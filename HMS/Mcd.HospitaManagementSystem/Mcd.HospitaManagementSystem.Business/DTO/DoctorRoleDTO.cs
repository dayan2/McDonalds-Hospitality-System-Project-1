﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcd.HospitaManagementSystem.Business
{
    public class DoctorRoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorSpecialityId { get; set; }
        public Nullable<decimal> Charges { get; set; }
        public string PhoneNo { get; set; }
        public int WardId { get; set; }
    }
}
