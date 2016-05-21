using Box2DX.Dynamics;

namespace LMD_Tenis.GameFramewerk.BaseGame.Physics
{
	public class Solver : ContactListener
	{
		private IGame game;

		public Solver(IGame game)
		{
			this.game = game;
		}

		public override void Add(ContactPoint point)
		{
			base.Add(point);
		}

		public override void Persist(ContactPoint point)
		{
			base.Persist(point);
		}

		public override void Result(ContactResult point)
		{
			base.Result(point);
		}

		public override void Remove(ContactPoint point)
		{
			base.Remove(point);
		}
	}
}