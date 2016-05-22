using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;
using Box2DX.Common;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.UI;
using LMD_Tenis.GameFramewerk.UI.Animations;
using LMD_Tenis.GameFramewerk.Windows;
using Screen = LMD_Tenis.GameFramewerk.Screen;

namespace LMD_Tenis.GameEngine.Windows
{
	public class ScreenMenu : Screen
	{
		private Intent intent_to_menu;
		private float dt;

		public ScreenMenu(IGame game) : base(game)
		{
			//	Game.GetPhysics().Initialize(-1000, -1000, 1000, 1000, 0, 1, true);
			//	Game.GetPhysics().AddRect(200, 500, 150, 100, 0, 0f, 0f, 0f, GameResource.rect_3);
			//	Game.GetPhysics().AddRect(200, 300, 250, 100, 0, 0.5f, 0.5f, 0.5f, GameResource.rect_3);
			//	Game.GetPhysics().AddCircle(250, 100, 40, 0, 0.5f, 0.5f, 0.5f, GameResource.dot_f_5);
			//	Game.GetPhysics().AddVert(200, 100, new Vec2[] { new Vec2(-50, -50), new Vec2(50, 0), new Vec2(50, 50), new Vec2(-50, 50) }, 0, 0.5f, 0.5f, 0.5f, GameResource.rect_3);
		}

		private void StartGame()
		{
			intent_to_menu.screenFrom = this;
			intent_to_menu.screenTo = new ScreenGame(Game);
			intent_to_menu.Start();
		}

		private CircleButton CreateButton(float x, float y, float radius, Bitmap img)
		{
			CircleButton button = new CircleButton(Game);
			button.SetWidth(radius * 2);
			button.SetHeight(radius * 2);
			button.SetBitmap(img);
			button.SetX(x);
			button.SetY(y);
			AddElement(button);

			AnimationScale animation = new AnimationScale();
			animation.Initialize(button.GetWidth(), button.GetHeight(),
				button.GetWidth() + 20, button.GetHeight() + 20, 2, 2, button);
			button.SetAnimation(animation);

			return button;
		}
		private GImage CreateImage(float x, float y, float width, float height, Bitmap b_img)
		{
			GImage img = new GImage(Game);
			img.SetWidth(width);
			img.SetHeight(height);
			img.SetImage(b_img);
			img.SetX(x);
			img.SetY(y);
			AddElement(img);

			return img;
		}

		public override void Step(float dt)
		{
			this.dt = dt;
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().Clear(Color.FromArgb(50, 50, 50));
			
			DrawElements(dt);
		}

		public override void Resume()
		{
			// Create images
			CreateImage(125, 170, 200, 150, GameResource.text_lmd);
			CreateImage(355, 200, 200, 150, GameResource.text_tenis);

			// Create buttons
			CreateButton(Game.GetWindowWidth() / 2, 400, 60, GameResource.button_play).onClick += (e) =>
			{
				// Play
				StartGame();
			};
			CreateButton(Game.GetWindowWidth() / 4, 400, 50, GameResource.button_exit).onClick += (e) =>
			{
				// Exit
				Application.Exit();
			};
			CreateButton(Game.GetWindowWidth() / 2 + Game.GetWindowWidth() / 4, 400, 50, GameResource.button_audio_on).onClick += (e) =>
			{
				// Audio on 4
				((CircleButton)GetElement(4)).SetVisible(false);
				((CircleButton)GetElement(5)).SetVisible(true);
			};
			CreateButton(Game.GetWindowWidth() / 2 + Game.GetWindowWidth() / 4, 400, 50, GameResource.button_audio_off).onClick += (e) =>
			{
				// Audio off 5
				((CircleButton)GetElement(4)).SetVisible(true);
				((CircleButton)GetElement(5)).SetVisible(false);
			};
			((CircleButton)GetListElements()[GetListElements().Count - 1]).SetVisible(false);

			intent_to_menu = new Intent(Game);
			intent_to_menu.SetScreenLoading(null);

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