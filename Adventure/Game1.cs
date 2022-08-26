using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteSheet _spriteSheet;
        private RenderTarget2D _nativeRenderTarget;
        private Renderer _renderer;
        private Player _player;
        private RoomDescriptor _currentRoom;
        private Dictionary<string, InventoryItem> _inventory;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _inventory = new Dictionary<string, InventoryItem>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var texture = Content.Load<Texture2D>("spritesheet");
            _spriteSheet = new SpriteSheet(texture, 16, 16);
            _nativeRenderTarget = new RenderTarget2D(GraphicsDevice, 256, 192);
            _inventory.Add("Sword", new InventoryItem
            {
                CurrentRoom = 2,
                Shape = Sprites.Sword,
                IsEquipped = false,
                Position = new Vector2(32, 88)
            });
            _renderer = new Renderer(_spriteBatch, _spriteSheet, _inventory);
            _currentRoom = GameMap.FirstRoom;
            _renderer.SetDescription(0, _currentRoom);
            _player = new Player { Position = new Vector2(120, 88), Shape = Sprites.Wizard };
            _renderer.SetPlayer(_player);
        }

        private void ChangeRoom(int roomId, RoomDescriptor newRoom)
        {
            _currentRoom = newRoom;
            _currentRoom.RoomId = roomId;
            _renderer.SetDescription(roomId, _currentRoom);
        }

        private Vector2 GetPlayerInput()
        {
            Vector2 offset = Vector2.Zero;
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                offset += new Vector2(-1, 0);
            }
            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                offset += new Vector2(1, 0);
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                offset += new Vector2(0, -1);
            }
            else if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                offset += new Vector2(0, 1);
            }

            if (keyboardState.GetPressedKeys().Contains(Keys.Space) && _player.CurrentItem != null)
            {
                _player.CurrentItem.IsEquipped = false;
                _player.CurrentItem.CurrentRoom = _currentRoom.RoomId;
                _player.CurrentItem.Position = _player.Position + new Vector2(16, 0);
                _player.CurrentItem = null;
            }

            return offset;
        }

        private Vector2 CheckScreenBound(Vector2 newPos)
        {
            if (newPos.Y < 16 && _currentRoom.WallNorth)
            {
                if (!(_currentRoom.ExitNorth > 0 && newPos.X > 7 * 16 && newPos.X < 9 * 16))
                    newPos.Y = 16;
            }
            else if (newPos.Y > 10 * 16 && _currentRoom.WallSouth)
            {
                if (!(_currentRoom.ExitSouth > 0 && newPos.X > 7 * 16 && newPos.X < 9 * 16))
                    newPos.Y = 10 * 16;
            }

            if (newPos.Y > 170 && _currentRoom.ExitSouth > 0)
            {
                ChangeRoom(_currentRoom.ExitSouth, GameMap.Map[_currentRoom.ExitSouth]);
                newPos.Y = 16;
            }
            else if (newPos.Y < 8 && _currentRoom.ExitNorth > 0)
            {
                ChangeRoom(_currentRoom.ExitNorth, GameMap.Map[_currentRoom.ExitNorth]);
                newPos.Y = 160;
            }

            if (newPos.X < 16 && _currentRoom.WallWest)
            {
                newPos.X = 16;
            }
            else if (newPos.X > 14 * 16 && _currentRoom.WallEast)
            {
                newPos.X = 14 * 16;
            }
            else if (newPos.X < 0 && _currentRoom.ExitWest >= 0)
            {
                ChangeRoom(_currentRoom.ExitWest, GameMap.Map[_currentRoom.ExitWest]);
                newPos.X = 15 * 16;
            }
            else if (newPos.X > 256 - 8 && _currentRoom.ExitEast >= 0)
            {
                ChangeRoom(_currentRoom.ExitEast, GameMap.Map[_currentRoom.ExitEast]);
                newPos.X = 1;
            }

            return newPos;
        }

        private void CheckObjectCollisions(Vector2 pos)
        {
            // Check current room objects
            var items = _inventory.Where(i => !i.Value.IsEquipped && i.Value.CurrentRoom == _currentRoom.RoomId)
                                  .Select(i => i.Value)
                                  .ToList();

            foreach (var item in items)
            {
                Rectangle playerRect = _player.Position.ToRectangle();
                Rectangle itemRect = item.Position.ToRectangle();

                if (playerRect.Intersects(itemRect))
                {
                    _player.CurrentItem = item;
                    _player.CurrentItem.IsEquipped = true;
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Vector2 newPos = _player.Position + GetPlayerInput();
            _player.Position = CheckScreenBound(newPos);
            CheckObjectCollisions(newPos);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _renderer.Draw();
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_nativeRenderTarget, new Rectangle(0, 0, 1024, 768), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}