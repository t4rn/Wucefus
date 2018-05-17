using System;
using Wucefus.Core.Dto;

namespace Wucefus.Api
{
    public class Jobs : IJobs
    {
        public ResponseDto AddConsent(ConsentDto consent)
        {
            ResponseDto response = new ResponseDto();
            response.Message = $"You've sent a Consent with Value: '{consent?.Value}' and Desc: '{consent.Description}'!";
            response.IsOk = true;

            return response;
        }

        public ResponseDto AddDescription(string desc)
        {
            ResponseDto response = new ResponseDto();
            response.Message = $"You've sent: {desc}!";
            response.IsOk = true;

            return response;
        }

        public ResponseDto GetByDate(string day, string month, string year)
        {
            ResponseDto response = new ResponseDto();
            DateTime date = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

            response.Message = $"You entered: {date.ToString("dddd, MMMM dd, yyyy")}.";
            response.IsOk = true;

            return response;
        }

        public ResponseDto Ping()
        {
            ResponseDto response = new ResponseDto();
            response.Message = $"Hello from {nameof(Jobs)}!";
            response.IsOk = true;

            return response;
        }
    }
}
