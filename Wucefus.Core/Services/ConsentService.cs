using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wucefus.Core.Domain;
using Wucefus.Core.Dto;
using Wucefus.Core.Repositories;

namespace Wucefus.Core.Services
{
    public class ConsentService : IConsentService
    {
        private readonly IConsentRepository _consentRepository;

        public ConsentService(IConsentRepository consentRepository)
        {
            _consentRepository = consentRepository;
        }
        public IEnumerable<ConsentDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ConsentDto GetByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
