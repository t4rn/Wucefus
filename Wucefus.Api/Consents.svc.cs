using System;
using System.Diagnostics;
using Wucefus.Api.Inspectors;
using Wucefus.Core.Dto;
using Wucefus.Core.Extensions;
using Wucefus.Core.Services;
using Wucefus.Core.Services.Loggers;

namespace Wucefus.Api
{
    [LoggerServiceBehavior]
    public class Consents : BaseSvc, IConsents
    {
        private readonly string _ip;
        private readonly IConsentService _consentService;

        public Consents(IKrisLogger logger, IConsentService consentService) : base(logger)
        {
            _ip = PrepareIp();
            _consentService = consentService;
        }

        public GetConsentsResultDto GetConsentsAll()
        {
            string methodName = nameof(GetConsentsAll);
            _log.Debug($"[{methodName}] START for IP: '{_ip}'");
            GetConsentsResultDto result = new GetConsentsResultDto();

            Stopwatch stopWatch = Stopwatch.StartNew();
            try
            {
                result.Consents = _consentService.GetAll();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                _log.Error($"[{methodName}] Ex: {ex}");
                result.Message = $"Exception occurred: {ex.Message}.";
            }

            result.ProcessTime = stopWatch.Elapsed.ToString();
            _log.Debug($"[{methodName}] END for IP: '{_ip}' | result: {result.Serialize()}");

            return result;
        }

        public string Ping(int value)
        {
            _log.Debug($"[{nameof(Ping)}] START for IP: '{_ip}' and value: '{value}'");
            return string.Format($"You entered: '{value}' from IP: '{_ip}'.");
        }
    }
}
