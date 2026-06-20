using System;

namespace Angular.Api.Data.Dtos
{
    public class EnquiryDto
    {
        public int EnquiryId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public double Rate { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
