using GP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public class ManageProvider
    {
        readonly IList<Provider> providers;
        public ManageProvider(IList<Provider> providers)
        {
            this.providers = providers;
        }
        public IEnumerable<Provider> GetProviderByName(string name)
        {
            return from provider in providers
                   where provider.UserName != null && provider.UserName.Contains(name)
                   select provider;
        }
        public Provider GetFirstProviderByName(string name)
        {
            return GetProviderByName(name).FirstOrDefault();
        }

        public Provider GetProviderById(int id)
        {
            return (from provider in providers
                    where provider.Id == id
                    select provider).Single();
        }
    }
}
