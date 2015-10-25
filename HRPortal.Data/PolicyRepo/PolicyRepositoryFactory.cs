using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data.PolicyRepo
{
    public static class PolicyRepositoryFactory
    {
        public static IPolicyRepository CreatePolicyRepository()
        {
            switch (ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "test":
                    return new MockPolicyRepository();
                case "prod":
                    return new PolicyRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
