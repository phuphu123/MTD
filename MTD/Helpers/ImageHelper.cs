using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace MTD.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Lưu ảnh từ dạng base64 sang ảnh
        /// </summary>
        /// <param name="imageUrl">đường dẫn ảnh mới</param>
        /// <param name="base64ImageString">chuỗi base 64</param>
        /// <returns>true nếu lưu được, false nếu bị lỗi.</returns>
        public static bool SaveBase64ToImage(string path, string fileName, string base64ImageString)
        {
            try
            {
                base64ImageString = base64ImageString.Replace("data:image/png;base64,", "");

                byte[] imgArr = Convert.FromBase64String(base64ImageString);
                Image img;

                using (MemoryStream ms = new MemoryStream(imgArr))
                {
                    img = Image.FromStream(ms);
                }

                // Check URL.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                img.Save(path + fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}