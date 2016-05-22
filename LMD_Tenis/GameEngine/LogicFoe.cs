using System.Runtime.CompilerServices;
using Box2DX.Common;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.BaseGame.Physics;

namespace LMD_Tenis.GameEngine
{
	public class LogicFoe
	{
		private IGame game;
		private InfoBody body;
		private InfoBody ball;
		private bool IsMove = false;

		public LogicFoe(IGame game, InfoBody body, InfoBody ball)
		{
			this.game = game;
			this.body = body;
			this.ball = ball;
		}

		public void Step(float dt)
		{
			if (body.body.GetPosition().Y*30f <= 20)
				body.body.SetXForm(new Vec2(body.body.GetPosition().X, 21 / 30f), 0);

			if (body.body.GetPosition().Y * 30f >= game.GetWindowHeight() / 2 - 50)
				body.body.SetXForm(new Vec2(body.body.GetPosition().X, (game.GetWindowHeight() / 2 -51) / 30f), 0);

			IsMove = ball.body.GetPosition().Y*30f <= game.GetWindowHeight()/2;

			if (IsMove)
			{
				body.body.SetLinearVelocity((ball.body.GetPosition()-body.body.GetPosition())*2);
			}
			else
			{
				body.body.SetLinearVelocity(new Vec2(game.GetWindowWidth() / 2 / 30f, 40 / 30f) - body.body.GetPosition());
			}
		}
	}
}