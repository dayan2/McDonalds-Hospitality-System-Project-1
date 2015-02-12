using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mcd.HospitaManagementSystem.Business;
using System.Collections.Generic;
using Mcd.HospitalManagement.Web.Controllers;
using System.Web.Mvc;
using Mcd.HospitalManagement.Web.Models;

namespace Mcd.HospitalManagement.Web.Tests.Controllers
{
    [TestClass]
    public class DoctorControllerTest
    {

        /// <summary>
        /// GetAllDoctors List
        /// </summary>
        [TestMethod]
        public void DoctorController_GetDoctorsMethod_Should_Return_A_DoctorModelTypeOfList_To_The_View()
        {
            Mock<IDoctorManager> mock = new Mock<IDoctorManager>();

            List<DoctorRoleDTO> list = new List<DoctorRoleDTO>{
                                                new DoctorRoleDTO{Id = 11 , Name = "neranjan", Charges = 220, DoctorSpecialityId = 1, PhoneNo = "", WardId = 1},
                                                new DoctorRoleDTO{Id = 91 , Name = "Ewerdney", Charges = 1220, DoctorSpecialityId = 1, PhoneNo = "", WardId = 1}
                                       };
            IEnumerable<DoctorRoleDTO> clist = list;

            mock.Setup(e => e.GetDoctors()).Returns(clist);

            DoctorController cont = new DoctorController(mock.Object);
            var View = (ViewResult)cont.GetDoctors();
            var actual = (IEnumerable<DoctorModel>)View.Model;
            //Assert
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<DoctorModel>));
        }

        /// <summary>
        /// UpdateDoctor
        /// </summary>
        /// HTTPGet Method
        [TestMethod]
        public void DoctorController_UpdateDoctorMethod_Should_Return_A_Doctor_Model()
        {
            Mock<IDoctorManager> mock = new Mock<IDoctorManager>();

            DoctorRoleDTO expectedDoctor = new DoctorRoleDTO { Id = 11, Name = "neranjan", Charges = 220, DoctorSpecialityId = 1, PhoneNo = "", WardId = 1 };

            mock.Setup(x => x.GetDoctorsById(It.IsAny<int>())).Returns(expectedDoctor);

            DoctorController controller = new DoctorController(mock.Object);
            var control = (ViewResult)controller.UpdateDoctor(1);
            var actual = (DoctorRoleDTO)control.ViewData.Model;

            //Assert
            Assert.AreEqual(expectedDoctor.Id, actual.Id);
            Assert.AreEqual(expectedDoctor.Name, actual.Name);
        }
        /// <summary>
        /// UpdateDoctor
        /// </summary>
        /// HTTPPostMethod
        [TestMethod]
        public void DoctorController_UpdateDoctorMethod_Should_Verify_And_Redirect_To_The_Index()
        {
            Mock<IDoctorManager> mock = new Mock<IDoctorManager>();

            DoctorModel expectedDoctor = new DoctorModel { Id = 11, Name = "neranjan", Charges = 220, DoctorSpecialityId = 1, PhoneNo = "", WardId = 1 };

            mock.Setup(x => x.UpdateDoctor(It.IsAny<DoctorRoleDTO>()));

            DoctorController controller = new DoctorController(mock.Object);
            var result = (RedirectToRouteResult)controller.UpdateDoctor(expectedDoctor);
            //var actual = (DoctorRoleDTO)control.ViewData.Model;

            mock.Verify();

            //Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Doctor", result.RouteValues["controller"]);
        }



        /// <summary>
        /// RemoveDoctor
        /// </summary>
        [TestMethod]
        public void DoctorController_RemoveDoctorMethod_Should_Verify_And_Redirect_To_The_Index()
        {
            Mock<IDoctorManager> mock = new Mock<IDoctorManager>();

            mock.Setup(x => x.RemoveDoctor(It.IsAny<int>()));

            DoctorController controller = new DoctorController(mock.Object);
            var result = (RedirectToRouteResult)controller.RemoveDoctor(new DoctorRoleDTO());

            //Verify
            mock.Verify();

            //Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Doctor", result.RouteValues["controller"]);
        }


        /// <summary>
        /// DoctorDetails
        /// </summary>
        [TestMethod]
        public void DoctorController_DetailsMethod_Should_Return_A_DoctorModel_To_The_View()
        {
            Mock<IDoctorManager> mock = new Mock<IDoctorManager>();

            DoctorRoleDTO expectedDoctor = new DoctorRoleDTO { Id = 11, Name = "neranjan", Charges = 220, DoctorSpecialityId = 1, PhoneNo = "", WardId = 1 };

            mock.Setup(x => x.GetDoctorsById(It.IsAny<int>())).Returns(expectedDoctor);

            DoctorController controller = new DoctorController(mock.Object);
            var control = (ViewResult)controller.Details(1);
            var actual = (DoctorRoleDTO)control.ViewData.Model;

            //Assert
            Assert.AreEqual(expectedDoctor.Id, actual.Id);
            Assert.AreEqual(expectedDoctor.Name, actual.Name);
        }


        /// <summary>
        /// AddDoctor
        /// </summary>
        /// HttpPostMethod
        [TestMethod]
        public void DoctorController_AddDoctorMethod_Should_Verify_And_Redirect_To_The_Index()
        {
            Mock<IDoctorManager> mock = new Mock<IDoctorManager>();

            mock.Setup(x => x.AddDoctor(It.IsAny<DoctorRoleDTO>()));

            DoctorController controller = new DoctorController(mock.Object);
            var result = (RedirectToRouteResult)controller.AddDoctor(new DoctorModel());

            //Verify
            mock.Verify();

            //Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Doctor", result.RouteValues["controller"]);
        }
    }
}
