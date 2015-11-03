using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.PolicyRepo
{
    public interface IPolicyRepository
    {
        List<PolicyInformation> GetAll();
        List<Category> GetAllCategories();
        void Add(PolicyInformation newPol);
        void Delete(int id);
        void Edit(PolicyInformation pol);
        PolicyInformation GetById(int id);
    }
}
