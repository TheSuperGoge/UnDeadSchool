using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace UnDeadSchool
{
    public class EffectManager : GameComponent
    {
        public BasicEffect effect { get; protected set; }

        public EffectManager(Game game)
            : base(game)
        {
            effect = new BasicEffect(game.GraphicsDevice);
              RasterizerState Rstate = new RasterizerState();
            Rstate.ScissorTestEnable = true;
            Game.GraphicsDevice.RasterizerState = Rstate;
            
        }

        public override void Update(GameTime gameTime)
        {
            Camera cam = (Camera)Game.Services.GetService(typeof(Camera));
            effect.View = cam.View;
            effect.Projection = cam.Projection;
            Game.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            base.Update(gameTime);
        }
    }
}