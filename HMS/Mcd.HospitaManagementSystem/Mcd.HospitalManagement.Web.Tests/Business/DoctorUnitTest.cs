using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Data.Linq;
using System.Collections.Generic; 
using Mcd.HospitalManagementSystem.Data;
using Mcd.HospitaManagementSystem.Business;
using System.Linq;

namespace Mcd.HospitalManagement.Web.Tests.Business
{
    [TestClass]
    public class DoctorUnitTest
    {
        //[TestMethod]
        //public void BusinessDoctorRole_GetDoctorsMethod_Returns_DoctorRoleDTO_TypeOfList()
        //{
            //Mock<IBusinessDoctorRole> mock = new Mock<IBusinessDoctorRole>();

            //List<DoctorRoleDTO> list = new List<DoctorRoleDTO> { 
            //    new DoctorRoleDTO{Id = 1 , Name = "ddayan",PhoneNo = "2341234", Charges = 222, WardId = 1, DoctorSpeciatlyId = 1},
            //    new DoctorRoleDTO{Id = 2 , Name = "Mendis",PhoneNo = "123456789", Charges = 22, WardId = 2, DoctorSpeciatlyId = 2}
            //};

            //IEnumerable<DoctorRoleDTO> dlist = list;
            //IEnumerable<DoctorRoleDTO> data = GetData();
            //IEnumerable<DoctorRoleDTO> clist = from c in lll
            //                                   select new DoctorRoleDTO
            //                                   {
            //                                       Id = c.Id
            //                                   };
            //mock.Setup(x => x.GetDoctors()).Returns(dlist);

            //IBusinessDoctorRole control = new BusinessDoctorRole();
            //var actual = (IEnumerable<Doctor>)control.GetDoctors();
            //Assert.IsInstanceOfType(actual, typeof(IEnumerable<DoctorRoleDTO>));
        //}

        /// <summary>
        /// AddDoctors Method
        /// </summary>
        /// 
        [TestMethod]
        public void DoctorDetails_AddDoctorMethod_Saves_A_Doctor_Via_Context()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Doctor>>();

            var mockContext = new Mock<LP_HMSDbEntities>();
            mockContext.Setup(m => m.Doctors).Returns(mockSet.Object);

            // Act
            var service = new DoctorDetails(mockContext.Object);
            service.AddDoctor(new DoctorRoleDTO() { Id = 11, Name = "neranjan", Charges = 220, DoctorSpecialityId = 1, PhoneNo = "", WardId = 1 });

            //Verify
            mockSet.Verify(m => m.Add(It.IsAny<Doctor>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// GetDoctors Method
        /// </summary>
        /// 
        [TestMethod]
        public void DoctorDetails_GetDoctorsMethod_Retrieve_All_Doctor_Models()
        {
            // Arrange
            var data = new List<Doctor> 
            { 
                new Doctor { Name = "Duminda" }, 
                new Doctor { Name = "Yohan" }, 
                new Doctor { Name = "Piyumi" },
                new Doctor { Name = "Neranjan" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Doctor>>();
            mockSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<LP_HMSDbEntities>();
            mockContext.Setup(c => c.Doctors).Returns(mockSet.Object);

            // Act
            var service = new DoctorDetails(mockContext.Object);
            var doctors = service.GetDoctors();

            // Assert
            Assert.IsNotNull(doctors);
            Assert.AreEqual(4, (int)doctors.Count());
            Assert.AreEqual("Duminda", doctors.ElementAt(0).Name.ToString());
            Assert.AreEqual("Yohan", doctors.ElementAt(1).Name.ToString());
            Assert.AreEqual("Piyumi", doctors.ElementAt(2).Name.ToString());
            Assert.AreEqual("Neranjan", doctors.ElementAt(3).Name.ToString());
        }

        //[TestMethod]
        //public void DoctorDetails_GetDoctorsByIdMethod_Should_Retrieve_A_DoctorById()
        //{
        //    // Arrange
        //    var data = new List<Doctor> 
        //    { 
        //        new Doctor { Name = "Duminda" }, 
        //        new Doctor { Name = "Yohan" }, 
        //        new Doctor { Name = "Piyumi" },
        //        new Doctor { Name = "Neranjan" }
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<Doctor>>();
        //    mockSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    var mockContext = new Mock<LP_HMSDbEntities>();
        //    mockContext.Setup(c => c.Doctors).Returns(mockSet.Object);

        //    // Act
        //    var service = new DoctorDetails(mockContext.Object);
        //    var actual = service.GetDoctorsById(1);

        //    // Assert
        //    Assert.IsNotNull(actual);
        //    //Assert.AreEqual(1 , driver.Id);

        //}

        //[TestMethod]
        //public void DoctorDetails_RemoveDoctorMethod_Remove_Doctors_From_Context()
        //{
        //    var data = new List<Doctor> 
        //    { 
        //        new Doctor { Name = "Duminda" }, 
        //        new Doctor { Name = "Yohan" }, 
        //        new Doctor { Name = "Piyumi" },
        //        new Doctor { Name = "Neranjan" }
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<Doctor>>();

        //    var mockContext = new Mock<LP_HMSDbEntities>();

        //    mockSet.As<IQueryable<Doctor>>()
        //     .Setup(x => x.Provider)
        //     .Returns(data.Provider);
        //    mockSet.As<IQueryable<Doctor>>()
        //             .Setup(x => x.ElementType)
        //             .Returns(data.ElementType);
        //    mockSet.As<IQueryable<Doctor>>()
        //             .Setup(x => x.Expression)
        //             .Returns(data.Expression);
        //    mockSet.As<IQueryable<Doctor>>()
        //             .Setup(x => x.GetEnumerator())
        //             .Returns(data.GetEnumerator());

        //    mockContext.Setup(m => m.Doctors).Returns(mockSet.Object);

        //    var service = new DoctorDetails(mockContext.Object);
        //    service.RemoveDoctor(1);


        //    mockContext.VerifyGet(x => x.Doctors, Times.Exactly(2)); 
        //    //mockSet.Verify(x => x.Remove(It.IsAny<Doctor>()), Times.Once());

        //    //mockSet.Verify(m => m.Remove(It.IsAny<Doctor>()), Times.Once());
        //    //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //}

        #region Exception Handling
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DoctorDetails_GetDoctorsMethod_Should_Raised_An_Exception()
        {
            //Arrange
            Mock<DoctorDetails> mock = new Mock<DoctorDetails>();
            mock.Setup(x => x.GetDoctors()).Throws<Exception>();

            DoctorDetails manager = new DoctorDetails();
            manager.GetDoctors();
            //Act

            //mock.Object.GetDoctors();
            //mock.Verify(x => x.GetDoctors() , Times.Once() ) ;
            //mock.Verify(x => x.GetDoctors());
            Assert.IsNull(manager.GetDoctors());

        }
        #endregion

    }
}
