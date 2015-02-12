﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcd.HospitaManagementSystem.Business
{
    public interface IDoctorManager
    {
        IEnumerable<DoctorRoleDTO> GetDoctors();
        DoctorRoleDTO GetDoctorsById(int id);
        //get Patient details_Appointments
        void AddDoctor(DoctorRoleDTO doctor);
        void RemoveDoctor(int id);
        void UpdateDoctor(DoctorRoleDTO doctor);
        //void DoctorRecomendation();
    }
}
