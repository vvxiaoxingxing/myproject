using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace NetCore.Infrastructure.Utils
{
    public class ImageUtil
    {
        public static decimal GetBase64ImageSize(string base64)
        {
            var tag = "data:image/png;base64,";
            var baseFile_data = base64.Replace(tag, null); //1.去掉base64编码中的前缀 data:image/png;base64,     
            baseFile_data = baseFile_data.Replace("=", null);  //2.去掉base64编码中的“=”号
            var strLen = baseFile_data.Length;
            var baseFileLength = strLen - Math.Ceiling((decimal)strLen / 8) * 2;//3.计算文件流大小
            return baseFileLength;
        }

        public static string GetBase64ImageExt(string base64)
        {
            var image = Base64ToImage(base64);
            var ext=GetImageExt(image);
            return ext;
        }

        #region 字节数组转换成图片
        /// <summary>
        /// base64转换成图片
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image Base64ToImage(string base64)
        {
            base64 = base64.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
                .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
            byte[] bytes = Convert.FromBase64String(base64);
            Image img;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Position = 0;
                img = Image.FromStream(ms);
                ms.Close();
            }
            return img;
        }
        #endregion

        #region 获取图片后缀
        /// <summary>
        /// 获取图片后缀
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string GetImageExt(Image image)
        {
            string imageExt = "";
            var RawFormatGuid = image.RawFormat.Guid;
            if (ImageFormat.Png.Guid == RawFormatGuid)
            {
                return "png";
            }
            if (ImageFormat.Jpeg.Guid == RawFormatGuid)
            {
                return "jpg";
            }
            if (ImageFormat.Bmp.Guid == RawFormatGuid)
            {
                return "bmp";
            }
            if (ImageFormat.Gif.Guid == RawFormatGuid)
            {
                return "gif";
            }
            if (ImageFormat.Icon.Guid == RawFormatGuid)
            {
                return "icon";
            }
            return imageExt;
        }
        #endregion
    }
}
