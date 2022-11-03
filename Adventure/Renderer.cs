using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure
{
    internal class Renderer
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteSheet _spriteSheet;
        private readonly Dictionary<string, InventoryItem> _inventory;
        private readonly List<Mob> _mobs;
        private int _roomId;
        private RoomDescriptor _description;
        private Player _player;

        public Renderer(SpriteBatch spriteBatch,
                        SpriteSheet spriteSheet, 
                        Dictionary<string, InventoryItem> inventory,
                        List<Mob> mobs)
        {
            _spriteBatch = spriteBatch;
            _spriteSheet = spriteSheet;
            _inventory = inventory;
            _mobs = mobs;
        }

        public void Draw()
        {
            DrawSand(_description.Seed);

            if (_description.WallNorth)
            {
                DrawWall(true, _description.ExitNorth >= 0);
            }            

            if (_description.WallWest)
            {
                DrawSideWall(true);
            }

            if (_description.WallEast)
            {
                DrawSideWall(false);
            }

            if (_description.WallSouth)
            {
                DrawWall(false, _description.ExitSouth >= 0);
            }

            if (!_description.RoomUnlocked)
                DrawVisuals(_description.NorthExit);

            _spriteSheet.Draw(_spriteBatch, _player.Position, _player.Shape);
            if (_player.CurrentItem != null)
            {
                _spriteSheet.Draw(_spriteBatch, _player.CurrentItem.Position, _player.CurrentItem.Shape);
            }

            var items = _inventory.Where(i => (!i.Value.IsEquipped && i.Value.CurrentRoom == _roomId))
                                  .Select(i => i.Value)
                                  .ToList();

            foreach (var item in items)
            {
                _spriteSheet.Draw(_spriteBatch, item.Position, item.Shape);
            }

            DrawVisuals(_description.Visuals);
            DrawMobs(_mobs);
        }

        private void DrawMobs(List<Mob> mobs)
        {
            foreach (var mob in mobs)
            {
                if (_description.RoomId == mob.Room || mob.Room == -1)
                {
                    var color = mob.IsDead ? Color.Red : Color.White;
                    _spriteSheet.Draw(_spriteBatch, mob.Position, mob.SpriteId, color);
                }
            }
        }

        private void DrawVisuals(int[] visuals)
        {
            if (visuals == null || visuals.Length == 0)
                return;

            for(int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int index = y * 16 + x;
                    int valueAtIndex = visuals[index] - 1;
                    if (valueAtIndex > -1)
                    {
                        _spriteSheet.Draw(_spriteBatch, new Vector2(x * 16f, y * 16f), valueAtIndex, _description.ColourTint);
                    }
                }
            }
        }

        public void SetDescription(int roomId, RoomDescriptor description)
        {
            _roomId = roomId;
            _description = description;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        private void DrawSideWall(bool isLeft)
        {
            float offset = isLeft ? 0 : 15 * 16;
            int wall = isLeft ? Sprites.WallLeft : Sprites.WallRight;
            Color color = Color.White;
            if (_description.BarrierEastWest)
            {
                wall = Sprites.Barrier;
                color = Color.Red;
            }

            for (int y = 1; y < 12; y++)
            {
                _spriteSheet.Draw(_spriteBatch, new Vector2(offset, y * 16), wall, color);
            }
        }

        private void DrawWall(bool isTop, bool hasExit)
        {
            var offset = isTop ? 0 : 11 * 16;
            _spriteSheet.Draw(_spriteBatch, new Vector2(0, offset), Sprites.WallLeft);
            for (int x = 1; x < 15; x++)
            {
                if (hasExit && x > 6 && x < 9)
                    continue;

                _spriteSheet.Draw(_spriteBatch, new Vector2(x * 16, offset), Sprites.Wall);
            }
            _spriteSheet.Draw(_spriteBatch, new Vector2(15 * 16, offset), Sprites.WallRight);

            if (hasExit)
            {
                _spriteSheet.Draw(_spriteBatch, new Vector2(7 * 16, offset), Sprites.OpeningLeft, Color.White, !isTop);
                _spriteSheet.Draw(_spriteBatch, new Vector2(8 * 16, offset), Sprites.OpeningRight, Color.White, !isTop);
            }
        }

        private void DrawSand(int seed)
        {
            Random random = new Random(seed);
            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    var pc = random.NextSingle();
                    int sand = Sprites.Sand;
                    if (pc < .1)
                    {
                        sand = pc < .02f ? Sprites.SandStones : Sprites.SandTextured;
                    }

                    _spriteSheet.Draw(_spriteBatch, new Vector2(x * 16f, y * 16f), sand);
                }
            }
        }
    }
}
