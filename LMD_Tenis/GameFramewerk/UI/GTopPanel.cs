using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using LMD_Tenis.GameFramewerk.UI.Animations;

namespace LMD_Tenis.GameFramewerk.UI
{
	public class GTopPanel : BaseUI
	{
		public enum CommandTopPanel
		{
			pause,
			play,
			menu
		}

		public delegate void EventCommandTopPanel(CommandTopPanel cmd);

		public event EventCommandTopPanel onCommand;

		private List<GBaseButton> buttons;
		private GImage BackgroundImage;
		private int play_1 = 0, play_2 = 0;
		private StringFormat stringFormat;
		private String s_max = ">", s_min = "<", s_r = " = ";
		private Font font;
		private SolidBrush solidBrush;

		public GTopPanel(IGame game) : base(game)
		{
			buttons = new List<GBaseButton>();

			BackgroundImage = new GImage(game);
			BackgroundImage.SetX(game.GetWindowWidth() / 2);
			BackgroundImage.SetY(15);
			BackgroundImage.SetHeight(30);
			BackgroundImage.SetWidth(game.GetWindowWidth());
			BackgroundImage.SetImage(GameResource.rect_2);

			CreateButton(30, 15, 15, GameResource.button_menu).onClick+= (e) =>
			{
				onCommand?.Invoke(CommandTopPanel.menu);
			};
			CreateButton(game.GetWindowWidth() - 45, 15, 15, GameResource.button_pause).onClick += (e) =>
			{
				buttons[1].SetVisible(false);
				buttons[2].SetVisible(true);

				onCommand?.Invoke(CommandTopPanel.pause);
			};
			CreateButton(game.GetWindowWidth() - 45, 15, 15, GameResource.button_play).onClick += (e) =>
			{
				buttons[1].SetVisible(true);
				buttons[2].SetVisible(false);

				onCommand?.Invoke(CommandTopPanel.play);
			};
			buttons[buttons.Count - 1].SetVisible(false);

			stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			font = new Font("Calibri", 13f, FontStyle.Bold);
			solidBrush = new SolidBrush(Color.White);
		}

		public override void Step(float dt)
		{
			BackgroundImage.Step(dt);

			for (int i = 0; i < buttons.Count; i++)
				buttons[i].Step(dt);
		}

		public override void Draw()
		{
			if (play_1 > play_2)
				game.GetGraphics().GetGraphics().DrawString(play_1 + s_max + play_2, font,
					solidBrush, 10, 10, stringFormat);
			else if (play_1 < play_2)
				game.GetGraphics().GetGraphics().DrawString(play_1 + s_min + play_2, font,
					solidBrush, 10, 10, stringFormat);
			else if (play_1 == play_2)
				game.GetGraphics().GetGraphics().DrawString(play_1 + s_r + play_2, font,
					solidBrush, 10, 10, stringFormat);
			
			BackgroundImage.Draw();

			for (int i = 0; i < buttons.Count; i++)
				buttons[i].Draw();
		}

		public override void Dispose()
		{
			for (int i = 0; i < buttons.Count; i++)
				buttons[i].Dispose();
			buttons.Clear();
		}

		private CircleButton CreateButton(float x, float y, float radius, Bitmap img)
		{
			CircleButton button = new CircleButton(game);
			button.SetWidth(radius * 2);
			button.SetHeight(radius * 2);
			button.SetBitmap(img);
			button.SetX(x);
			button.SetY(y);

			AnimationScale animation = new AnimationScale();
			animation.Initialize(button.GetWidth(), button.GetHeight(),
				button.GetWidth() - 10, button.GetHeight() - 10, 1, 1, button);
			button.SetAnimation(animation);

			buttons.Add(button);

			return button;
		}

		public void ClearBalls()
		{
			play_1 = 0;
			play_2 = 0;
		}

		public void IncrementPlay1()
		{
			play_1++;
		}

		public void IncrementPlay2()
		{
			play_2++;
		}

		public void SetTouch(float x, float y)
		{
			for (int i = 0; i < buttons.Count; i++)
				buttons[i].SetTouch(x, y, TypeTouch.Down);
		}

		public override void SetX(float value)
		{
			x = value;
		}

		public override void SetY(float value)
		{
			y = value;
		}

		public override float GetX()
		{
			return x;
		}

		public override float GetY()
		{
			return y;
		}

		public override void SetVelocityX(float value)
		{
			velocity_x = value;
		}

		public override void SetVelocityY(float value)
		{
			velocity_y = value;
		}

		public override float GetVelocityX()
		{
			return velocity_x;
		}

		public override float GetVelocityY()
		{
			return velocity_y;
		}

		public override void SetAndle(float value)
		{
			angle = value;
		}

		public override float GetAngle()
		{
			return angle;
		}

		public override void SetAngularVelocity(float value)
		{
			angularVelocity = value;
		}

		public override float GetAngularVelocity()
		{
			return angularVelocity;
		}

		public override void SetEnableCamera(bool value)
		{
			IsCamera = value;
		}

		public override float GetScaleX()
		{
			return scaleX;
		}

		public override float GetScaleY()
		{
			return scaleY;
		}

		public override void SetScaleX(float value)
		{
			scaleX = value;
		}

		public override void SetScaleY(float value)
		{
			scaleY = value;
		}
	}
}