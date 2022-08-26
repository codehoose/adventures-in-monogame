using Microsoft.Xna.Framework;

namespace Adventure
{
    internal class InventoryItem
    {
        public Vector2 Position;
        public bool IsEquipped;
        public int CurrentRoom = -1;
        public int Shape;
    }
}
