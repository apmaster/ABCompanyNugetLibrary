using System;
using System.Collections.Generic;
using System.Text;

namespace ABCompanyDomain.SnackMachineLogic
{
    public sealed class ABCompanyDomainSnackMachineLogicMoneyBills : ABCompanyDomainSnackMachineLogicValueObject<ABCompanyDomainSnackMachineLogicMoneyBills>
    {
        public static readonly ABCompanyDomainSnackMachineLogicMoneyBills None = new ABCompanyDomainSnackMachineLogicMoneyBills(0, 0, 0, 0);
        public static readonly ABCompanyDomainSnackMachineLogicMoneyBills Dollar = new ABCompanyDomainSnackMachineLogicMoneyBills(1, 0, 0, 0);
        public static readonly ABCompanyDomainSnackMachineLogicMoneyBills FiveDollar = new ABCompanyDomainSnackMachineLogicMoneyBills(0, 1, 0, 0);
        public static readonly ABCompanyDomainSnackMachineLogicMoneyBills TenDollar = new ABCompanyDomainSnackMachineLogicMoneyBills(0, 0, 1, 0);
        public static readonly ABCompanyDomainSnackMachineLogicMoneyBills TwentyDollar = new ABCompanyDomainSnackMachineLogicMoneyBills(0, 0, 0, 1);

        public int OneDollarBill { get; }
        public int FiveDollarBill { get; }
        public int TenDollarBill { get; }
        public int TwentyDollarBill { get; }

        public double Amount
        {
            get
            {
                return OneDollarBill +
                       FiveDollarBill +
                       TenDollarBill +
                       TwentyDollarBill;
            }
        }

        public ABCompanyDomainSnackMachineLogicMoneyBills(
						 int oneDollarBill,
						 int fiveDollarBill,
						 int tenDollarBill,
						 int twentyDollarBill)
        {

            if (oneDollarBill < 0)
            {
                throw new InvalidOperationException();
            }
            if (fiveDollarBill < 0)
            {
                throw new InvalidOperationException();
            }
            if (tenDollarBill < 0)
            {
                throw new InvalidOperationException();
            }
            if (twentyDollarBill < 0)
            {
                throw new InvalidOperationException();
            }
            OneDollarBill = oneDollarBill;
            FiveDollarBill = fiveDollarBill;
            TenDollarBill = tenDollarBill;
            TwentyDollarBill = twentyDollarBill;
        }

        public static ABCompanyDomainSnackMachineLogicMoneyBills operator +(ABCompanyDomainSnackMachineLogicMoneyBills money1, ABCompanyDomainSnackMachineLogicMoneyBills money2)
        {
            ABCompanyDomainSnackMachineLogicMoneyBills sum = new ABCompanyDomainSnackMachineLogicMoneyBills(
                money1.OneDollarBill + money2.OneDollarBill,
                money1.FiveDollarBill + money2.FiveDollarBill,
                money1.TenDollarBill + money2.TenDollarBill,
                money1.TwentyDollarBill + money2.TwentyDollarBill);
            return sum;
        }

        public static ABCompanyDomainSnackMachineLogicMoneyBills operator -(ABCompanyDomainSnackMachineLogicMoneyBills money1, ABCompanyDomainSnackMachineLogicMoneyBills money2)
        {
            return new ABCompanyDomainSnackMachineLogicMoneyBills(
                money1.OneDollarBill - money2.OneDollarBill,
                money1.FiveDollarBill - money2.FiveDollarBill,
                money1.TenDollarBill - money2.TenDollarBill,
                money1.TwentyDollarBill - money2.TwentyDollarBill);
        }

		protected override bool EqualsCore(ABCompanyDomainSnackMachineLogicMoneyBills other)
        {
            return OneDollarBill == other.OneDollarBill
			   && FiveDollarBill == other.FiveDollarBill
			   && TenDollarBill == other.TenDollarBill
			   && TwentyDollarBill == other.TwentyDollarBill;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneDollarBill;
                hashCode = (hashCode * 397) ^ OneDollarBill;
                hashCode = (hashCode * 397) ^ FiveDollarBill;
                hashCode = (hashCode * 397) ^ TenDollarBill;
                hashCode = (hashCode * 397) ^ TwentyDollarBill;
                return hashCode;
            }
        }
    }
}
