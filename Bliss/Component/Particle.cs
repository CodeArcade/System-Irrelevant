using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Size = System.Drawing.Size;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Component
{
    public class Particle : Component
    {

        public Vector2 Velocity { get; set; }
        public float Angle { get; set; }
        public float AngularVelocity { get; set; }
        public float Size { get; set; }
        public int TTL { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public Size MaxSize { get; set; }

        public Particle(Vector2 velocity, Vector2 position, float angle, float angularVelocity, float size, int tTl, Color color, Texture2D texture)
        {
            Velocity = velocity;
            Position = position;
            Angle = angle;
            AngularVelocity = angularVelocity;
            Size = size;
            TTL = tTl;
            Color = color;
            Texture = texture;
            MaxSize = new Size(Texture.Width, Texture.Height);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, MaxSize.Width, MaxSize.Height);
            Vector2 origin = new Vector2(MaxSize.Width / 2, MaxSize.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color, Angle, origin, Size, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            TTL--;
            Position = new Vector2(Position.X + Velocity.X + AngularVelocity, Position.Y + Velocity.Y + AngularVelocity);
        }
    }
}
