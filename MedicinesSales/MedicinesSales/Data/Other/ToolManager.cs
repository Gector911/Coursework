using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;

namespace MedicinesSales.Data.Other
{
   static class ToolManager
    {
        public static BitmapImage byteArrayToImage(byte[] bytesArr)
        {
            MemoryStream memstr = new MemoryStream(bytesArr);
            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = memstr;
            imageSource.EndInit();

            return imageSource;
        }
        public static BitmapImage GetBitmapImage(string str)
        {
            var bitmap = new BitmapImage();
            var path = Directory.GetCurrentDirectory() + str;
            using (var stream = new FileStream(str, FileMode.Open, FileAccess.Read))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                bitmap.Freeze();
            }
            return bitmap;
        }
    }
}
