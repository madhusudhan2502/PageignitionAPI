using System;
using System.ComponentModel.DataAnnotations;

namespace Pagination.WebApi.Models
{
    public class BondAppData
    {
        [Key]
        public int BondApplicationID { get; set; }
        public string BondCompanyName { get; set; }
        public string BondType { get; set; }
        public DateTime PostedDateTime { get; set; }
        public DateTime PaymentAuthorizedDate { get; set; }
        public DateTime PaymentCapturedDate { get; set; }
    }
}
