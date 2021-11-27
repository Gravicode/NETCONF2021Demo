using Xunit;
using TestingDemo;
namespace TestingDemo.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestTambah()
        {
            var fun = new MyFunctions();
            bool result = fun.Tambah(1, 2) == 3;

            Assert.True(result, "harusnya jawaban 3");
        }
    }
}