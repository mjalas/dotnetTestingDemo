using System;
using System.Linq;
using Xunit;

namespace Accounting.Tests
{
    public class AccountTests
    {
        
        [Fact]
        public void TestDeposit_NoInitialBalance_Success()
        {

        }

        [Fact]
        public void TestDeposit_InitialBalance_Success()
        {
            
        }

        [Fact]
        public void TestWitdraw_NoInitialBalance_Failure()
        {
            
        }

        [Fact]
        public void TestWithdraw_InitialBalance_Success()
        {
            
        }

        // The demo only has a couple of test cases per method, 
        // but in reality the goal should be to have one test case/scenario.
        // Because of this, the real benefit of data-driven testing can not
        // be seen in this demo. The demo only demonstrates the idea of
        // data-driven testing. 
        /*[Theory,
         InlineData(),
         InlineData()]
        public void TestWithdraw_DataDrivenStyle_InlineData()
        {
            
        }*/

        /*[Theory]
        [MemberData(nameof(GetTestData))]
        public void TestWithdraw_DataDrivenStyle_MemberData()
        {
            
        }


        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] {  };
            yield return new object[] {  };
        }
        */
    }
}
