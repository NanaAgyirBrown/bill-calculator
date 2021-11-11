using BillPayment.Domain;
using BillPayment.Interfaces.Repository;
using System.ComponentModel;
using System.Net;

namespace BillPayment.Helpers
{
    public class Responses
    {
        public async Task<ApiResponse> GetResponse(OperationActions action, HttpStatusCode StatusCode, BindingList<string> Message,Object ResponseData)
        {
            return action switch
            {
                OperationActions.Exception =>
                new ApiResponse
                {
                    IsSuccessful = false,
                    HasException = true,
                    HasError = false,
                    Data = null,
                    ErrorPayload = new ServerErrorResponse
                    {
                        status = StatusCode,
                        message = Message
                    }
                },
                OperationActions.Failed =>
                new ApiResponse
                {
                    IsSuccessful = false,
                    HasException = false,
                    HasError = true,
                    Data = ResponseData,
                    ErrorPayload = new ServerErrorResponse
                    {
                        status = StatusCode,
                        message = Message
                    }
                },
                OperationActions.Success =>
                new ApiResponse
                {
                    IsSuccessful = true,
                    HasException = false,
                    HasError = false,
                    Data = ResponseData,
                    ErrorPayload = new ServerErrorResponse{}
                },
                _ => throw new NotImplementedException()
            };
        }
    }
}
