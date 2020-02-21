using System;
using System.Linq;
using static ABCompanyDomain.SnackMachineLogic.ABCompanyDomainSnackMachineLogicMoneyBills;

namespace ABCompanyDomain.SnackMachineLogic
{
    public class ABCompanyDomainSnackMachineLogic:ABCompanyDomainSnackMachineLogicEntity
    {
          public ABCompanyDomainSnackMachineLogicMoneyBills MoneyBillsInside { get; private set; } = None;
          public ABCompanyDomainSnackMachineLogicMoneyBills MoneyBillsInTransaction { get; private set; } = None;

        public void InsertMoneyBills(ABCompanyDomainSnackMachineLogicMoneyBills DollarBill)
        {
            ABCompanyDomainSnackMachineLogicMoneyBills[] AllDollars = { Dollar, FiveDollar, TenDollar, TwentyDollar };
            if (!AllDollars.Contains(DollarBill))
            {
                throw new InvalidOperationException();
            }
            MoneyBillsInTransaction += DollarBill;
        }

        public void ReturnMoney()
        {
            MoneyBillsInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyBillsInside += MoneyBillsInTransaction;
            MoneyBillsInTransaction = None;
        }
    }
}
