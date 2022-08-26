using Microsoft.Xna.Framework;

namespace Adventure
{
    internal static class Vector2Extensions
    {

        public static Rectangle ToRectangle(this Vector2 position, int spriteWidth = 16, int spriteHeight = 16)
        {
            return new Rectangle((int)position.X, (int)position.Y, spriteWidth, spriteHeight);
        }
    }
}
