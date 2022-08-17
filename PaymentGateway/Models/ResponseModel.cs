using System;

namespace PaymentGateway.Models
{
    public class ResponseModel
    {

        public int ResponseCode { get; set; }
        public string?  Message { get; set; }
        public string? ApprovalCode { get; set; }
        public DateTime DateTime  { get; set; }
    }
}
