namespace Adventure
{
    internal class RoomDescriptor
    {
        public bool WallNorth;
        public bool WallSouth;
        public bool WallWest;
        public bool WallEast;

        public int ExitNorth = -1;
        public int ExitSouth = -1;
        public int ExitWest = -1;
        public int ExitEast = -1;

        public int Seed;
        public int RoomId;

        public bool RoomUnlocked;

        // These are going to be 16x12 arrays of integers that point to a value in the sprite sheet
        public int[] Visuals;
        public int[] Collisions;
        public int[] NorthExit; // For the castle rooms
    }
}
