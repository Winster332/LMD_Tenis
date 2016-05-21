using System;
using System.Drawing;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.UI;
using LMD_Tenis.GameFramewerk.UI.Animations;
using LMD_Tenis.GameFramewerk.Windows;

namespace LMD_Tenis.GameEngine.Windows
{
	public class ScreenStart : Screen
	{
		private CircleButton button;
		private float dt;
		private Intent intent_to_menu;

		public ScreenStart(IGame game) : base(game)
		{
			button = new CircleButton(game);
			button.SetX(100);
			button.SetY(100);
			button.SetWidth(100);
			button.SetHeight(100);
			button.SetBitmap(GameResource.bullet);

			AnimationScale animation = new AnimationScale();
			animation.Initialize(100f, 100f, 150f, 150f, 1f, 1f, button, true);
			

			button.SetAnimation(animation);
			button.onClick += Button_onClick;
			AddElement(button);

			intent_to_menu = new Intent(Game);
			intent_to_menu.SetScreenLoading(new ScreenLoading(Game));
			game.GetCamera().SetXY(100, 150);
		}

		private void Button_onClick(GBaseButton button)
		{
			intent_to_menu.screenFrom = this;
			intent_to_menu.screenTo = new ScreenMenu(Game);
			intent_to_menu.Start();
		}

		public override void Step(float dt)
		{
			this.dt = dt;
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().Clear(Color.Brown);
			
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