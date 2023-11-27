
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
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IVolunteerInterface _volunteerService;
        public readonly Mock<IVolunteerRepository> volunteerservice = new Mock<IVolunteerRepository>();
        private readonly Volunteer _Volunteer;
        private readonly IEnumerable<Volunteer> VolunteerList;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
             _volunteerService = new VolunteerManagementService( volunteerservice.Object);
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
        public async Task<bool> Testfor_Get_Volunteer()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                  volunteerservice.Setup(repos => repos.GetAllVolunteers()).Returns(VolunteerList);
                var result =   _volunteerService.GetAllVolunteers();
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
        public async Task<bool> Testfor_Get_Volunteer_ById()
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
        public async Task<bool> Testfor_Update_Volunteer()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 volunteerservice.Setup(repos => repos.UpdateVolunteer(_Volunteer)).Returns(_Volunteer);
                var result= _volunteerService.UpdateVolunteer(_Volunteer);
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
        public async Task<bool> Testfor_Delete_Budget()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 volunteerservice.Setup(repos => repos.DeleteVolunteer(_Volunteer.VolunteerId)).Returns(_Volunteer);
                var result= _volunteerService.DeleteVolunteer(_Volunteer.VolunteerId);

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