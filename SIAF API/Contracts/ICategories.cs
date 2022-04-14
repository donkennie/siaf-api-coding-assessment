using SIAF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAF_API.Contracts
{
    public interface ICategories
    {
        Task<IEnumerable<Categories>> GetAllCategories();
        Task<Categories> CreateCategories(Categories categories);
    }
}
