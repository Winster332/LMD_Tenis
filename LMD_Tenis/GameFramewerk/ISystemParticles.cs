using LMD_Tenis.GameFramewerk.BaseGame;

namespace LMD_Tenis.GameFramewerk
{
	public interface ISystemParticles
	{
		void Add(float x, float y, GSystemParticles.ParticleParameters[] parameterses);
		void DrawAndStep(float dt);
		void Dispose();
	}
}