//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

//************************************************
// Mission init script for ROTC: Ethernet missions
//************************************************

exec("./rotc-types.cs");

$Game::GameType = $Game::Ethernet;
$Game::GameTypeString = "ROTC: Ethernet";

$Server::MissionDirectory = strreplace($Server::MissionFile, ".mis", "") @ "/";
$Server::MissionEnvironmentFile = $Server::MissionDirectory @ "mission.env";

function executeMissionScript()
{
	exec($Server::MissionDirectory @ "mission.cs"); 
}

function executeEnvironmentScript()
{
	exec($Server::MissionEnvironmentFile @ ".cs"); 
}

function executeGameScripts()
{
	exec("game/server/base/exec.cs");
	exec("game/server/eth/exec.cs");
	exec("game/server/weapons/exec.cs");	
	exec("game/server/blueprints/exec.cs");	
}

function loadManual()
{
	constructManual("game/server/eth/help/index.idx");
	// hack hack hack
	if($Server::Game.superblaster)
	{
		%p = getManualPage("6.1");
		%p.name = "Superblaster";
		%p.file = "game/server/weapons/blaster3/blaster3.rml";
		updateManualPage(%p);
	}
}

function loadHints()
{
   constructHints("game/server/eth/help/hints.rml");
}

function initMission()
{
	if(isObject($Server::Game))
		$Server::Game.delete();
	$Server::Game = new ScriptObject();
	$Server::Game.mutators = "";
	$Server::Game.alwaystag = -1;
	$Server::Game.nevertag  = 0;
	$Server::Game.temptag   = 1;
	$Server::Game.tagMode = $Server::Game.alwaystag;
	$Server::Game.slowpokemod = 1.0;
	// Kitsune Added These
	$Server::Game.lowgrav = 1;
	$Server::Game.jumpMod = 1;
	$Server::Game.rejumpMod = 1;
	$Server::Game.energyMod = 1;
	$Server::Game.repairMod = 1;
	$Server::Game.chargeMod = 1;
	%recognized = "";
	for(%i = 0; %i < getWordCount($Pref::Server::Mutators); %i++)
	{
		%mutator = getWord($Pref::Server::Mutators, %i);
		if(%mutator $= "temptag")
		{
		 %recognized = %mutator SPC %recognized;
			$Server::Game.tagMode = $Server::Game.temptag;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "nevertag")
		{
		%recognized = %mutator SPC %recognized;
			$Server::Game.tagMode = $Server::Game.nevertag;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "noshield")
		{
		%recognized = %mutator SPC %recognized;
			$Server::Game.noshield = true;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "lowhealth")
		{
		%recognized = %mutator SPC %recognized;
			$Server::Game.lowhealth = true;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "slowpoke")
		{
		%recognized = %mutator SPC %recognized;
			$Server::Game.slowpoke = true;
			$Server::Game.slowpokemod = 0.5;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "superblaster")
		{
		%recognized = %mutator SPC %recognized;
			$Server::Game.superblaster = true;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "QUICKDEATH")
		{
		%recognized = %mutator SPC %recognized;
			$Server::Game.noshield = true;
			$Server::Game.lowhealth = true;
			$Server::Game.mutators = $Server::Game.mutators SPC
				"noshield" SPC "lowhealth";
		}
		// Kitsune Added These
		else if(%mutator $= "high-speed")
		{
			$Server::Game.slowpoke = true;
			$Server::Game.slowpokemod = 3;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "low-grav")
		{
			$Server::Game.lowgrav = 0.4;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "high-grav")
		{
			$Server::Game.lowgrav = 4;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "super-jump")
		{
			$Server::Game.jumpMod = 4;
			$Server::Game.rejumpMod = 2;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "high-jump")
		{
			$Server::Game.jumpMod = 3;
			$Server::Game.rejumpMod = 1.5;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "fast-repair")
		{
			$Server::Game.repairMod = 2;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "fast-recharge")
		{
			$Server::Game.chargeMod = 2;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "half-energy")
		{
			$Server::Game.energyMod = 0.5;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "double-energy")
		{
			$Server::Game.energyMod = 2;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "quad-energy")
		{
			$Server::Game.energyMod = 4;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "permaboard")
		{
			$Server::Game.permaboard = true;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "slasher-disc")
		{
			$Server::Game.slasherdisc = true;
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		// test
		else if(%mutator $= "instagib")
		{
			%recognized = %mutator SPC %recognized;
			$Game::GameType = $Game::Instagib;
			$Game::GameTypeString = "ROTC: Ethernet - Instagib";
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
		else if(%mutator $= "blaster-arena")
		{
			%recognized = %mutator SPC %recognized;
			$Game::GameType = $Game::BlasterArena;
			$Game::GameTypeString = "ROTC: Ethernet - Blaster Arena";
			$Server::Game.mutators = %mutator SPC $Server::Game.mutators;
		}
	}
	%recognized = trim(%recognized);
	if(getWordCount(%recognized) > 0)
	{
		// We have valid mutators...
		$Server::Game.mutators = trim($Server::Game.mutators);
		if(getWordCount(%recognized) == 1)
			%str = %recognized;
		else
			%str = "VARIANT";
		$Server::MissionType = $Server::MissionType SPC "\c4["@%str@"]\co";
	}
	executeGameScripts();
	executeMissionScript();
	executeEnvironmentScript();
	loadManual();
	loadHints();
}

function onMissionLoaded()
{
	// Called by loadMission() once the mission is finished loading.
	startGame();
}

function onMissionEnded()
{
	// Called by endMission(), right before the mission is destroyed

	if(isObject($Server::Game))
		$Server::Game.delete();

	// Normally the game should be ended first before the next
	// mission is loaded, this is here in case loadMission has been
	// called directly.  The mission will be ended if the server
	// is destroyed, so we only need to cleanup here.
	cancel($Game::Schedule);
	$Game::Running = false;
	$Game::Cycling = false;
}



		
