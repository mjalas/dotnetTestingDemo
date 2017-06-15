using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Accounting;

namespace Accounting.Tests
{
    public class AccountTests
    {

        [Fact]
        public void InitializeAccount_NoInitialBalace()
        {
            var account = new Account();
            Assert.Equal(0.0, account.Balance);
        }

        [Fact]
        public void InitialBalance_Success()
        {
            var account = new Account(10);
            Assert.Equal(10.0, account.Balance);
        }

        public class DepositTests : IDisposable
        {
            private Account _account;

            //Runs before each test case
            public DepositTests()
            {
                _account = new Account();
            }

            //Runs after each test case
            public void Dispose()
            {
                _account = null;
            }

            [Fact]
            public void SingleDeposit_Success()
            {                
                Assert.Equal(0.0, _account.Balance);
                _account.Deposit(10);
                Assert.Equal(10.0, _account.Balance);
            }

            [Fact]
            public void TwoDeposits_Success()
            {
                Assert.Equal(0.0, _account.Balance);
                _account.Deposit(10.0);
                Assert.Equal(10.0, _account.Balance);
                _account.Deposit(20);
                Assert.Equal(30.0, _account.Balance);
            }

            [Fact]
            public void NegativeAmount_Failure()
            {                
                Assert.Equal(0.0, _account.Balance);
                Assert.Throws<NegativeAmount>(() => _account.Deposit(-10));
                Assert.Equal(0.0, _account.Balance);
            }            
        }
        
        public class WithdrawTests :  IDisposable
        {
            private Account _account;

            public WithdrawTests()
            {
                _account = new Account(10);
            }

            public void Dispose()
            {
                _account = null;
            }

            [Fact]
            public void TooBigWithdrawal_Failure()
            {
                Assert.Equal(10.0, _account.Balance);
                Assert.Throws<NotEnoughFunds>(() => _account.Withdraw(11));
                Assert.Equal(10.0, _account.Balance);
            }

            [Fact]
            public void SingleWithdrawal_Success()
            {                
                _account.Withdraw(10);
                Assert.Equal(0.0, _account.Balance);
            }

            [Fact]
            public void TwoWithdrawals_Success()
            {
                _account.Withdraw(5);
                Assert.Equal(5.0, _account.Balance);
                _account.Withdraw(5);
                Assert.Equal(0.0, _account.Balance);
            }

            // The demo only has a couple of test cases per method, 
            // but in reality the goal should be to have one test case/scenario.
            // This may lead to a test class to have lots of tests, with a lot of
            // test code duplicated. Data-driven testing is one way to solve this. 
            // However, the real benefit of data-driven testing can be hard to see
            // in this demo due to the low amount of test cases. The demo only 
            // demonstrates the idea of data-driven testing. 
            [Theory,
             InlineData(0.0, 10.0, 10.0),
             InlineData(10.0, 10.0, 20.0)]
            public void DataDrivenStyle_InlineData(double initialAmount, double depositAmount, double expectedAmount)
            {
                var account = new Account(initialAmount);
                Assert.Equal(initialAmount, account.Balance);
                account.Deposit(depositAmount);
                Assert.Equal(expectedAmount, account.Balance);
            }


            [Theory]
            [MemberData(nameof(GetTestData))]
            public void DataDrivenStyle_MemberData(double initialAmount, double depositAmount, double expectedAmount)
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


            [Theory]
            [ClassData(typeof(TestDataGenerator))]
            public void DataDrivenStyle_ClassData(double initialAmount, double depositAmount, double expectedAmount)
            {
                var account = new Account(initialAmount);
                Assert.Equal(initialAmount, account.Balance);
                account.Deposit(depositAmount);
                Assert.Equal(expectedAmount, account.Balance);
            }            
        }


        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { 0.0, 10.0, 10.0 },
                new object[] { 10.0, 10.0, 20.0 }
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
