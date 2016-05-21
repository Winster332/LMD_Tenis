using System.Drawing;
using Box2DX.Common;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.UI;

namespace LMD_Tenis.GameEngine.Windows
{
	public class ScreenMenu : Screen
	{
		private float dt;

		public ScreenMenu(IGame game) : base(game)
		{
			Game.GetPhysics().Initialize(-1000, -1000, 1000, 1000, 0, 1, true);
			Game.GetPhysics().AddRect(200, 500, 150, 100, 0, 0f, 0f, 0f, GameResource.rect_3);
			Game.GetPhysics().AddRect(200, 300, 250, 100, 0, 0.5f, 0.5f, 0.5f, GameResource.rect_3);
			//	Game.GetPhysics().AddCircle(250, 100, 40, 0, 0.5f, 0.5f, 0.5f, GameResource.dot_f_5);
			Game.GetPhysics().AddVert(200, 100, new Vec2[] { new Vec2(-50, -50), new Vec2(50, 0), new Vec2(50, 50), new Vec2(-50, 50) }, 0, 0.5f, 0.5f, 0.5f, GameResource.rect_3);
		}

		public override void Step(float dt)
		{
			this.dt = dt;

			Game.GetPhysics().Step(1f, 20);
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().Clear(Color.Brown);

			Game.GetPhysics().Draw();
			DrawElements(dt);
		}

		public override void Resume()
		{
		}

		public override void Pause()
		{
		}

		public override void Dispose()
		{
			RemoveElements();
			Game.GetPhysics().Dispose();
		}

		public override void TouchDown(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Down);
		}

		public override void TouchMove(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Move);
		}

		public override void TouchUp(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Up);
		}
	}
}