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
    }
}
