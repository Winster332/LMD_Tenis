namespace LMD_Tenis.GameFramewerk.UI
{
	public abstract class BaseUI
	{
		protected IGame game;
		protected float x;
		protected float y;
		protected float width;
		protected float height;
		protected float scaleX;
		protected float scaleY;
		protected float angle;
		protected float angularVelocity;
		protected float velocity_x;
		protected float velocity_y;

		protected BaseUI(IGame game)
		{
			this.game = game;
		}

		/// <summary>
		/// Устанавилвает элемент по координате X
		/// </summary>
		/// <param name="value">Значение в px</param>
		public abstract void SetX(float value);
		/// <summary>
		/// Устанавилвает элемент по координате Y
		/// </summary>
		/// <param name="value">Значение в px</param>
		public abstract void SetY(float value);
		/// <summary>
		/// Возвращает координату X
		/// </summary>
		/// <returns></returns>
		public abstract float GetX();
		/// <summary>
		/// Возвращает координату Y
		/// </summary>
		/// <returns></returns>
		public abstract float GetY();
		/// <summary>
		/// Устанавливает скорость по координате X
		/// </summary>
		/// <param name="value">Шаг перемещения за такт времени</param>
		public abstract void SetVelocityX(float value);
		/// <summary>
		/// Устанавливает скорость по координате Y
		/// </summary>
		/// <param name="value">Шаг перемещения за такт времени</param>
		public abstract void SetVelocityY(float value);
		/// <summary>
		/// Возвращает скорость перемещения по координате X
		/// </summary>
		/// <returns></returns>
		public abstract float GetVelocityX();
		/// <summary>
		/// Возвращает скорость перемещения по координате Y
		/// </summary>
		/// <returns></returns>
		public abstract float GetVelocityY();
		/// <summary>
		/// Устанавливает угол повората в радианах
		/// </summary>
		/// <param name="value">Значение угла поворота</param>
		public abstract void SetAndle(float value);
		/// <summary>
		/// Возвращает поворост в радианах
		/// </summary>
		/// <returns></returns>
		public abstract float GetAngle();
		/// <summary>
		/// Устанавливает угловую скорость в радианах
		/// </summary>
		/// <param name="value">Значение скорости</param>
		public abstract void SetAngularVelocity(float value);
		/// <summary>
		/// Возвращает угловую скорость
		/// </summary>
		/// <returns></returns>
		public abstract float GetAngularVelocity();
		/// <summary>
		/// Обновляет элемент
		/// </summary>
		/// <param name="dt">Дельта времени</param>
		public abstract void Step(float dt);
		/// <summary>
		/// Прорисовывает элемент
		/// </summary>
		public abstract void Draw();
		/// <summary>
		/// Очищает элемент из памяти
		/// </summary>
		public abstract void Dispose();

		public abstract float GetScaleX();
		public abstract float GetScaleY();
		public abstract void SetScaleX(float value);
		public abstract void SetScaleY(float value);
	}
}