# Sprint Planner
Here is the Sprint Planner that will be used to document our plans, design changes, and so forth for the sprints within this class.

## Sprint 5 Plan

### Start Date: 11/09/24 
### End Date: 11/30/24 @ noon

| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Gun Powerup | 0 hrs | 0 hrs | Aidan Whitlatch | 11/23 | 11/16 |
| Boss Level (XML file) | 0 hrs | 0 hrs | Jingyu Fu | 11/23 | 11/27 |
| Bowser (we already have sprites and class for bowser, but further features need to be implemented)| 0 hrs | 0 hrs | Zhuoyang Li + Aidan Whitlatch | 11/25 | 11/20|
| Bowser Fireball Attack (we already have sprites and class for bowser fireball, but further features need to be implemented)| 0 hrs | 0 hrs| Hahn Choi + Christian Blue |11/25 | 11/20|
| Bowser Hammer Attack | 0 hrs | 0 hrs | Zhouyang Li + Aidan Whitlatch| 11/25 | 11/20 |
| New Blocks | 0 hrs | 0 hrs | Christian Blue | 11/17 | 11/25 |
| Moveable Platform | 0 hrs | 0 hrs | Christian Blue | 11/17 | 11/24 |
| New Enemy (Can be simple, maybe bullet bill?)| 0 hrs | 0 hrs | Hahn Choi | 11/23 | 11/25 |
| New Levels (XMLFiles, aim for 2-3)| 6 hrs | 6 hrs | Zhuoyang Li | 11/25 | 11/27 |
| Podoboos (fireballs that jump out of lava, used in castle level) | 0 hrs | 0 hrs | Hahn Choi | 11/25 | 11/25 |
| Main Menu |0 hrs | 0 hrs | Jingyu Fu  | 11/23 | 11/13
| Spawner(teleporter) |0 hrs | 0 hrs | Jingyu Fu  | 11/23 | 11/13
| Level transition |0 hrs | 0 hrs | Jingyu Fu  | 11/23 | 11/13
| Fall detection |0 hrs | 0 hrs | Jingyu Fu  | 11/23 | 11/13

## BackLog tasks from Sprint4
### Not required for this sprint but would improve the quality of our code

| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Privatize public variables within GameObject classes | 8 hrs | 8 hrs| Will only be done if there is time | 11/27 | Did not have time |

## List of new Features (classes)
Strikethrough implies that the item has been completed
* ~~Gun Powerup decorater~~
  - ~~Handle shooting~~
  - ~~Handle drawing the gun~~
  - ~~Removing the Powerup~~
* ~~Mouse Controller~~
  - ~~Used to keep track of the mouse's position~~
  - ~~On click command execution~~
 * ~~Bowser Class~~
   - Various behaviors that will detail the execution of his attacks (Could be their own separate classes)
      * ~~Jump Behavior~~
      * ~~Fireball Behavior~~
      * ~~Hammer Attack Behavior~~
* ~~New Block classes (new block states in the context of our project)~~
  - ~~Includes a moveable platform~~

* Main Menu
   - ~~Play~~
   - ~~Credits~~
   - ~~Quit~~
* ~~Spawner~~
   - ~~Fall detection(reset Mario's location when he fell)~~
   - ~~a "from-to" spawner/teleporter (from 1-1 to underworld, from 1-1 to 1-2, from main menu to 1-1), setting Mario's location after a specific trigger event~~
   - ~~has a method like teleport(x,y){}. setting Mario to any location in the current game world for testing~~
* ~~Level transition~~
  - ~~Gameworld manager: keeps track of the current gameworld(1-1,1-1under ...) so that it can work with pipes~~
  - ~~intermediate state: similar to "win" but not exactly win, just "stage-clear" and then move to the next level~~
  - ~~Rewrite how the level is loaded so that transition can work smoothly~~

 ## Design changes
 There were no design changes related to our Sprint 5 content but our level loader class was given more modularity this sprint. The level loader can now take in a 
 differnent format of xml that leads to a created object without having to overly rely on switch cases when determing what kind of object to create. This is done with
 reflections in c# that allow objects to be essintially created just from the string containing their full assembly name as long as they are given the correct parameters during
 construction. The new xml format supplies all of the needed parameters and reflection allows these strings to be converted to their respective types. All together this allows
 creation of a new object without having to overly rely on the switch case structure of our older level loader.

 Note: that the old level loader design is still in use throughout the code so it could not be deleted due to technical debt.
