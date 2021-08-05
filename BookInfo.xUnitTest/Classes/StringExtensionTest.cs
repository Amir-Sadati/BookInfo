using BookInfo.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookInfo.xUnitTest.Classes
{
    public class StringExtensionTest
    {
        [Fact]
        public void CombineWithTest()
        {
            Assert.Equal("amir-reza-sara", StringExtension.CombineWith
                (new string[] { "amir","reza","sara" }, '-'));
        }

        [Theory]
        [InlineData(new string[] { "David","Bob","Leo" },'-')]
        public void CombineWithTest2(string[] array ,char character)
        {
              Assert.Equal("David-Bob-Leo", StringExtension.CombineWith
                (array,character));
        }

        [Theory]
        [MemberData(nameof(TestWeek))]
        public void GetNumOfWeek(string DayOfWeek,int index)
        {
            Assert.Equal(index, StringExtension.GetNumOfWeek(DayOfWeek));
        }
       public static IEnumerable<object[]> TestWeek()
        {
            yield return new object[] { "یکشنبه", 1 };
            yield return new object[] { "چهار شنبه", 4 };

        }
       


    }
}
