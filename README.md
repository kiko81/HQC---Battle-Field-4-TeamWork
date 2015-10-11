High-Quality Programming Code – Team Project
=============================================

 Team? Battle Field 4
--------
The project consists of one  **source code file**, which is provided [here](https://github.com/kiko81/HQC---Battle-Field-4-TeamWork/blob/master/before/Program.cs)
## Changes made:
### 1.  Redesigned the project structure: Team 
-   Renamed the project to `BattleField`.
-   Renamed the main class `Program` to `EntryPoint`.
-   All classes are in their own .cs file
-   All logic moved to Battlefield.Logic class library 
### 2.  Reformatted the source code:
-   Removed all unneeded empty lines
-   Inserted empty lines according to C# formatting guidelines
-   Inserted curlu braces afer each loop and conditional statement
-   Split the lines containing several statements into several simple lines
-   Character casing: variables and fields made **camelCase**; types, methods and constatnts made **PascalCase**.
-   Formatted all other elements of the source code according to the best practices introduced in C# formatting guidelines
-   …
### 3.  Renamed variables:
-   all indexers renamed for better understanding
-   chinese strings translated to english
-   all shlyokavca variable and method names renamed 
### 4.  Introduced global constants:
-   `MinFieldSize = 5`
-   `MaxFieldSize = 20`
-   `MinimumPercentageOfBombs = 15`
-   `many local constants`
-   `explosion patterns moved to classes as readonly fields`
### 5.  Introduced classes
- `Game` - starting facade 
- `ConsoleEngine` - the only engine 
-  `Player` - yes, player - we have many - e.g. 2 :smiley:
-  `Field` - the playfield
-  `Cell` - each cell of the playfield
-  `Coordinates` - structure holding x and y coordinates
-  `ConsoleInput` - self exlainatory
-  `ConsoleOutput` - see above
-  `All bombs are classes too
-  many supporting abstracts and interfaces
### 6.  Methods
*   in Engine
    -   `Start` - argument - current player, calling update method and finishing the game when so 
    -   `Update` - argument - current player, a player's turn 
*   in Player
     -  `TakeAShot` - getting input coordinates and shooting at battlefield 
* in Field
    -   `ToString` 
    -   `FillFieldWithEmptyCells` - self explainatory
    -   `PlaceBombs` - see above
    -   `Explode` - getting coordinates and some conditional stuff - the mechanism of the shooting - returns number of bombs detonated

### 7.  Static classes
-   Moved method `GenerateRandomNumber(int start, int end)` to separate class `RandomUtils`.
-   validations moved to separate class `Validators` - not all of them 
### 8. New features 
-    multiple players - e.g. 2
-    chain reaction - single chain (eternal isn't suitable here)
-    explosion inversion - self explainatory
### 9. Design Patterns
- Creational
    -  Simple factory - creating bombs
    -  Singleton - the bombs 
    -  Lazy loading - the singleton bombs
    -  Prototype - cloning bombs for chain reaction
-   Structural
    - Facade - Game.Initiate method - creating all needed for the game and starting it
    - Decorator - decorating bombs with InvertExplosion method
    - Composite - composing composite bomb for chain reaction
-   Behavioral
    - Startegy - getting the explosion pattern from the proper bomb
    - Template - the Update method
    - State or Command - to come - if ...
### 10. Unit tests... hopefully will be