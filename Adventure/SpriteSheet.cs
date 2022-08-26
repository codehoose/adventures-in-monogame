using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure
{
    internal class SpriteSheet
    {
        private readonly Texture2D _texture;
        private readonly int _cellWidth;
        private readonly int _cellHeight;
        private readonly int _cols;
        private readonly int _rows;

        public SpriteSheet(Texture2D texture, int cellWidth, int cellHeight)
        {
            _texture = texture;
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            _cols = _texture.Width / _cellWidth;
            _rows = _texture.Height / _cellHeight;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, int cellId)
        {
            Draw(spriteBatch, pos, cellId, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, int cellId, Color color, bool flipVertical = false)
        {
            var x = _cellWidth * (cellId % _cols);
            var y = _cellHeight * (cellId / _cols);

            Rectangle src = new Rectangle(x, y, _cellWidth, _cellHeight);
            SpriteEffects effect = flipVertical ? SpriteEffects.FlipVertically : SpriteEffects.None;
            spriteBatch.Draw(_texture, pos, src, color, 0, Vector2.Zero, 1f, effect, 0);
        }
    }
}
