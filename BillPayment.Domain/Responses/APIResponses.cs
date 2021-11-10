using BillPayment.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain
{
 
    public class ApiResponse
    {
        public ApiResponse() => ErrorPayload = new ServerErrorResponse();
        public bool IsSuccessful { get; set; } = false;
        public bool HasError { get; set; } = false;
        public bool HasException { get; set; } = false;
        public IEnumerable<Object> Data { get; set; }
        public ServerErrorResponse ErrorPayload { get; set; }
    }

    public class ServerErrorResponse
    {
        public HttpStatusCode status { get; set; }
        public BindingList<string> message { get; set; }
    }
}
