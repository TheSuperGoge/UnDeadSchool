using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace UnDeadSchool
{
    public class Actor : Game3DComponent
    {
        public Actor(Game game, Vector3 position, string textureName)
            : base(game, position, textureName) { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            KeyboardManager KManager = (KeyboardManager)Game.Services.GetService(typeof(KeyboardManager));
            int X = KManager.IsKeyDownShort(Keys.D) - KManager.IsKeyDownShort(Keys.A);
            int Z = KManager.IsKeyDownShort(Keys.S) - KManager.IsKeyDownShort(Keys.W);
            position_ += 0.1f * new Vector3(X, 0, Z);
            base.Update(gameTime);
        }
    }
}