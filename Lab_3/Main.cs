using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;
using System.Drawing;

namespace Lab_3
{
	class MainClass
	{
		static string path ="/home/ubuntu/Desktop/3.TPL/Map_DB";
		public static void Main (string[] args)
		{
            //Parallel.For(0, 20, (int i) =>
            //{
             //       Console.WriteLine(i);
//            }); 
//			Parallel.ForEach(Partitioner.Create(1, 200 + 1), range =>
//            {
//                for (int i = range.Item1; i < range.Item2; i++)
//                {
//                    Console.WriteLine("Range: " + range.Item1.ToString() + " -> " +
//                    range.Item2.ToString() + " : " + i.ToString());
//                }
//            });
			string[] imgs =  getImgs(path);
			Bitmap[] bitmaps = new Bitmap[10];
//			string [] filenames = new string[imgs.Length];
//			for (int i = 0; i < imgs.Length; i++) {
//				filenames[i] = Path.GetFileName(imgs[i]);
//			}
			
			int height=0;
			int width=0;
			for (int i = 0; i < bitmaps.Length; i++) {
				bitmaps[i] = new Bitmap(imgs[i]);
				width+=bitmaps[i].Width;
				//height+=bitmaps[i].Height;
			}
			
			Bitmap damas = new Bitmap(width,bitmaps[0].Height);
			int c_width=0;
			for (int i = 0; i < bitmaps.Length; i++) {
				
				for (int x = 0; x < bitmaps[i].Width; x++) {
					for (int y = 0; y < bitmaps[i].Height; y++) {
						Color pxl = bitmaps[i].GetPixel(x,y);
						damas.SetPixel(c_width+x,y,pxl);
					}
				}
				c_width+=bitmaps[i].Width;
			}
			damas.Save(path+"/damas.jpg");
		}
		
		private static string[] getImgs(string dir)
		{
			return Directory.GetFiles(dir);
		}
	}
}
