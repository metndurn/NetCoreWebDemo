using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System;

namespace NetCoreWebDemo.Utils
{
	/*resim işlemleri buradan yapılacaktır*/
	public class FileHelper
	{
		/*geriye deger donduren metod ile resimleri getirip gosterecegiz ayrıca tırnak ıcınde olan 
		 img ise herhangi birsey yok ise orayı yol olarak gorecek*/
		public static string FileLoader(IFormFile formFile, string filePath = "/Img/")
		{
			/*degisken atanıp deger verilmedi*/
			var fileName = "";

			/*formfile boş değilse ve formfile içinde bir deger yok ise demektir*/
			if (formFile != null && formFile.Length > 0)
			{
				fileName = formFile.FileName;//eşitse
				string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;//yukleme dızınıdır
				using(var stream = new FileStream(directory, FileMode.Create))
				{
					formFile.CopyTo(stream);
				}
			}
			return fileName;/*atanan degiskeni geri döndürür*/
		}
		/*yuklenen resimleri silen metodtur hatta direk klasor de silinebilinir*/
		public static bool FileTerminator(string fileName, string filePath = "/Img/")
		{
			string deletedFile=Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;//yukleme dızınıdır
			if (File.Exists(deletedFile))
			{
				File.Delete(deletedFile);
				return true;//dogru ise bunu alır
			}
			return false;//yanlış ise bunu alır
		}
	}
}
