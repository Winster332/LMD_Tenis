using System.Drawing;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.BaseGame;
using LMD_Tenis.GameFramewerk.UI;
using LMD_Tenis.GameFramewerk.Windows;

namespace LMD_Tenis.GameEngine.Windows
{
	public class ScreenStart : Screen
	{
		private GImage imgLMD;
		private float dt;
		private Intent intent_to_menu;
		private float ScaleImg_x;
		private float ScaleImg_y;
		private float Time = 30;

		public ScreenStart(IGame game) : base(game)
		{
		
		}

		private void StartMenu()
		{
			intent_to_menu.screenFrom = this;
			intent_to_menu.screenTo = new ScreenMenu(Game);
			intent_to_menu.Start();
		}

		public override void Step(float dt)
		{
			this.dt = dt;

			if (ScaleImg_x < 250)
				ScaleImg_x+=2;
			if (ScaleImg_y < 200)
				ScaleImg_y+=2;
			else
			{
				Time -= 0.1f;
				if (Time <= 0)
					StartMenu();
			}

			imgLMD.SetWidth(ScaleImg_x);
			imgLMD.SetHeight(ScaleImg_y);
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().Clear(Color.FromArgb(50, 50, 50));
			
			DrawElements(dt);
		}

		public override void Resume()
		{
			imgLMD = new GImage(Game);
			imgLMD.SetImage(GameResource.text_lmd);
			imgLMD.SetWidth(50);
			imgLMD.SetHeight(1);
			imgLMD.SetX(Game.GetWindowWidth() / 2 + 90);
			imgLMD.SetY(200);
			ScaleImg_x = imgLMD.GetWidth();
			ScaleImg_y = imgLMD.GetHeight();
			AddElement(imgLMD);

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

		/*	Game.GetSystemParticles().Add(eventArgs.X, eventArgs.Y, new GSystemParticles.ParticleParameters[]
			{
				new GSystemParticles.ParticleParameters()
				{
					Alpha = 155,
					angle = 0,
					AngularVelocity = 0,
					Color = Color.MistyRose,
					width = 100,
					height = 100,
					Image = null,
					radius = 20,
					Size = 1,
					TTL = 100,
					Type = GSystemParticles.TypeParticle.Circle
				},
			});*/
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