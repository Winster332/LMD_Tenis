using LMD_Tenis.GameEngine.Windows;

namespace LMD_Tenis.GameFramewerk.Windows
{
	/// <summary>
	/// Класс перехода от одного экрана к другому
	/// </summary>
	public class Intent
	{
		public Screen screenFrom;
		public Screen screenTo;
		public float Min_Pause;
		private Screen screenLoading;
		private IGame game;

		public Intent(IGame game)
		{
			this.game = game;
			Min_Pause = 20;
		}

		public void SetScreenLoading(ScreenLoading screenLoading)
		{
			this.screenLoading = screenLoading;
		}

		public void Start()
		{
			screenLoading.SetUserDate(this);
			game.SetScreen(screenLoading);
		}

		public void Stop()
		{
		}
	}
}