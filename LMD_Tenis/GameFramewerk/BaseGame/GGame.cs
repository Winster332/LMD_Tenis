using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LMD_Tenis.GameFramewerk.BaseGame.Physics;
using LMD_Tenis.GameFramewerk.Windows;

namespace LMD_Tenis.GameFramewerk.BaseGame
{
	public class GGame : Form, IGame
	{
		#region variables
		private Windows.ManagementScreen MScreen;
		private IAudio audio;
		private IFileIO fileIO;
		private IGraphics graphics;
		private IInput input;
		private IPhysics physics;
		private ICamera camera;
		private ISystemParticles systemParticles;
		private float DeltaTime;
		private float PrevDeltaTime;
		#endregion

		/// <summary>
		/// Инициализирует класс GGame
		/// </summary>
		public GGame()
		{
			MScreen = new ManagementScreen(this);

			audio = new GAudio();
			fileIO = new GFileIO();
			graphics = new GGraphics();
			input = new GInput();
			physics = new GPhysics(this);
			camera = new GCamera();
			systemParticles = new GSystemParticles(this);

			MScreen.SetCurrentScreen(GetStartScreen());

			DoubleBuffered = true;
			Size = new Size(500, 700);
			Paint += GGame_Paint;
			MouseDown += GGame_MouseDown;
			MouseUp += GGame_MouseUp;
			MouseMove += GGame_MouseMove;

			DeltaTime = System.DateTime.Now.Millisecond;
			PrevDeltaTime = System.DateTime.Now.Millisecond;
		}

		/// <summary>
		/// Возвращает страртовый экран
		/// </summary>
		/// <returns></returns>
		public Screen GetStartScreen()
		{
			return new GameEngine.Windows.ScreenStart(this);
		}

		/// <summary>
		/// Возвращает активный экран
		/// </summary>
		/// <returns></returns>
		public Screen GetCurrentScreen()
		{
			return MScreen.GetCurrentScreen();
		}

		/// <summary>
		/// Устанавливает активный экран
		/// </summary>
		/// <param name="screen">Экран который будет установлен</param>
		public void SetScreen(Screen screen)
		{
			MScreen.SetCurrentScreen(screen);
		}

		/// <summary>
		/// Возвращает указатель на объект класса ввода
		/// </summary>
		/// <returns></returns>
		public IInput GetInput()
		{
			return input;
		}

		/// <summary>
		/// Возвращает указатель на объект класса графики
		/// </summary>
		/// <returns></returns>
		public IGraphics GetGraphics()
		{
			return graphics;
		}

		/// <summary>
		/// Возвращает указатель на объект класса отвечающий за I/O данных файловой системы
		/// </summary>
		/// <returns></returns>
		public IFileIO GetFileIO()
		{
			return fileIO;
		}

		/// <summary>
		/// Возвращает указатель на объект класса по обработки физический процессов
		/// </summary>
		/// <returns></returns>
		public IPhysics GetPhysics()
		{
			return physics;
		}

		/// <summary>
		/// Возвращает указатель на объект класса отвечающего за обработку звуковых эффектов
		/// </summary>
		/// <returns></returns>
		public IAudio GetAudio()
		{
			return audio;
		}

		public ICamera GetCamera()
		{
			return camera;
		}

		public ISystemParticles GetSystemParticles()
		{
			return systemParticles;
		}

		public float GetWindowWidth()
		{
			return this.Width;
		}

		public float GetWindowHeight()
		{
			return this.Height;
		}

		#region Update and rendering game
		private void GGame_Paint(object sender, PaintEventArgs e) // Обновляет текущий экран
		{
			System.Drawing.Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;

			GetGraphics().SetGraphics(g); // Устанавливет графикс в текущем такте

			DeltaTime = (float) (System.DateTime.Now.Millisecond / PrevDeltaTime); // Вычисляем дельту времени
			PrevDeltaTime = System.DateTime.Now.Millisecond;

			// Обновляем и перерисовываем активный экран
			MScreen.Step(DeltaTime);
			MScreen.Draw();

		//	Console.WriteLine("DT: " + DeltaTime);

			this.Invalidate();
		}
		#endregion
		#region Mouse to current screen
		private void GGame_MouseMove(object sender, MouseEventArgs e)
		{
			GetCurrentScreen().TouchMove(e);
		}

		private void GGame_MouseUp(object sender, MouseEventArgs e)
		{
			GetCurrentScreen().TouchUp(e);
		}

		private void GGame_MouseDown(object sender, MouseEventArgs e)
		{
			GetCurrentScreen().TouchDown(e);
		}
		#endregion
	}
}