# Minesweeper

## About the kata

The goal of Minesweeper is to uncover all the squares on a board that do not contain mines without being "blown up" by clicking on a square with a mine underneath.  
To help the player, the game shows a number in a square (hint) which tells the player how many mines there are adjacent to that square.  

* * *

## [Kata requirements](./Requirements.md)

## Installation

### System Requirements

-   A command line interface (CLI) such as Command Prompt for Windows or Terminal for macOS
-   This application is built on [.Net Core 5.0.1 SDK](https://dotnet.microsoft.com/download)

### Clone

Clone this repo to your local machine and in the CLI, navigate into the folder containing the solution and type `dotnet restore` to install the package dependencies

```shell
$ git clone git@github.com:TiffanyHoang/minesweeper.git
$ cd <your chosen folder>
$ dotnet restore
```

### Running the game and enjoy 🎮

Navigate to the folder called `minesweeper` and run the project using the below commands:

```shell
$ cd minesweeper/
$ dotnet run --project Minesweeper_App
```

### Running the tests 🧪

Staying in the folder called `minesweeper`, enter `dotnet test` in your CLI to run the unit tests in the solution

```shell
$ dotnet test
```

To run the tests in watch mode

```shell
$ dotnet watch --project Minesweeper_Tests test 
```

* * *

## Usage

-   When prompted "Please enter the difficult level (from 2 to 10):", enter a number to select the difficult level
-   The board will display the hidden value square as "."
-   To select your chosen square position to reveal, enter two digits separated by a comma 
-   If your selected square is not mine, the game shows a number in a square (hint) which tells the player how many mines there are adjacent to that square.
-   If your selected square is mine, the game will prompt Lose and reveal the entire board with hints and mines.
-   The game will terminate when you reveal all safe square (win) or when you selected square is a mine (lose).

* * *

## Dependencies

[XUnit](https://xunit.net/) - Testing framework

* * *

## Flowchart

<img src="docs/flow-chart.png">
