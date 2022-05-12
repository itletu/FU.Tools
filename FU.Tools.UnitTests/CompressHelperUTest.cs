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
            // ʵ��size
            var size = Encoding.Default.GetByteCount(str);
            
            // ѹ��
            str = CompressHelper.Compress(str);
            // ѹ��size
            var size2 = Encoding.Default.GetByteCount(str);

            // ��ѹ��
            str = CompressHelper.Decompress(str);
            // ��ѹ��size
            var size3 = Encoding.Default.GetByteCount(str);

            Assert.AreEqual(size, size3);
            Assert.Less( size2, size3);

        }
    }
}