using System.Collections.Generic;

namespace Wucefus.Core.Dto
{
    public class GetConsentsResultDto : ResponseDto
    {
        public IEnumerable<ConsentDto> Consents { get; set; }
    }
}
