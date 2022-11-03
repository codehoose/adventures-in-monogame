using Microsoft.Xna.Framework;

namespace Adventure
{
    internal class Mob
    {
        public int SpriteId { get; set; }

        /// <summary>
        /// -1 means it's moving and any number >= 0 means it's static
        /// </summary>
        public int Room { get; set; }

        public bool IsDead { get; set; }

        public Vector2 Position { get; set; }

        public int Health { get; set; } = 100;

        public Mob(int spriteId, int roomId, Vector2 position)
        {
            SpriteId = spriteId;
            Room = roomId;
            Position = position;
        }
    }
}
