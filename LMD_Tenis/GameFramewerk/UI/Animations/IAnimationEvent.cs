namespace LMD_Tenis.GameFramewerk.UI.Animations
{
	public interface IAnimationEvent
	{
		/// <summary>
		/// Выполняется при старте анимации
		/// </summary>
		/// <param name="animation"></param>
		void OnStart(IAnimation animation);
		/// <summary>
		/// Выполнятеся при окончании функционирования анимации
		/// </summary>
		/// <param name="animation"></param>
		void OnStop(IAnimation animation);
	}
}