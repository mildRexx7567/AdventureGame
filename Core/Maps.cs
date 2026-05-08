using System;
using AdventureGame.Models;

namespace AdventureGame.Core
{
    public class Map
    {
        public Room[,] Grid = new Room[4, 4];
        Random rand = new Random();

        public void Init()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Grid[i, j] = new Room
                    {
                        HasLight = rand.Next(2) == 0,
                        HasFuel = rand.Next(4) == 0,
                        HasChest = rand.Next(3) == 0,
                        HasPresence = rand.Next(5) == 0
                    };
                }
            }

            Grid[3, 3].IsExit = true;
            Grid[rand.Next(4), rand.Next(4)].HasKey = true;
        }
    }
}