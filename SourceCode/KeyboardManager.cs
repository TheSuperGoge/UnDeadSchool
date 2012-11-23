using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace UnDeadSchool
{
    public class KeyboardManager : GameComponent
    {
        KeyboardState previousState,
                      currentState;
        public KeyboardManager(Game game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            previousState = currentState;
            currentState = Keyboard.GetState();

            base.Update(gameTime);
        }

        public bool IsKeyDown(Keys key)
        {
            return currentState.IsKeyDown(key);
        }
        public bool IsKeyPressed(Keys key)
        {
            return IsKeyDown(key) && previousState.IsKeyUp(key);
        }
        public bool IsKeyReleased(Keys key)
        {
            return !IsKeyDown(key) && previousState.IsKeyDown(key);
        }
    }
}