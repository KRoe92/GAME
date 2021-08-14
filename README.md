I've gotten through all the objectives on the list, so I thought I'd write any notes I had on each of the objectives.

1) Setting up the project was simple, I chose to use the same version of Unity just to avoid any initial headaches at the start of the Test.

2) The most common warning was the SerializedField private warning, where Unity doesnt realise you can set a serialized private member in the inspector. I dont think this warning 
happens in later Unity versions anymore. Setting the value to default also sorts it out.

3) For the singleton I ended up setting up a new abstract singleton class, because I used another singleton for managing the volume.

4) For the UI canvas scaling, i set the canvas scaler to scale with screen size and set te scale mode to match height. It scales correctly to match in the game in all 
resolutions but doesnt fit in all portrait resolutions.

5) Added a scriptable object for designers to set the game settings. I chose a scriptable object so they can create multiple presets. Admittedly for this objective it would 
have been nice to have a bit more info on the project as it took a few minutes to figure out the relationship between recipes and ingredients, and the goal of the game.

6) Setting up the Main menu was fine

7) The volume menu was fine, but there was no volume in the project so it was a little tricky to test :D but i'm pretty positive that AudioListener.audio handles the game volume. 
The player prefs seem to work well for persisting the volume value.

8) The bulk of the build errors were files referencing the unity editor. These either need to be put between  #if UNITY_EDITOR  #endif or throw the entire file into an editor folder.

Optional 1) This was easy enough, just needed to unassign the previous cell before setting an item into a new cell.

Optional 2) This was okay as well, ideally the grid cells should be pooled instead of instantiated. And you could do the cell creation and neighbouring in the same loop 
and it would be more efficient but i thought separating them would be more readable. I put a max of 6 x 5 for the grid dimensions because the grid exceeds the screen and 
UI if you go over that.

 
Final Notes: As I said in one of my last commits, I've locked the game to Landscape because the game doesnt fit on most portrait resolutions. It all runs fine on my phone,
and all the objectives are finished but it's a little anti-climactic because there's still so much in the game that doesnt work. The oven and pot buttons dont do anything,
the mixing grid never produces anything but failures, and the dish button spawns items on top of other items. All and all it was a pretty fun test though.

 
