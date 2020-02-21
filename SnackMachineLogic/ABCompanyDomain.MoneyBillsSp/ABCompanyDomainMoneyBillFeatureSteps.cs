using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ABCompanyDomain.SnackMachineLogic;
using FluentAssertions;

namespace ABCompanyDomain.MoneyBillsSp
{
    [Binding]
    public class ABCompanyDomainMoneyBillFeatureSteps
    {
        [Given(@"there are two single dollar bills")]
        [Test]
        public void GivenThereAreTwoSingleDollarBills()
        {
            //Arrange
            ABCompanyDomainSnackMachineLogicMoneyBills MoneyBill_1 = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);
            ABCompanyDomainSnackMachineLogicMoneyBills MoneyBill_2 = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);
           
            //Act
            ABCompanyDomainSnackMachineLogicMoneyBills sum = MoneyBill_1 + MoneyBill_2;

            // Assert.Equals(2, sum.OneDollarBill);
            sum.OneDollarBill.Should().Be(2);
            sum.FiveDollarBill.Should().Be(4);
            sum.TenDollarBill.Should().Be(6);
            sum.TwentyDollarBill.Should().Be(8);
        }
       
        [Given(@"it gets inserted into the snack machine")]
        [Test]
        public void GivenItGetsInsertedIntoTheSnackMachine()
        {
            ABCompanyDomainSnackMachineLogicMoneyBills moneybill1 = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);
            ABCompanyDomainSnackMachineLogicMoneyBills moneybill2 = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);

            moneybill1.Should().Be(moneybill2);
            moneybill1.GetHashCode().Should().Be(moneybill2.GetHashCode());
        }
        
        [When(@"the snack machine recieves the last dollar")]
        [Test]
        public void WhenTheSnackMachineRecievesTheLastDollar()
        {
            ABCompanyDomainSnackMachineLogicMoneyBills dollar = new ABCompanyDomainSnackMachineLogicMoneyBills(0, 0, 1, 1);
            ABCompanyDomainSnackMachineLogicMoneyBills DifferentDollar = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 0, 0, 0);

            dollar.Should().NotBe(DifferentDollar);
            dollar.GetHashCode().Should().NotBe(DifferentDollar.GetHashCode());
        }
        
        [Then(@"the snack machine should display zero dollars")]
        [Test]
        public void ThenTheSnackMachineShouldDisplay()
        {
            ABCompanyDomainSnackMachineLogicMoneyBills MoneyBill_1 = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);
            ABCompanyDomainSnackMachineLogicMoneyBills MoneyBill_2 = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 2, 3, 4);

            ABCompanyDomainSnackMachineLogicMoneyBills sum = MoneyBill_1 - MoneyBill_2;
            
            // Assert.Equals(2, sum.OneDollarBill);

            sum.OneDollarBill.Should().Be(0);
            sum.FiveDollarBill.Should().Be(0);
            sum.TenDollarBill.Should().Be(0);
            sum.TwentyDollarBill.Should().Be(0);
        }


    }
}
