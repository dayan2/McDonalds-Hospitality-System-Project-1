﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcd.HospitaManagementSystem.Business.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserRoleId { get; set; }
    }
}
