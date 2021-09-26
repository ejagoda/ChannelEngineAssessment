using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public string ChannelOrderNo { get; set; }
        public decimal TotalInclVat { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal ShippingCostsInclVat { get; set; }
        public string CurrencyCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
    }
}
