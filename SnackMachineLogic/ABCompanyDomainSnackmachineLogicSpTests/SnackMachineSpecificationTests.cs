using NUnit.Framework;
using FluentAssertions;
using static ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills;
using TechTalk.SpecFlow;
using System;

namespace ABCompanyDomainSnackmachineLogicSpTests
{
    public class Tests
    {
        [Given(@"Empty Transaction")]
        [Test]
        public void GivenEmptyTransaction()
        {
            var snackMachine = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogic();

            snackMachine.InsertMoneyBills(Dollar);
            snackMachine.ReturnMoney();

            snackMachine.MoneyBillsInTransaction.Amount.Should().Be(0.0);
        }
        [Given(@"Insert Money in Transaction")]
        [Test]
        public void GivenInsertMoneyInTransaction()
        {
            var snackMachine = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogic();

            snackMachine.InsertMoneyBills(Dollar);
            snackMachine.InsertMoneyBills(FiveDollar);

            snackMachine.MoneyBillsInTransaction.Amount.Should().Be(2.0);
        }

        [Given(@"Insert more than one dollar bill at once")]
        [Test]
        public void GivenInsertMoreThanOneDollarBillAtOnce()
        {
            var snackMachine = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogic();
            var twoDollars = Dollar + Dollar;

            System.Action action = () => snackMachine.InsertMoneyBills(twoDollars);
            action.Should().Throw<InvalidOperationException>();
        }
        [Given(@"A transaction is made for a purchase")]
        [Test]
        public void GivenATransactionIsMadeForAPurchase()
        {
            var snackMachine = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogic();
            snackMachine.InsertMoneyBills(Dollar);
            snackMachine.InsertMoneyBills(Dollar);

            snackMachine.BuySnack();

            snackMachine.MoneyBillsInTransaction.Should().Be(None);
            snackMachine.MoneyBillsInside.Amount.Should().Be(2);
        }
    }
}