using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Accounting;

namespace Accounting.Tests
{
    public class AccountTests
    {
        public class FactTests : IDisposable
        {
            private Account _account;


            public FactTests()
            {
                _account = new Account();
            }

            [Fact]
            public void TestDeposit_NoInitialBalance_Success()
            {
                
                Assert.Equal(0.0, _account.Balance);
                _account.Deposit(10);
                Assert.Equal(10.0, _account.Balance);
            }

            [Fact]
            public void TestDeposit_InitialBalance_Success()
            {
                var account = new Account(10);
                Assert.Equal(10.0, account.Balance);
                account.Deposit(10);
                Assert.Equal(20.0, account.Balance);
            }

            [Fact]
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
                var account = new Account();
                Assert.Throws<NotEnoughFunds>(() => account.Withdraw(10));
                Assert.Equal(0.0, account.Balance);
            }

            [Fact]
            public void TestWithdraw_InitialBalance_Success()
            {
                var account = new Account(10);
                account.Withdraw(10);
                Assert.Equal(0.0, account.Balance);
            }

            public void Dispose()
            {
                _account = null;
            }
        }
        
        public class TheoryTests {

            // The demo only has a couple of test cases per method, 
            // but in reality the goal should be to have one test case/scenario.
            // Because of this, the real benefit of data-driven testing can not
            // be seen in this demo. The demo only demonstrates the idea of
            // data-driven testing. 
            [Theory,
             InlineData(0.0, 10.0, 10.0),
             InlineData(10.0, 10.0, 20.0)]
            public void TestWithdraw_DataDrivenStyle_InlineData(double initialAmount, double depositAmount, double expectedAmount)
            {
                var account = new Account(initialAmount);
                Assert.Equal(initialAmount, account.Balance);
                account.Deposit(depositAmount);
                Assert.Equal(expectedAmount, account.Balance);
            }


            [Theory]
            [MemberData(nameof(GetTestData))]
            public void TestWithdraw_DataDrivenStyle_MemberData(double initialAmount, double depositAmount, double expectedAmount)
            {
                var account = new Account(initialAmount);
                Assert.Equal(initialAmount, account.Balance);
                account.Deposit(depositAmount);
                Assert.Equal(expectedAmount, account.Balance);
            }


            public static IEnumerable<object[]> GetTestData()
            {
                yield return new object[] { 0.0, 10.0, 10.0 };
                yield return new object[] { 10.0, 10.0, 20.0 };
            }
            
        }
    }
}
