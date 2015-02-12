using Mcd.HospitalManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcd.HospitaManagementSystem.Business
{
    public class DoctorDetails
    {
        private LP_HMSDbEntities context;
        public DoctorDetails()
        {
            this.context = new LP_HMSDbEntities();
        }
        public DoctorDetails(LP_HMSDbEntities context)
        {
            this.context = context;
        }
        public IEnumerable<DoctorRoleDTO> GetDoctors()
        {
            try
            {
                var EntityObjectsList = context.Doctors.ToList();
                IEnumerable<DoctorRoleDTO> DTOlist = from c in EntityObjectsList
                                                     select new DoctorRoleDTO
                                                     {
                                                         Id = c.Id,
                                                         Name = c.Name,
                                                         DoctorSpecialityId = c.DoctorSpecialityId,
                                                         PhoneNo = c.PhoneNo,
                                                         WardId = c.WardId,
                                                         Charges = c.Charges
                                                     };
                return DTOlist;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("InvalidOperationException - Fail To Retrieve Doctors", ex);
            }

        }
        public DoctorRoleDTO GetDoctorsById(int id)
        {
            //try
            //{
                var EntityObjects = context.Doctors.Find(id);
                DoctorRoleDTO dto = new DoctorRoleDTO
                {
                    Id = EntityObjects.Id,
                    Name = EntityObjects.Name,
                    Charges = EntityObjects.Charges,
                    DoctorSpecialityId = EntityObjects.DoctorSpecialityId,
                    PhoneNo = EntityObjects.PhoneNo,
                    WardId = EntityObjects.WardId
                };
                return dto;
            //}
            //catch (InvalidOperationException ex)
            //{
            //    throw new Exception("InvalidOperationException - Failure To Get DoctorsById", ex);
            //}
        }
        public void AddDoctor(DoctorRoleDTO doctor)
        {
            try
            {
                Doctor EntityDoctorObj = new Doctor
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    DoctorSpecialityId = doctor.DoctorSpecialityId,
                    Charges = doctor.Charges,
                    PhoneNo = doctor.PhoneNo,
                    WardId = doctor.WardId
                };
                context.Doctors.Add(EntityDoctorObj);
                context.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("InvalidOperationException - Fail To Save The Doctor", ex);
            }
        }

        public void RemoveDoctor(int id)
        {
            try
            {
                var doctor = context.Doctors.Find(id);
                if (doctor != null)
                {
                    context.Doctors.Remove(doctor);
                    context.SaveChanges();
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("InvalidOperationException - Fail To Remove The Doctor", ex);
            }
        }

        public void UpdateDoctor(DoctorRoleDTO doctor)
        {
            try
            {
                Doctor EntityDoctorObj = new Doctor
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    DoctorSpecialityId = doctor.DoctorSpecialityId,
                    Charges = doctor.Charges,
                    PhoneNo = doctor.PhoneNo,
                    WardId = doctor.WardId
                };
                context.Entry(EntityDoctorObj).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("InvalidOperationException - Failure To Modify The Doctor", ex);
            }
        }
    }
}
