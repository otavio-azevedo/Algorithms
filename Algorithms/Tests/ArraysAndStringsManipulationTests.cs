using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ArraysAndStringsManipulationTests
    {
        [Fact]
        public void URLifyTest()
        {
            string str = "Mr John Smith    ";
            int realLength = 13;

            var result = ArraysAndStringsManipulation.URLify(str.ToCharArray(), realLength);

            Assert.Equal("Mr%20John%20Smith", result);
        }
    }
}
