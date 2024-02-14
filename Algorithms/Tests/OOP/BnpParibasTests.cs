using Algorithms.OOP;

namespace Tests.OOP
{
    public class BnpParibasTests
    {
        [Fact]
        public void ImportContent_CSV()
        {
            string content = "Ref;Date;Amount;Rate\r\nA001;2019-06-30;123.45;0.006\r\nA002;2019-07-01;456.78;0.003\r\nA003;2019-06-26;345.56;0.004";
            var result = BnpParibas.ImportContent(content);
            
            string expectedResult = "[{\"OriginalSourceId\":\"A001\",\"TransactionDate\":\"2019-06-30T00:00:00\",\"Value\":123.45,\"Rate\":0.006},{\"OriginalSourceId\":\"A002\",\"TransactionDate\":\"2019-07-01T00:00:00\",\"Value\":456.78,\"Rate\":0.003},{\"OriginalSourceId\":\"A003\",\"TransactionDate\":\"2019-06-26T00:00:00\",\"Value\":345.56,\"Rate\":0.004}]";
            
            Assert.Equal(expectedResult, result);
        }
    }
}
