High-Quality Programming Code – Team Project
=============================================

 Team? Battle Field 4
--------
The project consists of one  **source code file**, which is provided [here](https://github.com/kiko81/HQC---Battle-Field-4-TeamWork/blob/master/before/Program.cs)





    -   **Document the refactorings** you have performed in order to improve the quality of the project. Use English language and follow the sample (see below). The documentation must be in `.md` (GitHub Markdown) format.
    -   Document all public members and classes using **XML documentation** within the code and generate **CHM documentation**.
    -   Add **code comments** where appropriate
6.	**Add new functionalities** to the game. The more functionalities you add the more points you will get.
	-	Follow all principles and unit test you new game functionalities.

Deliverables
------------

1.  The **original source code** (project files, .cs files) without executables (in folder `/before/`).
2.  The **refactored source code** (project files, .cs files) without executables (in folder `/src/`).
3.  The **unit tests** – source code (project files, .cs files) without executables (in folder `/tests/`).
4.  The **refactoring documentation**. (`README.md` file)

Team Work Requirements
----------------------

-   Obligatory use **Git** as source code repository and **GitHub** (<http://github.com>) as project hosting and team collaboration environment. SVN or TFS are **not** allowed for this project.
	-	Take advantage of the GitHub issues for project management
-   **Each team member** should have contributions to the project and **commits in the source control repository in 7 different days**. We acknowledge that this requirement seems a bit unnatural, but we want to track **how the team collaborates over the time** and that the **project is developed incrementally**, not in the “last minute”.

Other Requirements
------------------

-   Every team member should send the project in the students system http://telerikacademy.com.
	-	Pack the project deliverables in a **single ZIP archive**.
	-	Be sure to avoid including large unused files in the archives (e.g. compilation binaries).
	-	Your archive should be up to 8 MB.
	-	Each team member should submit the same archive as a homework.
-   Be prepared as a team to **defend your project** in front of the course lecturers. You should be able to explain what refactorings have been performed and why. The documentation will definitely help you. Be prepared to **demonstrate how the unit tests cover the project’s functionality**. Preferably bring your own laptop to reduce the effort to setup your development environment and project workspace.
-	Be prepared to **explain the used patterns and SOLID principles**.
-   Be prepared to **show the commit logs** from the source control system to demonstrate how the project development efforts are shared between the team members and over the time.

Discussion Forum
----------------

-   You can freely discuss the course projects and ask questions in the official discussion forum of the course: <https://telerikacademy.com/Forum/Category/19/c#-qpc>

Sample Refactoring Documentation for Project “Game 15”                                                                                                                          
------------------------------------------------------

1.  Redesigned the project structure: Team 
	-   Renamed the project to `BattleField`.
	-   Renamed the main class `Program` to `EntryPoint`.
	-   All classes are in their own .cs file
	-   All logic moved to Battlefield.Logic class library 
2.  Reformatted the source code:
	-   Removed all unneeded empty lines
	-   Inserted empty lines according to C# formatting guidelines
	-   Inserted curlu braces afer each loop and conditional statement
	-   Split the lines containing several statements into several simple lines
	-   Character casing: variables and fields made **camelCase**; types, methods and constatnts made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in C# formatting guidelines
	-   …
3.  Renamed variables:
	-   all indexers renamed for better understanding
	-   chinese strings translated to english
	-   all shlyokavca variable and method names renamed 
4.  Introduced global constants:
	-   `MinFieldSize = 5`
	-   `MaxFieldSize = 20`
	-   `MinimumPercentageOfBombs = 15`
	-   `many local constants`
	-   `explosion patterns moved to classes as readonly fields`
5.  Introduced classes
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
6.  Methods
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

7.  Static classes
-   Moved method `GenerateRandomNumber(int start, int end)` to separate class `RandomUtils`.
-   validations moved to separate class `Validators` - not all of them 
8. New features 
-    multiple players - e.g. 2
-    chain reaction - single chain (eternal isn't suitable here)
-    explosion inversion - self explainatory
9. Design Patterns
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
10. Unit tests... i'm beginning them - no one else will