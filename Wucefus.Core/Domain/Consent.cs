namespace Wucefus.Core.Domain
{
    public class Consent
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool? Value { get; set; }
        public string Description { get; set; }
    }
}
