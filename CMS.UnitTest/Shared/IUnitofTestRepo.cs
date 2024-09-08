using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UnitTest.Shared
{
    public interface IUnitofTestRepo
    {
        IProductRepository productRepository { get; }
        IHomeRepository homeRepository { get; }
        IAboutRepository aboutRepository { get; }
        IContactRepository contactRepository { get; }
        IOrderRepository orderRepository { get; }
        ICartRepository cartRepository { get; }
        IEmployeeRepository employeeRepository { get; }
        IHostingPackageRepository hostingPackageRepository { get; }
        IBranchRepository branchRepository { get; }
        ICategoryRepository categoryRepository { get; }
        IRewardsEmailRepository rewardsEmailRepository { get; }
        IImageRepository imageRepository { get; }
    }
}
