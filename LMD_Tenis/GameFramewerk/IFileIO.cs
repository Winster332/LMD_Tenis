using System;
using System.Collections.Generic;
using LMD_Tenis.GameFramewerk.BaseGame;

namespace LMD_Tenis.GameFramewerk
{
	public interface IFileIO
	{
		void SetDataXMLFile(String path, Object obj);
		Object GetDataXMLFile(String path, Type type);
	}
}