using System;
using System.Linq;
using Xunit;
using Accounting;

namespace Accounting.Tests
{
    public class AccountTests
    {
        public class FactTests
        {
            [Fact]
            public void TestDeposit_NoInitialBalance_Success()
            {
                var account = new Account();
                Assert.Equal(0.0, account.Balance);
                account.Deposit(10);
                Assert.Equal(10.0, account.Balance);
            }

            [Fact]
            public void TestDeposit_InitialBalance_Success()
            {
                var account = new Account(10);
                Assert.Equal(10.0, account.Balance);
                account.Deposit(10);
                Assert.Equal(20.0, account.Balance);
            }

            /*[Fact]
            public void TestDeposit_NegativeAmount_Failure()
            {
                var account = new Account(10);
                Assert.Equal(10.0, account.Balance);
                account.Deposit(-10);
                // Add missing part here if needed!

                Assert.Equal(10.0, account.Balance);
            }

            [Fact]
            public void TestWitdraw_NoInitialBalance_Failure()
            {

            }

            [Fact]
            public void TestWithdraw_InitialBalance_Success()
            {

            }*/
        }
        
        public class TheoryTests {

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
}
