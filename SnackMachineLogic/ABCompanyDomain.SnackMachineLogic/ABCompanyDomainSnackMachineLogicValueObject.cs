using System;
using System.Collections.Generic;
using System.Text;

namespace ABCompanyDomain.SnackMachineLogic
{
    public abstract class ABCompanyDomainSnackMachineLogicValueObject<T>
        where T : ABCompanyDomainSnackMachineLogicValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }
        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ABCompanyDomainSnackMachineLogicValueObject<T> a, ABCompanyDomainSnackMachineLogicValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(ABCompanyDomainSnackMachineLogicValueObject<T> a, ABCompanyDomainSnackMachineLogicValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
