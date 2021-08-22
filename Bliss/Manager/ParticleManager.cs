using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Unity;
using System;
using System.Collections.Generic;
using Bliss.Component;
using Size = System.Drawing.Size;

namespace Bliss.Manager
{
  public class ParticleManager
  {
    private readonly Random Random;

    private readonly static List<Particle> Particles = new List<Particle>();

    public ParticleManager()
    {
      Random = new Random();
    }

    public void GenerateNewParticle(Color color, Vector2 emitterLocation, List<Texture2D> textures, int count = 1, int baseTtl = 20, Size? maxSize = null, Vector2? velocity = null, float angularVelocity = float.NaN)
    {
      if (count <= 0) return;

      for (int i = 0; i < count; i++)
      {
        Texture2D texture = textures[Random.Next(textures.Count)];

        if (velocity is null)
        {
          velocity = new Vector2(
            1f * (float)((Random.NextDouble() * 2 - 1) - 1),
            1f * (float)((Random.NextDouble() * 2 - 1) - 1)
          );
        }

        float angle = 0;
        if (float.IsNaN(angularVelocity))
        {
          angularVelocity = 0.1f * (float)((Random.NextDouble() * 2 - 1) - 1);
        }

        float size = (float)Random.NextDouble();
        int ttl = baseTtl + Random.Next(baseTtl * 2);

        Particle p = new Particle((Vector2)velocity, emitterLocation, angle, angularVelocity, size, ttl, color, texture);
        if (!(maxSize is null))
        {
          p.MaxSize = (Size)maxSize;
        }

        Particles.Add(p);
      }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) => Particles.ForEach(p => p.Draw(gameTime, spriteBatch));

    public void Update(GameTime gameTime)
    {
      for (int i = 0; i < Particles.Count; i++)
      {
        Particles[i].Update(gameTime);
        if (Particles[i].TTL <= 0)
        {
          Particles.RemoveAt(i);
        }
      }
    }
  }
}
