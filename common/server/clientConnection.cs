//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------


//-----------------------------------------------------------------------------
// This script function is called before a client connection
// is accepted.  Returning "" will accept the connection,
// anything else will be sent back as an error to the client.
// All the connect args are passed also to onConnectRequest
//
function GameConnection::onConnectRequest( %client, %netAddress, 
	%arg0, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7,  
	%arg8, %arg9, %arg10, %arg11, %arg12, %arg13, %arg14, %arg15 )
{
	%args = "";
	for(%i = 0; %i < 16; %i++)
		%args = %args SPC %arg[%i];

	echo("Connect request from: " @ %netAddress SPC "args:" SPC %args);

	if($Server::PlayerCount >= $pref::Server::MaxPlayers)
		return "CR_SERVERFULL";

	return "";
}

//-----------------------------------------------------------------------------
// This script function is the first called on a client accept
//
function GameConnection::onConnect( %client, 
	%arg0, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7,  
	%arg8, %arg9, %arg10, %arg11, %arg12, %arg13, %arg14, %arg15 )
{	
	%gameNameString = %arg0;
	%gameVersionString = %arg1;
	%name = %arg2;

	// Send down the connection error info, the client is
	// responsible for displaying this message if a connection
	// error occures.
	messageClient(%client,'MsgConnectionError',"",$Pref::Server::ConnectionError);
	
	// Simulated client lag for testing...
	// %client.setSimulatedNetParams(0.1, 30);

	// Get the client's unique id:
	// %authInfo = %client.getAuthInfo();
	// %client.guid = getField( %authInfo, 3 );
	%client.guid = 0;
	addToServerGuidList( %client.guid );
	
	// Set admin status
	if (%client.getAddress() $= "local") {
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
	}
	else {
		%client.isAdmin = false;
		%client.isSuperAdmin = false;
	}

	// Save client preferences on the connection object for later use.
	%client.gameNameString = %gameNameString;
	%client.gameVersionString = %gameVersionString;
	%client.gender = "Male";
	%client.armor = "Light";
	%client.race = "Human";
	%client.skin = addTaggedString( "base" );
	%client.setPlayerName(%name);
	%client.score = 0;

	// 
	$instantGroup = ServerGroup;
	$instantGroup = MissionCleanup;
	echo("CADD: " @ %client @ " " @ %client.getAddress());

	// Inform the client of all the other clients
	%count = ClientGroup.getCount();
	for (%cl = 0; %cl < %count; %cl++) {
		%other = ClientGroup.getObject(%cl);
		if ((%other != %client)) {
        	messageClient(%client, 'MsgClientJoinTeam', "",
        		%other.name,
        		%other.team.name,
        		%other.team.teamId,
        		%other,
        		%other.sendGuid,
        		%other.score,
        		%other.isAiControlled(),
        		%other.isAdmin,
        		%other.isSuperAdmin);
		}
	}

	// Inform the client we've joined up
	messageClient(%client,
		'MsgClientJoin', '\c2Welcome %1.',
		%client.name, 
		%client,
		%client.sendGuid,
		%client.score,
		%client.isAiControlled(), 
		%client.isAdmin, 
		%client.isSuperAdmin);

	// Inform all the other clients of the new guy
	messageAllExcept(%client, -1, 'MsgClientJoin', '\c1%1 connected.', 
		%client.name, 
		%client,
		%client.sendGuid,
		%client.score,
		%client.isAiControlled(), 
		%client.isAdmin, 
		%client.isSuperAdmin);
		
	// If the mission is running, go ahead download it to the client
	if ($missionRunning)
		%client.loadMission();
		
	%client.countedAsPlayer = true;
	$Server::PlayerCount++;		
}

//-----------------------------------------------------------------------------
// A player's name could be obtained from the auth server, but for
// now we use the one passed from the client.
// %realName = getField( %authInfo, 0 );
//
function GameConnection::setPlayerName(%client,%name)
{
	%client.sendGuid = 0;

	// Minimum length requirements
	%name = stripTrailingSpaces( strToPlayerName( %name ) );
	if ( strlen( %name ) < 3 )
		%name = "Poser";

	// Make sure the alias is unique, we'll hit something eventually
	if (!isNameUnique(%name))
	{
		%isUnique = false;
		for (%suffix = 1; !%isUnique; %suffix++)  {
			%nameTry = %name @ "." @ %suffix;
			%isUnique = isNameUnique(%nameTry);
		}
		%name = %nameTry;
	}

	// Tag the name with the "smurf" color:
	%client.nameBase = %name;
	%client.name = addTaggedString("\cp\c8" @ %name @ "\co");
}

function isNameUnique(%name)
{
	%count = ClientGroup.getCount();
	for ( %i = 0; %i < %count; %i++ )
	{
		%test = ClientGroup.getObject( %i );
		%rawName = stripChars( detag( getTaggedString( %test.name ) ), "\cp\co\c6\c7\c8\c9" );
		if ( strcmp( %name, %rawName ) == 0 )
			return false;
	}
	return true;
}

//-----------------------------------------------------------------------------
// This function is called when a client drops for any reason
//
function GameConnection::onDrop(%client, %reason)
{
	%client.onClientLeaveGame();
	
	removeFromServerGuidList( %client.guid );
	messageAllExcept(%client, -1, 'MsgClientDrop', '\c1%1 disconnected.', %client.name, %client);

	removeTaggedString(%client.name);
	echo("CDROP: " @ %client @ " " @ %client.getAddress());

   if(isObject(%client.cookies))
      %client.cookies.delete();
	
	if(%client.countedAsPlayer)
		$Server::PlayerCount--;
	
	// Reset the server if everyone has left the game
//	if( $Server::PlayerCount == 0 && $Server::Dedicated)
//		schedule(0, 0, "resetServerDefaults");
}


//-----------------------------------------------------------------------------

function GameConnection::startMission(%this)
{
	// Inform the client the mission starting
	commandToClient(%this, 'MissionStart', $missionSequence);
}


function GameConnection::endMission(%this)
{
	// Inform the client the mission is done
	commandToClient(%this, 'MissionEnd', $missionSequence);
}


//--------------------------------------------------------------------------
// Sync the clock on the client.

function GameConnection::syncClock(%client, %time)
{
	commandToClient(%client, 'syncClock', %time);
}

//--------------------------------------------------------------------------
// Cookies...

function GameConnection::sendCookie(%this, %name, %value)
{
	commandToClient(%this, 'Cookie', %name, %value);
}

function GameConnection::requestCookie(%this, %name)
{
	commandToClient(%this, 'CookieRequest', %name);
}
