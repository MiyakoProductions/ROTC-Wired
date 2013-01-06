$MissionInfo::Type = "\cp\c0ROTC:ETH\c2" SPC $GameVersionString @ "\co";
$MissionInfo::TypeDesc = "Capture all the opposing team's zones to win.";
$MissionInfo::InitScript = "game/server/missions/rotc-eth.cs";
$MissionInfo::MutatorDesc = ""
	@ "temptag\tPlayers are tagged from when they take damage until they're out of enemy LOS\n"
	@ "nevertag\tPlayers are never tagged\n"
	@ "noshield\tDeactivate CAT shields\n"
	@ "lowhealth\tCATs have 50 instead of 75 health\n"
	@ "slowpoke\tMakes the game slow\n"
	@ "superblaster\tReplaces normal blaster with high-powered hitscan version\n"
	@ "QUICKDEATH\tCombo: noshield/lowhealth\n"
	// Kitsune Added These
	@ "high-speed\tEveryone is on a high speed connection\n"
	@ "low-grav\tClassic Low Gravity\n"
	@ "high-grav\tIncreased Gravity\n"
	@ "super-jump\tJump like a fiend\n"
	@ "high-jump\tJump higher\n"
	@ "fast-repair\tRepairs shields faster\n"
	@ "fast-recharge\tRecharges energy faster\n"
	@ "half-energy\tEnergy is dropped to half\n"
	@ "double-energy\tEnergy is doubled\n"
	@ "quad-energy\tEnergy is quaded\n"
	@ "permaboard\tEtherboard is permanent\n"
	@ "slasher-disc\tRepel Disc becomes a Slasher Disc\n"
	@ "instagib\tClassic Instagib\n"
	@ "blaster-arena\tBlasters Only\n"
	@ "";

