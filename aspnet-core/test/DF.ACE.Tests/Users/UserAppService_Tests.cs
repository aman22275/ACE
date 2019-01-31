using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using DF.ACE.Users;
using DF.ACE.Users.Dto;
using DF.ACE.AdditionalUserProfile;
using DF.ACE.AdditionalUserProfile.Dto;
using DF.ACE.Roles;
using DF.ACE.Roles.Dto;
using System.Collections.Generic;

namespace DF.ACE.Tests.Users
{
    public class UserAppService_Tests : ACETestBase
    {
        private readonly IUserAppService _userAppService;

        private readonly AdditionalUserProfileAppService _additionalUserAppService;

        private readonly IRoleAppService _roleAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
            _additionalUserAppService = Resolve<AdditionalUserProfileAppService>();
            _roleAppService = Resolve<IRoleAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAll(new PagedResultRequestDto{MaxResultCount=20, SkipCount=0} );

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.Create(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task Can_Create_User_With_Additional_Data()
        {
            //Arrange
            var combinedUserData = new CreateCombinedUserAndProfileDto{};
            combinedUserData.CreateUserDto = new CreateUserDto
            {
                EmailAddress = "john1@volosoft1.com",
                IsActive = true,
                Name = "John1",
                Surname = "Nash1",
                Password = "123qwe",
                UserName = "john1.nash1"
            };

            combinedUserData.CreateAdditionalUserProfileDto = new CreateAdditionalUserProfileDto
            {
                Line1 = "98 Hardware Lane",
                City = "Melbourne",
                State = "Victoria",
                Country = "Australia",
                ZipCode = "3000"
            };

            //Act
            await _additionalUserAppService.CreateProfileWithAddition(combinedUserData);

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser1 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john1.nash1");
                var id = johnNashUser1.Id;
                var johnNashAdditionalInfo = await context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == id);

                // Assert
                johnNashUser1.ShouldNotBeNull();
               
                johnNashAdditionalInfo.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task Can_Edit_Profile()
        {
            //Arrange
            var combinedUserData = new CreateCombinedUserAndProfileDto { };
            combinedUserData.CreateUserDto = new CreateUserDto
            {
                EmailAddress = "peter@last.com",
                IsActive = true,
                Name = "Peter",
                Surname = "Last",
                Password = "123qwe",
                UserName = "peter.last"
            };

            combinedUserData.CreateAdditionalUserProfileDto = new CreateAdditionalUserProfileDto
            {
                Line1 = "98 Hardware Lane",
                City = "Melbourne",
                State = "Victoria",
                Country = "Australia",
                ZipCode = "3000"
            };
 
            await _additionalUserAppService.CreateProfileWithAddition(combinedUserData);

            var combinedUserDataEdited = new CombinedUserProfileDto { };
            combinedUserDataEdited.UserDto = new UserDto
            {
                EmailAddress = "peterEdit@last.com",
                IsActive = false,
                Name = "PeterEdit",
                Surname = "LastEdit",
                UserName= "peter.last"
            };

            combinedUserDataEdited.AdditionalUserProfileDto = new AdditionalUserProfileDto
            {
                Line1 = "98 Hardware Lane Edit",
                City = "Melbourne Edit",
                State = "Victoria Edit",
                Country = "Australia Edit",
                ZipCode = "930009"
            };

            //Act
            await UsingDbContextAsync(async context =>
            {
                var peterLastUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "peter.last");
                combinedUserDataEdited.UserDto.Id = peterLastUser.Id;
            });

            await _additionalUserAppService.UpdateProfileWithAddition(combinedUserDataEdited);

            await UsingDbContextAsync(async context =>
            {
                var peterLastUserEdited = await context.Users.FirstOrDefaultAsync(u => u.UserName == "peter.last");
                var peterLastAdditionalInfoEdeited = await context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == peterLastUserEdited.Id);

                //Assert
                peterLastUserEdited.Name.ShouldNotBeSameAs(combinedUserData.CreateUserDto.Name);
                peterLastUserEdited.Surname.ShouldNotBeSameAs(combinedUserData.CreateUserDto.Surname);
                peterLastUserEdited.EmailAddress.ShouldNotBeSameAs(combinedUserData.CreateUserDto.EmailAddress);
                peterLastUserEdited.IsActive.ShouldNotBeSameAs(combinedUserData.CreateUserDto.IsActive);
                peterLastAdditionalInfoEdeited.Line1.ShouldNotBeSameAs(combinedUserData.CreateAdditionalUserProfileDto.Line1);
                peterLastAdditionalInfoEdeited.City.ShouldNotBeSameAs(combinedUserData.CreateAdditionalUserProfileDto.City);
                peterLastAdditionalInfoEdeited.State.ShouldNotBeSameAs(combinedUserData.CreateAdditionalUserProfileDto.State);
                peterLastAdditionalInfoEdeited.Country.ShouldNotBeSameAs(combinedUserData.CreateAdditionalUserProfileDto.Country);
                peterLastAdditionalInfoEdeited.ZipCode.ShouldNotBeSameAs(combinedUserData.CreateAdditionalUserProfileDto.ZipCode);
            });
        }

        [Fact]
        public async Task Can_Delete_Profile()
        {
            //Arrange
            var combinedUserData = new CreateCombinedUserAndProfileDto { };
            combinedUserData.CreateUserDto = new CreateUserDto
            {
                EmailAddress = "peterDelete@last.com",
                IsActive = true,
                Name = "Peter",
                Surname = "Last",
                Password = "123qwe",
                UserName = "peterDelete.last"
            };

            combinedUserData.CreateAdditionalUserProfileDto = new CreateAdditionalUserProfileDto
            {
                Line1 = "98 Hardware Lane",
                City = "Melbourne",
                State = "Victoria",
                Country = "Australia",
                ZipCode = "3000"
            };

            await _additionalUserAppService.CreateProfileWithAddition(combinedUserData);

            var Id = new EntityDto<long>();

            await UsingDbContextAsync(async context =>
            {
                var peterLastUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "peterDelete.last");
                var peterLastAdditionalInfo = await context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == peterLastUser.Id);

                peterLastUser.ShouldNotBeNull();
                peterLastAdditionalInfo.ShouldNotBeNull();

                Id.Id = peterLastUser.Id;
            });

            //Act
            await _additionalUserAppService.DeleteProfileWithAddition(Id);

            await UsingDbContextAsync(async context =>
            {
                var peterLastUserCheck = await context.Users.FirstOrDefaultAsync(u => u.UserName == "peterDelete.last");

                //Assert
                peterLastUserCheck.IsDeleted.ShouldBeTrue();
            });
        }

        [Fact]
        public async Task Can_Create_Role()
        {
            //Act
            await _roleAppService.Create(
                new CreateRoleDto
                {
                    Name = "TestRole",
                    DisplayName = "Test Role",
                    Description = "Test Role Description",
                    Permissions = new List<string>{"Users","Roles"}
                });

            await UsingDbContextAsync(async context =>
            {
                var testRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "TestRole");

                //Assert
                testRole.ShouldNotBeNull();
            });
        }


        [Fact]
        public async Task Can_Edit_Role()
        {
            //Arrange
            var roleId = 0;
            var createRole = new  CreateRoleDto
            {
                Name = "TestRoleForEdit",
                DisplayName = "Test Role For Edit",
                Description = "Test Role For Edit Description",
                Permissions = new List<string> { "Users", "Roles", "Tenants" }
            };

            await _roleAppService.Create(createRole);

            await UsingDbContextAsync(async context =>
            {
                var testRoleForEdit = await context.Roles.FirstOrDefaultAsync(r => r.Name == "TestRoleForEdit");

                roleId = testRoleForEdit.Id;
                testRoleForEdit.ShouldNotBeNull();
            });

            var testRoleEdited = new RoleDto
            {
                Id = roleId,
                Name = "TestRoleForEdit",
                DisplayName = "Test Role Edited For Edit",
                Description = "Test Role For Edit Edited Description",
                Permissions = new List<string> { "Users", "Roles" }
            };

            await _roleAppService.Update(testRoleEdited);

            //Act
            await UsingDbContextAsync(async context =>
            {
                var testRoleDidEdit = await context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

                //Assert
                testRoleDidEdit.DisplayName.ShouldNotBeSameAs(createRole.DisplayName);
                testRoleDidEdit.Description.ShouldNotBeSameAs(createRole.Description);
                testRoleDidEdit.Permissions.ShouldNotBeSameAs(createRole.Permissions);
            });  
        }   

        [Fact]
        public async Task Can_Delete_Role()
        {
            //Arrange
            var idToDelete = new EntityDto<int>();

            await _roleAppService.Create(
                new CreateRoleDto
                {
                    Name = "TestRoleForDelete",
                    DisplayName = "Test Role For Delete",
                    Description = "Test Role Description For Delete",
                    Permissions = new List<string> { "Users", "Roles" }
                });

            await UsingDbContextAsync(async context =>
            {
                var testRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "TestRoleForDelete");
                testRole.ShouldNotBeNull();

                idToDelete.Id = testRole.Id;
            });

            //Act
            await _roleAppService.Delete(idToDelete);

            await UsingDbContextAsync(async context =>
            {
                var testRoleDeleted = await context.Roles.FirstOrDefaultAsync(r => r.Id == idToDelete.Id);

                //Assert
                testRoleDeleted.IsDeleted.ShouldBeTrue();
            });

        }
    }
}
