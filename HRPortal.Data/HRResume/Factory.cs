using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HRPortal.Models;

namespace HRPortal.Data
{
    public static class Factory
    {
        public static IApplicationRepository CreateApplicationRepository()
        {
            switch (ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "test":
                    return new MockHRRepository();
                case "prod":
                    return new HRRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

