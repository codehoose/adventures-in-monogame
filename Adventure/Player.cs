using Microsoft.Xna.Framework;

namespace Adventure
{
    internal class Player
    {
        public Vector2 Position { get; set; }

        public InventoryItem CurrentItem { get; set; }

        public int Shape { get; set; }
    }
}
