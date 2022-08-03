using OneCode.HRIS.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Abstraction
{
    public interface IAddressTypeRepository
    {
        MasterAddressType Find(string id);
        IQueryable<MasterAddressType> Load();
    }
}
