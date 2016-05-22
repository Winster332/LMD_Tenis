using System;
using System.Drawing;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.UI;
using LMD_Tenis.GameFramewerk.Windows;
using Screen = LMD_Tenis.GameFramewerk.Screen;

namespace LMD_Tenis.GameEngine.Windows
{
	public class ScreenLoading : Screen
	{
		private GImage image;
		private float dt;
		private Intent intent;

		public ScreenLoading(IGame game) : base(game)
		{
			image = new GImage(game);
			image.SetWidth(100);
			image.SetHeight(100);
			image.SetX(200);
			image.SetY(100);
			image.SetImage(GameResource.text_lmd);

			AddElement(image);
		}

		public override void Step(float dt)
		{
			this.dt = dt;

			if (intent == null)
				this.intent = (Intent)GetUserDate();

			Console.WriteLine(""+intent.Min_Pause);
			if (intent.Min_Pause >= 0)
			{
				intent.Min_Pause -= 0.1f;
			}
			else
			{
				Game.SetScreen(intent.screenTo);
			}
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().Clear(Color.FromArgb(255, 50, 50, 50));
			
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
		}

		#region Touch
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
		#endregion
	}
}