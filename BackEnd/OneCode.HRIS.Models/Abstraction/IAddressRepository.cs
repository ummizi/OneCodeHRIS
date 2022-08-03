using OneCode.HRIS.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Abstraction
{
    public interface IAddressRepository
    {
        TransactionAddress Find(string id);
        IQueryable<TransactionAddress> Load();
        IQueryable<TransactionAddress> AddressWithRelation();
        
    }
}
