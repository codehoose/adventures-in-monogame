using System.Collections.Generic;

namespace Adventure
{
    internal class GameMap
    {
        public static RoomDescriptor FirstRoom = new RoomDescriptor
        {
            WallNorth = true,
            WallSouth = true,
            ExitEast = 1,
            ExitWest = 0,
            ExitNorth = 3,
            Seed = 456
        };

        public static RoomDescriptor EastOfFirstRoom = new RoomDescriptor
        {
            WallNorth = true,
            WallSouth = true,
            WallEast = true,
            ExitWest = 0,
            ExitSouth = 2,
            Seed = 400,
        };

        public static RoomDescriptor SwordDragonChamber = new RoomDescriptor
        {
            WallNorth = true,
            WallSouth = true,
            WallEast = true,
            WallWest = true,
            ExitNorth = 1,
            Seed = 256
        };

        public static RoomDescriptor YellowCastle = new RoomDescriptor
        {
            ExitNorth = 0,
            ExitSouth = 0,
            WallSouth = true,
            Visuals = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 59, 0, 0, 59, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 58, 41, 41, 41, 41, 41, 41, 60, 0, 0, 0, 0, 37, 38, 38, 38, 58, 30, 41, 41, 41, 41, 30, 60, 38, 38, 38, 39, 37, 0, 0, 0, 58, 41, 41, 41, 41, 41, 41, 60, 0, 0, 0, 39, 37, 0, 0, 0, 58, 29, 41, 41, 41, 41, 29, 60, 0, 0, 0, 39, 37, 0, 0, 0, 58, 41, 41, 0, 0, 41, 41, 60, 0, 0, 0, 39, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 39, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 39, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 39, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            NorthExit = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 47, 48, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            },
            Collisions = new int[]
            {
                0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            }
        };

        public static Dictionary<int, RoomDescriptor> Map = new Dictionary<int, RoomDescriptor>
        {
            { 0, FirstRoom },
            { 1, EastOfFirstRoom },
            { 2, SwordDragonChamber },
            { 3, YellowCastle }
        };
    }
}
