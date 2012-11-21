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
        string textureName_;
        Texture2D texture_;

        public Game3DComponent(Game game, Vector3 position, string textureName)
            : base(game)
        {
            position_ = position;
            textureName_ = textureName;
        }

        protected override void LoadContent()
        {
            texture_ =  Game.Content.Load<Texture2D>(textureName_);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            position_ -= Vector3.Forward / 100;
            world_ = Matrix.CreateScale(new Vector3(texture_.Width,texture_.Height,1)/10) * Matrix.CreateTranslation(position_);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Camera cam = (Camera)Game.Services.GetService(typeof(Camera));

            BasicEffect effect = new BasicEffect(Game.GraphicsDevice);

            effect.World = world_;
            effect.View = cam.View;
            effect.Projection = cam.Projection;

            effect.TextureEnabled = true;
            effect.Texture = texture_;
            
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                Billboard.draw(Game.GraphicsDevice);
            }
            base.Draw(gameTime);
        }
    }
}