﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMD_Tenis.GameFramewerk.BaseGame;

namespace LMD_Tenis
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			GGame windowGame = new GGame();
			
			Application.Run(windowGame);
		}
	}
}
