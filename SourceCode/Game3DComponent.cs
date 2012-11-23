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
        public static bool operator <(Game3DComponent a, Game3DComponent b)
        {
            if (a.position_.Z < b.position_.Z)
            {
                return true;
            }
            return false;
        }
        public static bool operator >(Game3DComponent a, Game3DComponent b)
        {
            return b > a;
        }

        public static int CompareGame3DComponentsByZ(Game3DComponent a, Game3DComponent b)
        {
            return (int)(a.position_.Z - b.position_.Z);
        }

        public Vector3 position_ { get; protected set; }
        Matrix world_;
        string textureName_;
        Texture2D texture_;

        public Game3DComponent(Game game, Vector3 position, string textureName)
            : base(game)
        {
            position_ = position;
            textureName_ = textureName;
        }

        public void ForceLoad()
        {
            LoadContent();
        }
        protected override void LoadContent()
        {
            texture_ = ResourceManager<Texture2D>.Find(textureName_);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            world_ = Matrix.CreateScale(new Vector3(texture_.Width,texture_.Height,1)/10) * Matrix.CreateTranslation(position_);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            BasicEffect effect = ((EffectManager)Game.Services.GetService(typeof(EffectManager))).effect;

            effect.World = world_;

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