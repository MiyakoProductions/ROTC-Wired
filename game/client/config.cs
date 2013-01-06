// Torque Input Map File
if (isObject(moveMap)) moveMap.delete();
new ActionMap(moveMap);
moveMap.bind(keyboard, "escape", toggleShellDlg);
moveMap.bind(keyboard, "backslash", freeLook);
moveMap.bind(keyboard, "p", toggleFirstPerson);
moveMap.bind(keyboard, "a", moveleft);
moveMap.bind(keyboard, "d", moveright);
moveMap.bind(keyboard, "w", moveforward);
moveMap.bind(keyboard, "s", movebackward);
moveMap.bind(keyboard, "space", trigger2);
moveMap.bind(keyboard, "lshift", trigger4);
moveMap.bind(keyboard, "lcontrol", trigger5);
moveMap.bind(keyboard, "shift f", toggleTempZoomLevel);
moveMap.bind(keyboard, "f", tempZoom);
moveMap.bind(keyboard, "t", toggleMessageHud);
moveMap.bind(keyboard, "shift t", teamMessageHud);
moveMap.bind(keyboard, "shift pageup", pageMessageHudUp);
moveMap.bind(keyboard, "shift pagedown", pageMessageHudDown);
moveMap.bind(keyboard, "i", resizeMessageHud);
moveMap.bind(keyboard, "y", biggerMiniMap);
moveMap.bind(keyboard, "c", activateCmdrScreen);
moveMap.bind(keyboard, "alt r", toggleRecordingDemo);
moveMap.bind(keyboard, "alt p", takeScreenshot);
moveMap.bind(keyboard, "tab", action0);
moveMap.bind(keyboard, "1", action1);
moveMap.bind(keyboard, "2", action2);
moveMap.bind(keyboard, "3", action3);
moveMap.bind(keyboard, "4", action4);
moveMap.bind(keyboard, "5", action5);
moveMap.bind(keyboard, "6", action6);
moveMap.bind(keyboard, "7", action7);
moveMap.bind(keyboard, "8", action8);
moveMap.bind(keyboard, "9", action9);
moveMap.bind(keyboard, "0", action10);
moveMap.bind(keyboard, "q", action11);
moveMap.bind(keyboard, "e", action13);
moveMap.bind(keyboard, "r", action14);
moveMap.bind(keyboard, "o", action15);
moveMap.bind(keyboard, "g", action16);
moveMap.bind(keyboard, "x", action17);
moveMap.bind(keyboard, "v", action18);
moveMap.bind(keyboard, "b", action19);
moveMap.bind(keyboard, "m", action20);
moveMap.bind(keyboard, "shift 1", action21);
moveMap.bind(keyboard, "shift 2", action22);
moveMap.bind(keyboard, "shift 3", action23);
moveMap.bind(keyboard, "shift 4", action24);
moveMap.bind(keyboard, "shift 5", action25);
moveMap.bind(keyboard, "shift 6", action26);
moveMap.bind(keyboard, "shift 7", action27);
moveMap.bind(keyboard, "shift 8", action28);
moveMap.bind(keyboard, "shift 9", action29);
moveMap.bind(keyboard, "shift 0", action30);
moveMap.bind(keyboard, "f1", action31);
moveMap.bind(keyboard, "f2", action32);
moveMap.bind(keyboard, "f3", action33);
moveMap.bind(keyboard, "f4", action34);
moveMap.bind(keyboard, "f5", action35);
moveMap.bind(keyboard, "f6", action36);
moveMap.bind(keyboard, "f7", action37);
moveMap.bind(keyboard, "f8", action38);
moveMap.bind(keyboard, "alt c", action39);
moveMap.bind(mouse0, "xaxis", S, 0.3, yaw);
moveMap.bind(mouse0, "yaxis", S, 0.3, pitch);
moveMap.bind(mouse0, "button0", trigger0);
moveMap.bind(mouse0, "button2", trigger3);
moveMap.bind(mouse0, "button1", trigger1);
moveMap.bind(mouse0, "zaxis", mouseZoom);
moveMap.bind(mouse0, "shift button2", action12);
