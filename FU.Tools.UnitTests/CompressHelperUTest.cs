using NUnit.Framework;
using System.Text;

namespace FU.Tools.UnitTests
{
    public class CompressHelperUTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var str = "";
            for (int i = 683393; i < 684393; i++)
            {
                str += i + ",";
            }
            // Êµ¼Êsize
            var size = Encoding.Default.GetByteCount(str);
            
            // Ñ¹Ëõ
            str = CompressHelper.Compress(str);
            // Ñ¹Ëõsize
            var size2 = Encoding.Default.GetByteCount(str);

            // ½âÑ¹Ëõ
            str = CompressHelper.Decompress(str);
            // ½âÑ¹Ëõsize
            var size3 = Encoding.Default.GetByteCount(str);

            Assert.AreEqual(size, size3);
            Assert.Less( size2, size3);

        }
    }
}