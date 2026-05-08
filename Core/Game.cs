using System;
using AdventureGame.Models;

namespace AdventureGame.Core
{
    public class Game
    {
        Player player = new Player();
        Map map = new Map();
        Random rand = new Random();

        public void Start()
        {
            Console.WriteLine("==== ADVENTURE GAME ====");
            Console.Write("Enter your name: ");
            player.Name = Console.ReadLine() ?? "";

            map.Init();
            GameLoop();
        }

        void GameLoop()
        {
            while (true)
            {
                Console.WriteLine($"\n{player.Name} | Flashlight: {player.FlashlightUses}/5 | Key: {player.HasKey}");
                ShowMap();

                Console.Write("Move (W/A/S/D): ");
                string input = (Console.ReadLine() ?? "").ToUpper();

                MovePlayer(input);
                EnterRoom();
            }
        }

        void ShowMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == player.X && j == player.Y)
                        Console.Write(" P ");
                    else
                        Console.Write(" . ");
                }
                Console.WriteLine();
            }
        }

        void MovePlayer(string input)
        {
            int newX = player.X;
            int newY = player.Y;

            if (input == "W") newX--;
            if (input == "S") newX++;
            if (input == "A") newY--;
            if (input == "D") newY++;

            if (newX >= 0 && newX < 4 && newY >= 0 && newY < 4)
            {
                player.X = newX;
                player.Y = newY;
            }
            else
            {
                Console.WriteLine("Path blocked!");
            }
        }

        void EnterRoom()
        {
            Room room = map.Grid[player.X, player.Y];

            if (!room.HasLight)
            {
                player.DarkRoomsInRow++;
                player.FlashlightUses--;

                if (player.FlashlightUses <= 0)
                {
                    Console.WriteLine("No flashlight. Game Over.");
                    Environment.Exit(0);
                }
            }
            else
            {
                player.DarkRoomsInRow = 0;
            }

            if (player.DarkRoomsInRow >= 3)
            {
                Console.WriteLine("Something got you in the dark... Game Over.");
                Environment.Exit(0);
            }

            if (room.HasFuel)
            {
                Console.WriteLine("Found fuel (+2)");
                player.FlashlightUses = Math.Min(5, player.FlashlightUses + 2);
                room.HasFuel = false;
            }

            if (room.HasChest)
            {
                Console.WriteLine("Open chest? (y/n)");
                if ((Console.ReadLine() ?? "").ToLower() == "y")
                {
                    if (rand.Next(2) == 0)
                    {
                        Console.WriteLine("Mimic! You died.");
                        Environment.Exit(0);
                    }
                    else if (room.HasKey)
                    {
                        Console.WriteLine("You got the key!");
                        player.HasKey = true;
                    }
                }
            }

            if (room.IsExit)
            {
                if (player.HasKey)
                {
                    Console.WriteLine("YOU WIN!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Need a key.");
                }
            }
        }
    }
}