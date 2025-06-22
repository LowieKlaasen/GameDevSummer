using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    internal interface IGameObject
    {
        void update(GameTime gameTime);
        void draw(SpriteBatch spriteBatch);
    }
}
