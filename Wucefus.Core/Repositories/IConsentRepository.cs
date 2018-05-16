using System.Collections.Generic;
using Wucefus.Core.Domain;

namespace Wucefus.Core.Repositories
{
    public interface IConsentRepository
    {
        IEnumerable<Consent> GetAll();

        Consent GetById(int id);
    }
}
