using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LMD_Tenis.GameFramewerk.BaseGame
{
	public class GFileIO : IFileIO
	{
		public const String PATH_DATA = @"Data\";

		public void SetDataXMLFile(string path, object obj)
		{
			String all_path = PATH_DATA + path;
			XmlSerializer serializer = new XmlSerializer(obj.GetType());

			if (!Directory.Exists(PATH_DATA))
				Directory.CreateDirectory(PATH_DATA);

			using (Stream stream = new FileStream(all_path, FileMode.Create))
			{
				serializer.Serialize(stream, obj);
			}
		}

		public object GetDataXMLFile(string path, Type type)
		{
			String all_path = PATH_DATA + path;
			XmlSerializer serializer = new XmlSerializer(type);
			Object obj_res = null;

			if (!Directory.Exists(PATH_DATA))
				Directory.CreateDirectory(PATH_DATA);

			using (Stream stream = new FileStream(all_path, FileMode.Open))
			{
				obj_res = serializer.Deserialize(stream);
			}

			return obj_res;
		}
	}
}