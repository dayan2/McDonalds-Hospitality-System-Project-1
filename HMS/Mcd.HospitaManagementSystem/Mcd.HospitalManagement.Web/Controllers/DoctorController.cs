using Mcd.HospitalManagement.Web.Models;
using Mcd.HospitaManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mcd.HospitalManagement.Web.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorManager repo;
        #region Constructors
        public DoctorController()
        {
            this.repo = new DoctorManager();
        }
        public DoctorController(IDoctorManager repo)
        {
            this.repo = repo;
        }
        #endregion


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDoctors()
        {
            IEnumerable<DoctorRoleDTO> list = repo.GetDoctors();
            IEnumerable<DoctorModel> dlist = from c in list
                                             select new DoctorModel
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            Charges = c.Charges,
                                            PhoneNo = c.PhoneNo,
                                            DoctorSpecialityId = c.DoctorSpecialityId,
                                            WardId = c.WardId
                                        };
            return View(dlist);
        }
        public ActionResult FrontPage()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(DoctorModel doctor)
        {
            DoctorRoleDTO model = new DoctorRoleDTO
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Charges = doctor.Charges,
                DoctorSpecialityId = doctor.DoctorSpecialityId,
                PhoneNo = doctor.PhoneNo,
                WardId = doctor.WardId
            };
            repo.AddDoctor(model);
            return RedirectToAction("Index", "Doctor");
        }

        [HttpGet]
        public ActionResult UpdateDoctor(int id)
        {
            DoctorRoleDTO model = repo.GetDoctorsById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateDoctor(DoctorModel doctor)
        {
            DoctorRoleDTO model = new DoctorRoleDTO
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Charges = doctor.Charges,
                DoctorSpecialityId = doctor.DoctorSpecialityId,
                PhoneNo = doctor.PhoneNo,
                WardId = doctor.WardId
            };
            repo.UpdateDoctor(model);
            return RedirectToAction("Index", "Doctor");
        }

        [HttpGet]
        public ActionResult RemoveDoctor(int id)
        {
            DoctorRoleDTO model = repo.GetDoctorsById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult RemoveDoctor(DoctorRoleDTO doctor)
        {
            repo.RemoveDoctor(doctor.Id);
            return RedirectToAction("Index", "Doctor");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            DoctorRoleDTO model = repo.GetDoctorsById(id);
            return View(model);
        }
    }
}