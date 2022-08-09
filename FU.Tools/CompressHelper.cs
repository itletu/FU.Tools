using System.IO.Compression;
using System.Text;

namespace FU.Tools
{
    /// <summary>
    /// 字符串压缩类
    /// </summary>
    public struct CompressHelper
    {
 
        /// <summary>
        /// 压缩字符串
        /// </summary>
        public static string Compress(string value)
        {
            try
            {
                string data = "";
                byte[] byteArray = Encoding.Default.GetBytes(value);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (GZipStream sw = new GZipStream(ms, CompressionMode.Compress))
                    {
                        sw.Write(byteArray, 0, byteArray.Length);
                    }

                    data = Convert.ToBase64String(ms.ToArray());
                }
                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 解压缩字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Decompress(string value)
        {
            try
            {
                string data = "";
                byte[] bytes = Convert.FromBase64String(value);
                using (MemoryStream msReader = new MemoryStream())
                {
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                        {
                            byte[] buffer = new byte[1024];
                            int readLen = 0;
                            while ((readLen = zip.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                msReader.Write(buffer, 0, readLen);
                            }

                        }
                    }
                    data = Encoding.Default.GetString(msReader.ToArray());
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
 

    }
}