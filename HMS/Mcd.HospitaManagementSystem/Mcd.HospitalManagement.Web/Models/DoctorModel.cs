using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mcd.HospitalManagement.Web.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorSpecialityId { get; set; }
        public Nullable<decimal> Charges { get; set; }
        public string PhoneNo { get; set; }
        public int WardId { get; set; }
    }
}