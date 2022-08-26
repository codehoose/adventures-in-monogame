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

        public static Dictionary<int, RoomDescriptor> Map = new Dictionary<int, RoomDescriptor>
        {
            { 0, FirstRoom },
            { 1, EastOfFirstRoom },
            { 2, SwordDragonChamber },
        };
    }
}
