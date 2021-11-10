using System.Net;

namespace BillPayment.Helpers
{
    public static class BillerStatus
    {
        public const HttpStatusCode Created = HttpStatusCode.Created;
        public const HttpStatusCode Fetched = HttpStatusCode.OK;
        public const HttpStatusCode Updated = HttpStatusCode.Accepted;
        public const HttpStatusCode Deleted = HttpStatusCode.IMUsed;
        public const HttpStatusCode Crashed = HttpStatusCode.InternalServerError;
        public const HttpStatusCode Failed = HttpStatusCode.PreconditionFailed;
        public const HttpStatusCode InValidObject = HttpStatusCode.BadRequest;
        public const HttpStatusCode NotFound = HttpStatusCode.NotFound;
    }
}
