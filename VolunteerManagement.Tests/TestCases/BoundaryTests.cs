
using VolunteerManagementApp.DAL;
using VolunteerManagementApp.DAL.Interface;
using VolunteerManagementApp.DAL.Repository;
using VolunteerManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace VolunteerManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IVolunteerInterface _volunteerService;
        public readonly Mock<IVolunteerRepository> volunteerservice = new Mock<IVolunteerRepository>();
        private readonly Volunteer _Volunteer;
        private readonly IEnumerable<Volunteer> VolunteerList;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _volunteerService = new VolunteerManagementService(volunteerservice.Object);
            _output = output;
            _Volunteer = new Volunteer
            {
                VolunteerId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            };
            VolunteerList = new List<Volunteer>
        {
            new Volunteer
            {
               VolunteerId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            },
            new Volunteer
            {
              VolunteerId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            },
            // Add more Volunteer instances as needed
        };

        }

        [Fact]
        public async Task<bool> Testfor_Id_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                volunteerservice.Setup(repos => repos.GetVolunteerById(_Volunteer.VolunteerId)).Returns(_Volunteer);
                var result = _volunteerService.GetVolunteerById(_Volunteer.VolunteerId);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_FirstName_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 volunteerservice.Setup(repos => repos.GetVolunteerById(_Volunteer.VolunteerId)).Returns(_Volunteer);
                var result =  _volunteerService.GetVolunteerById(_Volunteer.VolunteerId);

                //Assertion
                if (result!= null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_LastName_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                volunteerservice.Setup(repos => repos.GetVolunteerById(_Volunteer.VolunteerId)).Returns(_Volunteer);
                var result = _volunteerService.GetVolunteerById(_Volunteer.VolunteerId);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
       
        [Fact]
        public async Task<bool> Testfor_Date_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 volunteerservice.Setup(repos => repos.GetVolunteerById(_Volunteer.VolunteerId)).Returns(_Volunteer);
                var result =  _volunteerService.GetVolunteerById(_Volunteer.VolunteerId);
               

                //Assertion
                if (result!= null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}