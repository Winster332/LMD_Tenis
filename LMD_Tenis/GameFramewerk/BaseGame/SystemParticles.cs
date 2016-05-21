using System.Collections.Generic;
using LMD_Tenis.GameFramewerk.UI;

namespace LMD_Tenis.GameFramewerk.BaseGame
{
	public class SystemParticles
	{
		private List<Particle> particles;
		private IGame game;

		public SystemParticles(IGame game)
		{
			this.game = game;
			particles = new List<Particle>();
		}

		public void UpDate(float dt)
		{
			foreach (var part in particles)
			{
				part.Step(dt);
				part.Draw();
			}
		}

		public void Add(float x, float y)
		{

		}

		public class Particle
		{
			public GImage image;

			public Particle()
			{

			}

			public void Step(float dt)
			{
				
			}

			public void Draw()
			{
			}
		}
	}
}