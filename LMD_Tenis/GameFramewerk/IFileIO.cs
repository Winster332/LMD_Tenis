using System;
using System.Collections.Generic;
using LMD_Tenis.GameFramewerk.BaseGame;

namespace LMD_Tenis.GameFramewerk
{
	public interface IFileIO
	{
		void ReadFile(String path);
		void WriteFile(String path);
		List<GFileIO.Item> GetSettingListItems();
	}
}