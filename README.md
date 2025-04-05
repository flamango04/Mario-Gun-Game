# Super Mario

### Course: CSE 3902 AU24

### Instructor: Neil Kirby

### Team: Five-Guys

- Christian Blue
- Hahn Choi
- Jingyu Fu
- Zhuoyang Li
- Aidan Whitlatch

## Game Introduction

Super Mario is a classic platform adventure game that takes players on an exciting journey through the Mushroom
Kingdom. Join Mario, the courageous plumber, as he embarks on a quest to rescue Princess Peach from the clutches of
the evil Bowser. Leap over obstacles, stomp on enemies, and navigate treacherous landscapes filled with hidden
secrets and power-ups. Whether you’re dodging fire-breathing plants or exploring underwater realms, each level offers
a new challenge and surprise. With iconic music, vibrant graphics, and timeless gameplay, Super Mario is a thrilling
adventure that brings joy to gamers of all ages. Get ready to jump, run, and save the day!

## How to play the game

#### Player control:

- W/Up Arrow: jump
- A/Down Arrow: move left
- D/Right Arrow: move right
- S/Left Arrow: crouch
- Z: throw the fireball
- 3: power up
- P: Pause the game
- Q: Quit the game
- R: Reset
- E: Force the Player to take damage
- Left mouse button: To shoot when mario has the gun mario power-up

## Sprint5 Content

Features Implemented

1. Main Menu
   
   Description: The main menu is treated as a playable level, allowing Mario to move and interact before starting the actual game. This unique approach makes the main menu more engaging than a static screen and there are tutorial texts on the main menu screen.
   
   Mario spawns at a designated location within the main menu level. 
   Players can interact with elements like pipes to transition to the first level.

3. Spawner/Teleporter
   
   Description: A Spawner class manages Mario's spawn and teleportation across levels. It ensures consistency and reduces redundant code.
   
   Functionality:
   
   Tracks the spawn location for Mario at the start of each level.
   Teleports Mario to a specific (x, y) location, especially useful for transitions like entering/exiting pipes or starting a new level.
   Ensures Mario always spawns at the correct location.

5. Level Transition
   
   Description: A system for transitioning between levels after specific events, such as flag capture or entering a pipe.
   
   Functionality:
   
   Switches between levels using a combination of Spawner and GameWorldManager.
   Plays a transition animation or video when Mario clears a level.
   Handles different game states, such as moving from the main menu to Level 1-1, 1-1 to 1-2, and so on.
   Teleports Mario to the correct starting location in the next level.
   A switch-case logic determines the destination level based on the current game world.
   Integrated with the sound system to play appropriate BGM for each level.

7. Fall Detection
   
   Description: Detects when Mario falls out of the playable bounds and handles the respawn or game-over process.
   
   Functionality:
   
   Monitors Mario's YPos to detect falls beyond the despawn height.
   Triggers a delay using a timer before resetting the game world or decrementing lives.
   Plays the "You Are Dead" sound effect during the delay.
   Integrates seamlessly with the spawner to respawn Mario at the correct location after a fall.
   Ensures a robust fail-safe mechanism for player falls.
   Improves player experience with smooth transitions after falls.

9. Sound Effects and Background Music
   
   Description: A sound system for managing background music and sound effects in the game.
   
   Functionality:
   
   SoundManager:
   
   Manages all sound-related operations, including loading, playing, pausing, stopping, and resuming sounds.
   Handles both SFX and BGM through dictionaries for easy access and extensibility.
   BGM:
   
   Includes background music for all 3 new levels.
   
   SFX:
   
   Includes sound effects for new enemies like bulletbill and bowser, and new items like gun.
   Supports simultaneous playback of multiple sound effects using the SoundEffectInstance system.
   Ensures smooth transitions between sounds based on game events.

6. Gun Powerup:
   
   Allows mario to pick up and hold the gun powerup. The gun will rotate to follow the direction of the mouse
   as it moves across the screen. However it can not rotate behind the direction mario is looking so it careful movement
   is required if you need to shoot behind you when playing through the levels.
7. Bowser Enemy

   Bowser stands as the final boss of the 4th level within our project. Bowser has multiple behavior's that he can choose from
   to attack the player at any given instant. Bowser can throw fireballs, throw hammers, jump, and patrol a given area. There is
   a system in place to ensure that there is a lower chance for bowser to repeat any given behavior which leads to more varied
   gameplay during the boss fight.


Extensibility

1. Level Design: Extend levels with more challenging mechanics and interactive elements by adding new xml files with level data.

2. Expanded GameWorldManager: Support for additional worlds and dynamically loaded levels.

3. Enhanced Player Abilities: Introduce new power-ups, weapons, and gameplay mechanics.

4. Optimized Sound System: Add spatial sound effects and improve performance for larger sound libraries.


## Team Management

We reflected on our experience in implementing last Sprint and worked to do a better job of teamwork and project management this time:
First, we implemented most of the features a week before the deadline, and we identified and solved problems in the code during each class discussion.
Secondly, we made appointments with instructors and TAs for Code Review and Group Meeting in advance, which left us enough time for Debugging and Refactoring.
The project progress management was also better than last time, we created different channels on the Discord server for us to implement different functionalities in smaller groups; we had different branches in the Github repository to implement and test the code, which accelerated our progress.

## Tools and Processes Used

1. **Command Pattern:**

   - The project implements the Command pattern for handling user inputs. Each command is encapsulated in its own
     class, making the codebase modular and easier to manage.
2. **Object Manager:**

   - The **GameObjectManager** is a central class(Singleton)  responsible for managing all the game objects in game, such as player, enemies, items, background elements, and blocks.
3. **XML Files:**

   - First we used Microsoft Excel to fill in the level data, the reason we used Excel is that it's easy to modify and generate whole rows and columns of data with it and most of the blocks in the levels have some of the same attributes such as height, name etc. We then wrote an external program in python to read the data from the Excel sheet and use it to generate XML files.
4. **.NET Type system**
   - This allows us to use Reflections to create new ICommands objects during runtime that are then executed to resolve detected collisions. 
5. **Singletons**
   - Various singletons are used to ensure easy global access to classes that are utilized in a wide range of areas within the code. A few examples are the UniversalSpriteFactory, the HUD, and the Game1 cla
## Notes
* The bullet bills are meant to pass through blocks
* The gun power up is designed to be removed when the level is completed. It is not a bug when the powerup disappears after touching the flag pole
## Known Bugs

* Mario can clip out of bounds if he kicks the shell near a wall. The collision with the shell will cause mario to be push out of bounds.
* When little mario is running and crouch is held, mario will be stuck in the run animation even though he is not moving.
* xml file from the XMLgenerator might generates a file start with:
  ```xml
   line1: <?xml version="1.0" encoding="utf-8" ?>
   line2: <?xml version="1.0" ?>"
  Manually delete the line2 before using this file
