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
    public enum CameraMode
    {
        PROJECTIVE,
        ORTHOGONAL,
    }
    public class Camera : GameComponent
    {
        public CameraMode Mode;
        Matrix world_;
        Matrix view_;
        Matrix projection_;

        public Matrix View { get { return view_; } }
        public Matrix Projection { get { return projection_; } }

        public Camera(Game game, Matrix world)
            : base(game)
        {
            world_ = world;
            Mode = CameraMode.PROJECTIVE;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                Mode = (CameraMode)((int)(Mode + 1) % 2);
            }
            view_ = Matrix.CreateLookAt(world_.Translation, world_.Forward + world_.Translation, world_.Up);
            switch (Mode)
            {
                case CameraMode.PROJECTIVE:
                    projection_ = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100);
                    break;
                case CameraMode.ORTHOGONAL:
                    projection_ = Matrix.CreateOrthographic(Game.GraphicsDevice.Viewport.Width/20, Game.GraphicsDevice.Viewport.Height/20, 0.1f, 100);
                    break;
            }
            base.Update(gameTime);
        }
    }
}