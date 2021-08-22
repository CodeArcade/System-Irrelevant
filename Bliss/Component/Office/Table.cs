using Bliss.Component.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Component.Office
{
    public class Table: Sprite
    {
        public Table()
        {
            Texture = ContentManager.TableTexture;
        }
    }
}
