# Adventure Game

A console-based adventure game made in **C#** using **Visual Studio Code** and the **.NET SDK**.

The player must explore rooms, manage flashlight resources, survive dangerous encounters, find the hidden key, and escape through the exit room.

---

# Problem Analysis

The purpose of this project is to create a text-based adventure game where the player explores a map while managing limited resources and avoiding dangers.

The game includes:

* A grid-based room system
* Player movement using directional controls
* A flashlight system with limited uses
* Dark rooms that create danger
* Chests that may contain rewards or deadly mimics
* Fuel pickups to recharge the flashlight
* A hidden key required to win the game
* A final exit room

The challenge is balancing exploration and survival while searching for the key.

---

# Solution Design

The game was designed using object oriented programming principles in C#.

## Main Classes

### Player

Stores:

* Position on the map
* Flashlight uses
* Key possession
* Darkness penalty tracking

### Room

Represents each room in the game map.

A room can contain:

* Light or darkness
* Fuel
* A chest
* The key
* The exit
* Dangerous presence events

### Map

Handles:

* Creating the room grid
* Randomly generating room properties
* Placing the exit and key

### Game

Controls:

* Main game loop
* Player movement
* Room interactions
* Win and lose conditions

---

# Gameplay Features

## Movement

The player moves using:

| Key | Action     |
| --- | ---------- |
| W   | Move Up    |
| S   | Move Down  |
| A   | Move Left  |
| D   | Move Right |
| Q   | Quit Game  |

---

## Flashlight System

* The flashlight starts with **5 uses**.
* Entering a dark room consumes **1 use**.
* Fuel restores **2 uses**.
* The flashlight cannot exceed 5 uses.

If the flashlight reaches 0:

**Game Over**

---

## Dark Room Penalty

Entering 3 dark rooms in a row causes the player to lose the game.

---

## Chests

Some rooms contain chests.

When opened:

* 50% chance the chest is safe
* 50% chance it is a mimic

If it is a mimic:

**Game Over**

---

## Key and Exit

* One room contains the hidden key.
* The player must find the key.
* The exit room is located at the bottom-right corner of the map.

Winning condition:

* Enter the exit room while holding the key.

---

# Project Structure

```plaintext
AdventureGame/
│
├── Core/
│   ├── Game.cs
│   └── Map.cs
│
├── Models/
│   ├── Player.cs
│   └── Room.cs
│
├── Program.cs
├── AdventureGame.csproj
```

---

# How to Run the Game

## Requirements

* .NET SDK
* Visual Studio Code

---

## Run Commands

Open terminal inside the project folder and run:

```bash
dotnet run
```

---

# GitHub Setup

## Initialize Git

```bash
git init
```

## Add Files

```bash
git add .
```

## Commit

```bash
git commit -m "Initial commit"
```

## Connect Repository

```bash
git remote add origin https://github.com/YOUR-USERNAME/AdventureGame.git
```

## Push to GitHub

```bash
git push -u origin main
```

---

# Future Improvements

Possible future upgrades:

* Better map visualization
* Real walls and blocked paths
* Save/load system
* Inventory system
* Smarter enemy AI
* Colored console UI
* More room events
* Sound effects

---

# Author

Created by Happy using C# and Visual Studio Code.
