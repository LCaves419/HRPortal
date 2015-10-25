using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data
{
    public interface IApplicationRepository
    {
        List<ApplicationInformation> GetAll();
        void Add(ApplicationInformation newApp);
        void Delete(int id);
        void Edit(ApplicationInformation app);
        ApplicationInformation GetById(int id);
    }
}
