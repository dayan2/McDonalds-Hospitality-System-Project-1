using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcd.HospitaManagementSystem.Business
{
    public class DoctorManager : IDoctorManager
    {
        private DoctorDetails details;
        public DoctorManager()
        {
            this.details = new DoctorDetails();
        }

        IEnumerable<DoctorRoleDTO> IDoctorManager.GetDoctors()
        {
            IEnumerable<DoctorRoleDTO> EntityObjectsList = details.GetDoctors();
            return EntityObjectsList;
        }

        void IDoctorManager.AddDoctor(DoctorRoleDTO doctor)
        {
            details.AddDoctor(doctor);
        }

        void IDoctorManager.RemoveDoctor(int id)
        {
            details.RemoveDoctor(id);
        }

        void IDoctorManager.UpdateDoctor(DoctorRoleDTO doctor)
        {
            if (doctor != null)
            {
                details.UpdateDoctor(doctor);
            }
        }
        DoctorRoleDTO IDoctorManager.GetDoctorsById(int id)
        {
            DoctorRoleDTO dto = details.GetDoctorsById(id);
            return dto;
        }
    }
}
