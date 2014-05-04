using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weasyl_thumb {
	class Program {
		static void Main(string[] args) {
			if (args.Length == 0) {
				Console.Error.WriteLine("No file specified. Press ENTER to exit.");
				Console.Read();
				return;
			}
			Bitmap from = new Bitmap(args[0]);
			float width, height, x, y;
			if (from.Width > from.Height) {
				width = 240;
				height = from.Height / (from.Width / 240.0f);
			} else {
				width = from.Width / (from.Height / 240.0f);
				height = 240;
			}
			Console.WriteLine(width + "x" + height);
			x = (240 - width) / 2;
			y = (240 - height) / 2;
			Bitmap to = new Bitmap(240, 240);
			Graphics g = Graphics.FromImage(to);
			g.DrawImage(from, x, y, width, height);
			to.Save(Path.GetDirectoryName(args[0])+"/thumb_"+Path.GetFileNameWithoutExtension(args[0])+".png");
		}
	}
}
