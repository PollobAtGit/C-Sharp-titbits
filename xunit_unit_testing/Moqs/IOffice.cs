using System.Collections.Generic;

namespace Moqs
{
    public interface IOffice
    {
        IEmployee ChiefExecutiveOfficer { get; }

        IReadOnlyCollection<IEmployee> Employees { get; }
    }
}