# GSV
Gratuitous Stick Violence: A randomly generated mobile platformer created using Unity 2017.2.0f3

Contributors: Will Fleener, Henry Harrison, Randy Scheffler, Annie Hua

The general structure of the application is Main Menu -> Game -> Scoreboard -> Main Menu Repeat.
Main Menu, Game, and Scoreboard are all seperate scenes created in Unity.
Within each scene are multiple objects which add functionality and make up the game. On these objects are attributes and scripts.
An attribute, for example, may imbue an object with the ability to collide with other objects that can also carry out collisions.
Scripts are the real backbone of the project, however. They can control almost every aspect of a game object they are placed on,
as well as other game objects if referenced. They are powerful and allowed us to create GSV the way it is.

The general file structure is organized in such a way as to give types of files their own folder and to keep all files of that type in that
folder. All of these, and the completed work we did, are located in the overarching assets folder. 
For example, GSV -> Gratuitous Stick Violence -> Assets -> Scenes cointains three .Unity files that represent each of the three scenes 
(Main menu, scoreboard, and game). Another example is GSV -> Gratuitous Stick Violence -> Assets -> Background Images contains all the 
image files and associated materials used to create the background in the game.
