using System.Collections.Generic;
using Wucefus.Core.Dto;

namespace Wucefus.Core.Services
{
    public interface IConsentService
    {
        IEnumerable<ConsentDto> GetAll();

        ConsentDto GetByCode(string code);
    }
}
