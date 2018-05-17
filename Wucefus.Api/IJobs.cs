using System.ServiceModel;
using System.ServiceModel.Web;
using Wucefus.Core.Dto;

namespace Wucefus.Api
{
    [ServiceContract]
    public interface IJobs
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseDto Ping();

        /// <summary>
        /// Example usage: http://localhost:63165/jobs.svc/date/2016/12/12
        /// </summary>
        [WebGet(UriTemplate = "date/{year}/{month}/{day}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        ResponseDto GetByDate(string day, string month, string year);

        [WebInvoke(Method = "POST", UriTemplate = "add/{desc}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseDto AddDescription(string desc);

        [WebInvoke(Method = "POST", UriTemplate = "consent", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseDto AddConsent(ConsentDto consent);

        [WebInvoke(Method = "PUT", UriTemplate = "consent", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseDto UpdateConsent(ConsentDto consent);

        [WebInvoke(Method = "DELETE", UriTemplate = "consent/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseDto DeleteConsent(string id);
    }
}
