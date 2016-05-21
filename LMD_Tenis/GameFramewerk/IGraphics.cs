using System.Drawing;

namespace LMD_Tenis.GameFramewerk
{
	public interface IGraphics
	{
		/// <summary>
		/// Устанавливет текущий графикс
		/// </summary>
		/// <param name="g">Графкис указатель которого будет взят</param>
		void SetGraphics(Graphics g);
		/// <summary>
		/// Возвращает на текущий указатель графикса
		/// </summary>
		/// <returns></returns>
		Graphics GetGraphics();
	}
}