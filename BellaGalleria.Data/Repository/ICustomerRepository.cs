using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Data.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }
    }
}
