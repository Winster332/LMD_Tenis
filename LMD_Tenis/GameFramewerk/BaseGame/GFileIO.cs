using System;
using System.Collections.Generic;
using System.IO;

namespace LMD_Tenis.GameFramewerk.BaseGame
{
	public class GFileIO : IFileIO
	{
		public List<Item> items;

		public GFileIO()
		{
			items = new List<Item>();
		}

		/// <summary>
		/// Загружает данные из настроек
		/// </summary>
		/// <param name="path"></param>
		public void ReadFile(string path)
		{
			String res = GameResource.Settings;
			bool read_name = false;
			bool read_value = false;

			for (int i = 0; i < res.Length; i++)
			{
				if (res[i] == '[')
				{
					items.Add(new Item());
					read_name = true;
					continue;
				}
				if (res[i] == ']')
				{
					read_name = false;
					continue;
				}
				if (res[i] == '{')
				{
					read_value = true;
					continue;
				}
				if (res[i] == '}')
				{
					read_value = false;
					continue;
				}

				if (read_name)
				{
					items[items.Count - 1].name += res[i];
				}
				if (read_value)
				{
					items[items.Count - 1].param += res[i];
				}
			}
		}

		public void WriteFile(string path)
		{
		}

		/// <summary>
		/// Возвращает данные из настроек
		/// </summary>
		/// <returns></returns>
		public List<Item> GetSettingListItems()
		{
			return items;
		}

		public class Item
		{
			public String name;
			public String param;
		}
	}
}