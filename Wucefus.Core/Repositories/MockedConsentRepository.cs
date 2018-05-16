using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wucefus.Core.Domain;

namespace Wucefus.Core.Repositories
{
    public class MockedConsentRepository : IConsentRepository
    {
        public IEnumerable<Consent> GetAll()
        {
            var consents = new List<Consent>();

            return consents;
        }

        public Consent GetById(int id)
        {
            Consent consent = new Consent();

            return consent;
        }
    }
}
