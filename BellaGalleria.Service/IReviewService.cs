using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Service
{
    public interface IReviewService : IServiceManager<Review>
    {
    }

    public class ReviewService : BaseServiceManager<Review>, IReviewService
    {
        public ReviewService(IRepository<Review> repository, IUnitOfWork unitofwork) 
            : base(repository, unitofwork)
        {
        }
    }
}
