using System.Drawing;
using System.Security.Cryptography;
using Box2DX.Common;
using LMD_Tenis.GameFramewerk;
using LMD_Tenis.GameFramewerk.BaseGame;
using LMD_Tenis.GameFramewerk.BaseGame.Physics;
using LMD_Tenis.GameFramewerk.UI;
using LMD_Tenis.GameFramewerk.Windows;

namespace LMD_Tenis.GameEngine.Windows
{
	public class ScreenGame : Screen
	{
		private float dt;
		private InfoBody myBody;
		private InfoBody ballBody;
		private GSystemParticles.ParticleParameters[] partParams;
		private GTopPanel topPanel;
		private LogicFoe LFoe;
		private GImage image_line;
		private bool IsPause;

		public ScreenGame(IGame game) : base(game)
		{
			IsPause = false;
		}

		public override void Step(float dt)
		{
			this.dt = dt;

			if (!IsPause)
			{
				image_line.Step(dt);

				Game.GetPhysics().Step(dt, 20);
				Game.GetSystemParticles().Add(ballBody.body.GetPosition().X*30f, ballBody.body.GetPosition().Y*30f, partParams);

				if (myBody.body.GetPosition().Y*30f <= Game.GetWindowHeight()/2+50)
					myBody.body.SetXForm(new Vec2(myBody.body.GetPosition().X, (Game.GetWindowHeight()/2 + 51)/30f),
						myBody.body.GetAngle());

				if (ballBody.body.GetPosition().Y * 30f <= 0)
				{
					topPanel.IncrementPlay1();
					ReplayGame();
				}
				if (ballBody.body.GetPosition().Y * 30f >= Game.GetWindowHeight())
				{
					topPanel.IncrementPlay2();
					ReplayGame();
				}

				LFoe.Step(dt);
			}
		}

		public void ReplayGame()
		{
			Game.GetPhysics().Dispose();

			InfoBody foeBody = Game.GetPhysics().AddCircle(Game.GetWindowWidth() / 2, 100, 50, 0, 1f, 1f, 1f, GameResource.circle_3, "I");
			myBody = Game.GetPhysics().AddCircle(Game.GetWindowWidth() / 2, Game.GetWindowHeight() - 100, 50, 0, 1f, 1f, 1f, GameResource.circle_1, "FOE");
			ballBody = Game.GetPhysics().AddCircle(Game.GetWindowWidth() / 2, Game.GetWindowHeight() / 2 + 40, 30, 0, 1f, 1f, 1f, GameResource.circle_2, "BALL");
			LFoe = new LogicFoe(Game, foeBody, ballBody);

			// Create borders
			Game.GetPhysics().AddRect(0, Game.GetWindowHeight() / 2, 20, Game.GetWindowHeight(), 0, 0f, 0f, 0f, GameResource.rect_3, "BORDER");
			Game.GetPhysics().AddRect(Game.GetWindowWidth() - 15, Game.GetWindowHeight() / 2, 20, Game.GetWindowHeight(), 0, 0f, 0f, 0f, GameResource.rect_3, "BORDER");

			Game.GetSystemParticles().Dispose();
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().Clear(System.Drawing.Color.FromArgb(50, 50, 50));

			image_line.Draw();
			Game.GetPhysics().Draw();
			Game.GetSystemParticles().DrawAndStep(dt);

			DrawElements(dt);
		}

		public override void Resume()
		{
			// Initialize particle parameters
			partParams = new GSystemParticles.ParticleParameters[1];
			partParams[0] = new GSystemParticles.ParticleParameters()
			{
				Type = GSystemParticles.TypeParticle.Circle,
				Color = Color.DarkTurquoise,
				TTL = 100,
				radius = 10
			};

			// Initialize Physics
			Game.GetPhysics().Initialize(-1000, -1000, 1000, 1000, 0, 0, false);
			Game.GetPhysics().GetSolver().onAdd += ScreenGame_onAdd;

			// Create circles
			InfoBody foeBody = Game.GetPhysics().AddCircle(Game.GetWindowWidth() / 2, 100, 50, 0, 1f, 1f, 1f, GameResource.circle_3, "I");
			myBody = Game.GetPhysics().AddCircle(Game.GetWindowWidth() / 2, Game.GetWindowHeight() - 100, 50, 0, 1f, 1f, 1f, GameResource.circle_1, "FOE");
			ballBody = Game.GetPhysics().AddCircle(Game.GetWindowWidth() / 2, Game.GetWindowHeight() / 2 + 40, 30, 0, 1f, 1f, 1f, GameResource.circle_2, "BALL");
			LFoe = new LogicFoe(Game, foeBody, ballBody);

			// Create borders
			Game.GetPhysics().AddRect(0, Game.GetWindowHeight() / 2, 20, Game.GetWindowHeight(), 0, 0f, 0f, 0f, GameResource.rect_3, "BORDER");
			Game.GetPhysics().AddRect(Game.GetWindowWidth() - 15, Game.GetWindowHeight() / 2, 20, Game.GetWindowHeight(), 0, 0f, 0f, 0f, GameResource.rect_3, "BORDER");

			// Decor
			image_line = new GImage(Game);
			image_line.SetImage(GameResource.rect_1);
			image_line.SetX(Game.GetWindowWidth() / 2);
			image_line.SetY(Game.GetWindowHeight() / 2);
			image_line.SetWidth(Game.GetWindowWidth());
			image_line.SetHeight(10);

			// Create intent to menu
			Intent intent_to_menu = new Intent(Game);
			intent_to_menu.SetScreenLoading(null);

			// Create top panel
			topPanel = new GTopPanel(Game);
			topPanel.ClearBalls();
			topPanel.onCommand += (cmd) =>
			{
				switch (cmd)
				{
					case GTopPanel.CommandTopPanel.menu:
						intent_to_menu.screenFrom = this;
						intent_to_menu.screenTo = new ScreenMenu(Game);
						intent_to_menu.Start();
						break;
					case GTopPanel.CommandTopPanel.play:
						IsPause = false;
						break;
					case GTopPanel.CommandTopPanel.pause:
						IsPause = true;
						break;
				}
			};
			AddElement(topPanel);
		}

		private void ScreenGame_onAdd(GameFramewerk.BaseGame.Physics.InfoBody body1, GameFramewerk.BaseGame.Physics.InfoBody body2)
		{
			// Contact
		}

		public override void Pause()
		{
		}

		public override void Dispose()
		{
			RemoveElements();
			Game.GetPhysics().Dispose();
			Game.GetSystemParticles().Dispose();
		}

		public override void TouchDown(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Down);
			topPanel.SetTouch(eventArgs.X, eventArgs.Y);
		}

		public override void TouchMove(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Move);

			myBody.body.SetLinearVelocity((new Vec2(eventArgs.X / 30f, eventArgs.Y / 30f) - 
				myBody.body.GetPosition()) * 5);
		}

		public override void TouchUp(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Up);
		}
	}
}