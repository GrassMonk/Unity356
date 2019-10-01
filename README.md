# Unity356
Repository for the unity group project for CSCI356 - Game Engine Essentials.

*POWERUPS:
One can drag and drop the 'powerup' prefab into position on the scene. Then in the 'PowerUps' script component, drag and drop the elements:
1. PowerUp1Btn
2. PowerUp2Btn
3. PowerUp3Btn
4. PowerUp4Btn
Into the slots, respectively. Although this does seem tedious and inefficient, I was unable to find an alternative after trying to for half a day.
This process is required for each powerup added to the scene, and they will not function properly unless this is done.

Powerup 1: Speed boost
Powerup 2: Oil slick
Powerup 3: Bomb
Powerup 4: Super boost (Size, speed, mass increase)

The game UI is finished, however it is not functionally complete:
(e.g. the progress bar does not move, as im unsure how to measure progress. Place and lap do not change for similar reasons). 
I've created a 'resources' folder, this is for prefabs that are to be loaded through script (Resources.Load function requires it).
In that folder is the bomb, oil and explosion prefabs.