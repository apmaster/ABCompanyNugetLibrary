using System;
using NUnit.Framework;
using FluentAssertions;

namespace ABCompanyDomain.MoneyBillsSp
{
    public class ABCompanyDomainMoneyBillUnitTests
    {
        [Test]
        public void Negative_Dollar_Bill()
        {
            int testoncedollar = 2;
            int testfivedollar = 2;
            int testtendollar = 2;
            int testtwentydollar = -1;

            Action action = () => new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills(
                testoncedollar,
                testfivedollar,
                testtendollar,
                testtwentydollar);

            action.Should().Throw<InvalidOperationException>();

        }

        [Test]
        public void Amount_Is_Calculated_Correctly()
        {
            int onedollarcount = 1;
            int fivedollarcount = 2;
            int tendollarcount = 0;
            int twentydollarcount = 1;

            double expectedamount = 4;

            ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills money = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills(
                onedollarcount,
                fivedollarcount,
                tendollarcount,
                twentydollarcount);

            money.Amount.Should().Be(expectedamount);
        }

        [Test]
        public void Subtract_two_money_Bills_Correctly()
        {
            ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills Money1 = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);
            ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills Money2 = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills(0, 1, 2, 3);

            ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills Result = Money1 - Money2;

            Result.OneDollarBill.Should().Be(1);
            Result.FiveDollarBill.Should().Be(1);
            Result.TenDollarBill.Should().Be(1);
            Result.TwentyDollarBill.Should().Be(1);
        }
        [Test]
        public void Cannot_Subtract_more_than_Exists()
        {
            ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills money1 = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills(0, 1, 0, 0);
            ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills money2 = new ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills(1, 0, 0, 0);

            Action action = () =>
            {
                ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills money = money1 - money2;
            };

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
