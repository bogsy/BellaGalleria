using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Service
{
    public interface ICustomerService : IServiceManager<Customer>
    {
    }

    public class CustomerService : BaseServiceManager<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository, IUnitOfWork unitofwork) 
            : base(repository, unitofwork)
        {
        }
    }
}
