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
    public class Game3DCollection : DrawableGameComponent
    {
        List<Game3DComponent> components;

        public Game3DCollection(Game game)
            : base(game)
        {
            components = new List<Game3DComponent>();
        }

        public void Add(Game3DComponent component)
        {
            components.Add(component);

        }
        public void Remove(Game3DComponent component)
        {
            components.Remove(component);
        }

        public override void Initialize()
        {
            foreach (Game3DComponent comp in components)
            {
                comp.Initialize();
            }
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Game3DComponent comp in components)
            {
                comp.Update(gameTime);
            }
            components.Sort(Game3DComponent.CompareGame3DComponentsByZ);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Game3DComponent comp in components)
            {
                comp.Draw(gameTime);
            }
            base.Draw(gameTime);
        }
    }
}