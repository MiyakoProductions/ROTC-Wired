//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// Revenge Of The Cats - standard.cs
// Code for the standard CAT
//------------------------------------------------------------------------------

exec("share/shapes/rotc/players/standardcat/player.cs");

exec("./standard.sfx.cs");
exec("./standard.gfx.cs");

datablock PlayerData(RedStandardCat)
{
	className = StandardCat;
	
	firstPersonOnly = true;
	
	targetLockTimeMS = 200;
	
	hudImageNameFriendly = "~/client/ui/hud/pixmaps/teammate.cat.png";
	hudImageNameEnemy = "~/client/ui/hud/pixmaps/enemy.cat.png";

	useEyePoint = true;
	renderFirstPerson = true;
	emap = true;

    eyeOffset = "0 -0.2 -0.02";
    cameraDefaultFov = 110.0;
	cameraMinFov	  = 30.0;
	cameraMaxFov	  = 130.0;
	cameraMinDist = 1;
	cameraMaxDist = 5;

	shapeFile = "share/shapes/rotc/players/standardcat/player2.red.dts";
 
	//cloakTexture = "share/shapes/rotc/effects/explosion_white.png";
	shapeFxTexture[0] = "share/textures/rotc/connection2.png";
	shapeFxTexture[1] = "share/textures/rotc/connection.png";
	shapeFxTexture[2] = "share/textures/rotc/barrier.green.png";
	shapeFxTexture[3] = "share/textures/rotc/armor.white.png";
	shapeFxTexture[4] = "share/textures/rotc/armor.orange.png";
	shapeFxTexture[5] = "share/textures/rotc/bounce.orange.hit.png";
	shapeFxTexture[6] = "share/textures/rotc/bounce.orange.miss.png";

	shapeFxColor[0] = "1.0 1.0 1.0 1.0";  
	shapeFxColor[1] = "1.0 0.0 0.0 1.0";  
	shapeFxColor[2] = "1.0 0.5 0.0 1.0";  
	shapeFxColor[3] = "0.0 0.5 1.0 1.0";  

	computeCRC = true;

	canObserve = true;
	cmdCategory = "Clients";

	renderWhenDestroyed = false;
	debrisShapeName = "share/shapes/rotc/players/standardcat/debris.red.dts";
	debris = StandardCatDebris;

	aiAvoidThis = true;

	minLookAngle = -1.5;
	maxLookAngle = 1.5;
	minLookAngleMarching = -1.5;
	maxLookAngleMarching = 1.5;
	minLookAngleCrouched = -1.5;
	maxLookAngleCrouched = 1.5;
	minLookAngleProne = -0.8;
	maxLookAngleProne = 0.8;

	maxFreelookAngle = 3.0;

	mass = 90;
	drag = 0.0;
	density = 10;
	gravityMod = 1.0 * $Server::game.lowgrav;

	maxDamage = 75;
	damageBuffer = 25;
	maxEnergy = 100 * $Server::Game.energyMod;

	repairRate = 0.8 * $Server::Game.repairMod;
	damageBufferRechargeRate = 0.15;
	damageBufferDischargeRate = 0.15;
	energyRechargeRate = 0.4 * $Server::Game.chargeMod;

	skidSpeed = 20 * $Server::Game.slowpokemod;
	skidFactor = 0.4;

	flyForce = 10 * 90 * $Server::Game.slowpokemod;

	runForce = 100 * 90 * $Server::Game.slowpokemod; // formerly 48 * 90
	runEnergyDrain = 0;
	minRunEnergy = 0;
	
	slideForce = 20 * 90 * $Server::Game.slowpokemod;
	slideEnergyDrain = 0;
	minSlideEnergy = 0;

	maxForwardSpeed = 15 * $Server::Game.slowpokemod;
	maxBackwardSpeed = 12 * $Server::Game.slowpokemod;
	maxSideSpeed = 12 * $Server::Game.slowpokemod;
	maxForwardSpeedSliding = 30 * $Server::Game.slowpokemod;
	maxBackwardSpeedSliding = 25 * $Server::Game.slowpokemod;
	maxSideSpeedSliding = 12 * $Server::Game.slowpokemod;
	maxForwardSpeedMarching = 8 * $Server::Game.slowpokemod;
	maxBackwardSpeedMarching = 8 * $Server::Game.slowpokemod;
	maxSideSpeedMarching = 5 * $Server::Game.slowpokemod;
//	maxForwardSpeedCrouched = 15; NOT USED
//	maxBackwardSpeedCrouched = 12; NOT USED
//	maxSideSpeedCrouched = 10; NOT USED
//	maxForwardSpeedProne = 3; NOT USED
//	maxBackwardSpeedProne = 3; NOT USED
//	maxSideSpeedProne = 2; NOT USED

	maxUnderwaterForwardSpeed = 8.4 * $Server::Game.slowpokemod;
	maxUnderwaterBackwardSpeed = 7.8 * $Server::Game.slowpokemod;
	maxUnderwaterSideSpeed = 7.8 * $Server::Game.slowpokemod;
	// [todo: insert values for other body poses here?]

	jumpForce = 8 * 90 * $Server::Game.jumpMod;  // 12 * 90
	jumpEnergyDrain = 0;
   reJumpForce = 10 * 90 * $Server::Game.rejumpMod; // script field
   reJumpEnergyDrain = 20; // script field
	minJumpEnergy = 00;
	jumpDelay = 0;
	
	recoverDelay = 9;
	recoverRunForceScale = 1.2;

	minImpactSpeed = 30; //
	speedDamageScale = 3.0; // dynamic field: impact damage multiplier

	boundingBox = "1.2 1.1 2.7";
	pickupRadius = 0.75;

	// Controls over slope of runnable/jumpable surfaces
	maxStepHeight = 1.0;
	maxStepHeightMarching = 1.0;
	maxStepHeightCrouched = 1.0;
	maxStepHeightProne = 0.2;
	runSurfaceAngle  = 40;
	runSurfaceAngleMarching  = 40;
	runSurfaceAngleCrouched  = 40;
	runSurfaceAngleProne  = 50;

	jumpSurfaceAngle = 30;

	minJumpSpeed = 20;
	maxJumpSpeed = 30;

	horizMaxSpeed = 200;
	horizResistSpeed = 30;
	horizResistFactor = 0.35;

	upMaxSpeed = 65;
	upResistSpeed = 25;
	upResistFactor = 0.3;

	footstepSplashHeight = 0.35;

	// Damage location details
	boxNormalHeadPercentage		 = 0.83;
	boxNormalTorsoPercentage		= 0.49;
	boxHeadLeftPercentage			= 0;
	boxHeadRightPercentage		  = 1;
	boxHeadBackPercentage			= 0;
	boxHeadFrontPercentage		  = 1;

	// footprints
	decalData	= RedStandardCatFootprint;
	decalOffset = 0.25;

	// foot puffs
	footPuffEmitter = RedStandardCatFootPuffEmitter;
	footPuffNumParts = 5;
	footPuffRadius = 0.2;
	
	// ground connection beam
	groundConnectionBeam = StandardCatGroundConnectionBeam;

   numShapeTrails = 5;

	// slide emitters
	//slideContactParticleFootEmitter = RedSlideEmitter;
	slideContactParticleTrailEmitter[0] = CatSlideContactTrailEmitter;
	slideParticleFootEmitter = RedCatSlideFootEmitter;
	//slideParticleTrailEmitter[0] = BlueSlideEmitter;
	skidParticleFootEmitter = CatSkidFootEmitter;
	skidParticleTrailEmitter[0] = CatSkidTrailEmitter0;
	skidParticleTrailEmitter[1] = CatSkidTrailEmitter1;
	
	// damage info eyecandy...
	damageBufferParticleEmitter = RedCatDamageBufferEmitter;
	repairParticleEmitter = RedCatRepairEmitter;
//	bufferRepairParticleEmitter = RedCatBufferRepairEmitter;
//	damageParticleEmitter = RedCatDamageEmitter;
//	bufferDamageParticleEmitter = RedCatBufferDamageEmitter;	
	damageDebris = RedCatDamageDebris;
//	bufferDamageDebris = CatBufferDamageDebris;

	// not implemented in engine...
	// dustEmitter = StandardCatLiftoffDustEmitter;

	splash = StandardCatSplash;
	splashVelocity = 4.0;
	splashAngle = 67.0;
	splashFreqMod = 300.0;
	splashVelEpsilon = 0.60;
	bubbleEmitTime = 0.4;
	splashEmitter[0] = StandardCatFoamDropletsEmitter;
	splashEmitter[1] = StandardCatFoamEmitter;
	splashEmitter[2] = StandardCatBubbleEmitter;
	mediumSplashSoundVelocity = 10.0;
	hardSplashSoundVelocity = 20.0;
	exitSplashSoundVelocity = 5.0;

	//NOTE:  some sounds commented out until wav's are available

	// Footstep Sounds
	LeftFootSoftSound		= StandardCatLeftFootSoftSound;
	LeftFootHardSound		= StandardCatLeftFootHardSound;
	LeftFootMetalSound	  = StandardCatLeftFootMetalSound;
	LeftFootSnowSound		= StandardCatLeftFootSnowSound;
	LeftFootShallowSound	= StandardCatLeftFootShallowSplashSound;
	LeftFootWadingSound	 = StandardCatLeftFootWadingSound;
	RightFootSoftSound	  = StandardCatRightFootSoftSound;
	RightFootHardSound	  = StandardCatRightFootHardSound;
	RightFootMetalSound	 = StandardCatRightFootMetalSound;
	RightFootSnowSound	  = StandardCatRightFootSnowSound;
	RightFootShallowSound  = StandardCatRightFootShallowSplashSound;
	RightFootWadingSound	= StandardCatRightFootWadingSound;
	FootUnderwaterSound	 = StandardCatFootUnderwaterSound;
	//FootBubblesSound	  = FootBubblesSound;
	//movingBubblesSound	= ArmorMoveBubblesSound;
	//waterBreathSound	  = WaterBreathMaleSound;

	impactSoftSound		= StandardCatImpactSoftSound;
	impactHardSound		= StandardCatImpactHardSound;
	impactMetalSound	  = StandardCatImpactMetalSound;
	impactSnowSound		= StandardCatImpactSnowSound;

	//impactWaterEasy		= ImpactLightWaterEasySound;
	//impactWaterMedium	 = ImpactLightWaterMediumSound;
	//impactWaterHard		= ImpactLightWaterHardSound;

	groundImpactMinSpeed	 = 10.0;
	groundImpactShakeFreq	= "4.0 4.0 4.0";
	groundImpactShakeAmp	 = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10.0;

	//exitingWater			= ExitingWaterLightSound;
	slideSound = PlayerSlideSound;
	slideContactSound = PlayerSlideContactSound;
	skidSound = PlayerSkidSound;

	observeParameters = "0.5 4.5 4.5";
};

if($Game::GameType != $Game::Ethernet)
{
	RedStandardCat.groundConnectionBeam = "";
}

if($Server::Game.noshield)
	RedStandardCat.damageBuffer = 0;

if($Server::Game.lowhealth)
	RedStandardCat.maxDamage = 50;

function RedStandardCat::onAdd(%this, %obj)
{
	Parent::onAdd(%this, %obj);
	%obj.mountImage(RedCatLightImage, 3);
}

datablock PlayerData(BlueStandardCat : RedStandardCat)
{
	shapeFile = "share/shapes/rotc/players/standardcat/player2.blue.dts";
	shapeFxTexture[2] = "share/textures/rotc/barrier.orange.png";
	shapeFxTexture[4] = "share/textures/rotc/armor.cyan.png";
	shapeFxTexture[5] = "share/textures/rotc/bounce.green.hit.png";
	shapeFxTexture[6] = "share/textures/rotc/bounce.green.miss.png";
	shapeFxColor[0] = "1.0 1.0 1.0 1.0";  
	shapeFxColor[1] = "0.0 0.0 1.0 1.0";  
	shapeFxColor[2] = "0.0 0.5 1.0 1.0";  
	shapeFxColor[3] = "1.0 0.5 0.0 1.0";  
	debrisShapeName = "share/shapes/rotc/players/standardcat/debris.blue.dts";
	decalData = BlueStandardCatFootprint;
	footPuffEmitter = BlueStandardCatFootPuffEmitter;
	slideParticleFootEmitter = BlueCatSlideFootEmitter;
	damageBufferParticleEmitter = BlueCatDamageBufferEmitter;
	repairParticleEmitter = BlueCatRepairEmitter;
//	bufferRepairParticleEmitter = BlueCatBufferRepairEmitter;
//	damageParticleEmitter = BlueCatDamageEmitter;
//	bufferDamageParticleEmitter = BlueCatBufferDamageEmitter;	
	damageDebris = BlueCatDamageDebris;
//	bufferDamageDebris = CatBufferDamageDebris;
};

function BlueStandardCat::onAdd(%this, %obj)
{
	Parent::onAdd(%this, %obj);
	%obj.mountImage(BlueCatLightImage, 3);
}

