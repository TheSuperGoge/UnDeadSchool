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
    public class Game3DComponent : DrawableGameComponent
    {
        Vector3 position_;
        Matrix world_;

        public Game3DComponent(Game game, Vector3 position)
            : base(game)
        {
            position_ = position;
        }

        public override void Update(GameTime gameTime)
        {
            world_ = Matrix.CreateBillboard(position_, position_ - Vector3.Forward, Vector3.Up, null);
            base.Update(gameTime);
        }
    }
}