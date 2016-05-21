using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LMD_Tenis.GameFramewerk.UI;
using LMD_Tenis.GameFramewerk.Windows;

namespace LMD_Tenis.GameFramewerk
{
	public abstract class Screen
	{
		private List<BaseUI> elements;
		private Object Tag;
		protected IGame Game;

		protected Screen(IGame game)
		{
			Game = game;
			elements = new List<BaseUI>();
		}
		
		/// <summary>
		/// Обновляет логику экрана
		/// </summary>
		/// <param name="dt">Дельта времени</param>
		public abstract void Step(float dt);
		/// <summary>
		/// Перерисовывает экран
		/// </summary>
		public abstract void Draw();
		/// <summary>
		/// Загружает экран
		/// </summary>
		public abstract void Resume();
		/// <summary>
		/// Останавливает экран
		/// </summary>
		public abstract void Pause();
		/// <summary>
		/// Очищает экран
		/// </summary>
		public abstract void Dispose();
		/// <summary>
		/// Происходит при нажатии на экран
		/// </summary>
		/// <param name="eventArgs"></param>
		public abstract void TouchDown(MouseEventArgs eventArgs);
		/// <summary>
		/// Происходит при перемещении курсора по экрану
		/// </summary>
		/// <param name="eventArgs"></param>
		public abstract void TouchMove(MouseEventArgs eventArgs);
		/// <summary>
		/// Происходит когда кнопка мыши отпущена
		/// </summary>
		/// <param name="eventArgs"></param>
		public abstract void TouchUp(MouseEventArgs eventArgs);
		/// <summary>
		/// Добавляет новый UI элемент на экран
		/// </summary>
		/// <param name="elementUi">UI элемент</param>
		/// <returns></returns>
		public BaseUI AddElement(BaseUI elementUi)
		{
			elements.Add(elementUi);
			return elements[elements.Count - 1];
		}
		/// <summary>
		/// Удаляет UI элемент с экрана
		/// </summary>
		/// <param name="elementUi">UI элемент</param>
		public void RemoveElement(BaseUI elementUi)
		{
			elementUi.Dispose();
			elements.Remove(elementUi);
		}
		/// <summary>
		/// Удаляет UI элемент с экрана
		/// </summary>
		/// <param name="index">Индекс UI элемента</param>
		public void RemoveElement(int index)
		{
			elements[index].Dispose();
			elements.Remove(elements[index]);
		}
		/// <summary>
		/// Возвращает UI элемент
		/// </summary>
		/// <param name="index">Индекс UI элемента</param>
		/// <returns></returns>
		public BaseUI GetElement(int index)
		{
			return elements[index];
		}
		/// <summary>
		/// Возвращает коллекцию UI элементов
		/// </summary>
		/// <returns></returns>
		public List<BaseUI> GetListElements()
		{
			return elements;
		}
		/// <summary>
		/// Удаляет все UI элементы
		/// </summary>
		protected void RemoveElements()
		{
			foreach (var element in elements)
			{
				element.Dispose();
			}

			elements.Clear();
		}
		/// <summary>
		/// Прорисовывает все UI элементы
		/// </summary>
		/// <param name="dt"></param>
		protected void DrawElements(float dt)
		{
			for (int i = 0; i < elements.Count; i++)
			{
				BaseUI element = elements[i];

				element.Step(dt);
				element.Draw();
			}
		}
		/// <summary>
		/// Устанавливается на каждый UI элемент поддерживающий события
		/// для обратной реакции в класс Screen
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="type">Тип поведения</param>
		protected void TouchElements(float x, float y, TypeTouch type)
		{
			for (int i = 0; i < elements.Count; i++)
			{
				BaseUI element = elements[i];

				if (element.GetType() == typeof(RectButton) || element.GetType() == typeof(CircleButton))
				{
					((GBaseButton) element).SetTouch(x, y, type);
				}
			}
		}

		public void SetUserDate(Object value)
		{
			Tag = value;
		}

		public Object GetUserDate()
		{
			return Tag;
		}
	}
}