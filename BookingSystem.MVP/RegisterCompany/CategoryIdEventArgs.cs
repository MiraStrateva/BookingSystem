using System;

namespace BookingSystem.MVP.RegisterCompany
{
    public class CompanyIdEventArgs : EventArgs
    {
        public Guid? CompanyId { get; private set; }

        public CompanyIdEventArgs(Guid? companyId)
        {
            this.CompanyId = companyId;
        }
    }
}
