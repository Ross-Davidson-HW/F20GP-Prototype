# F20GP-Prototype

This repository contains my Unity prototype for Heriot-Watt Universitys F20GP - Computer Games Programming course. Built in Unity 2020.3.28f1, it utilises simple shapes to create a level for the player to move around in. The goal is to collect 9 "star" spheres within the level while avoiding walls of "fire" and small "goblin" cubes. There are also several blue spheres that create a minor hazard for the player to move through while been ushed around and bounced between them.

Should the player succeed in collecting all 9 stars, they will be presented with a victory screen, and the game ends.

This was primarily made using C# and Unity.

Scripts are split into 3 main areas: The Player scripts, the level scripts and the flock scripts.

As the game is isometric, the controls had to be adjusted to work with that viewpoint. By default, pressing "W" or whichever key is assigned to forwards moves you on the Z axis. From my isometric view, this looks like you are moving towards the upper left. As such, I had to alter the controls to move you on both the X and Z axis when W is held down. This can be found in the "movement" script within the Player folder. The Camera is also set to follow the player around the level, which can be found in the FollowPlayer script within the Camera folder.

The Flock is the largest piece of code within the project, and can be found in the Environment folder. It consists of several behaviour scripts, which are used to generate ScriptObjects, as well as two filters and associated objects to control what the flock does and does not approach.

Otherwise the level itself is build of simple cube and sphere shapes, with some set to the "danger" tag/layer to allow other scripts to interact with them. The game consists of three scenes: The Start menu, the Level itself, and the Victory screen.

