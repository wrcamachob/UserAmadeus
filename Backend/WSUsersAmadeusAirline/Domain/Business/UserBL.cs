using Domain.Interfaces;
using Domain.Models;
using Infraestructure.Entities;
using Infraestructure.Interfaces;
using Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
    public class UserBL : IUsersBL<UsersModel>
    {
        private IUsers users;

        public UserBL(IConfiguration config)
        {
            users = new UsersRepository(config);
        }

        public async Task<IEnumerable<UsersModel>> GetAll()
        {
            var usersDataModel = await users.GetAllUsers();
            var listUserModel = new List<UsersModel>();
            foreach (UsersAmadeus user in usersDataModel)
            {                
                listUserModel.Add(new UsersModel
                {
                    IDIdentifier = user.IDIdentifier,
                    Name = user.Name,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,                    
                    Email = user.Email,
                    DateOfBirthday = user.DateOfBirthday,
                    Salary = user.Salary
                });
            }
            return listUserModel;
        }

        public async Task<IEnumerable<UsersModel>> GetByID(long Id)
        {
            var usersDataModel = await users.GetByID(Id);
            var listUserModel = new List<UsersModel>();
            foreach (UsersAmadeus user in usersDataModel)
            {
                listUserModel.Add(new UsersModel
                {
                    IDIdentifier = user.IDIdentifier,
                    Name = user.Name,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    DateOfBirthday = user.DateOfBirthday,
                    Salary = user.Salary
                });
            }
            return listUserModel;
        }

        public async Task<string> Insert(UsersModel userM)
        {
            string message;
            try
            {
                var userMod = new UsersAmadeus
                {
                    Email = userM.Email,
                    IDIdentifier = userM.IDIdentifier,
                    Name = userM.Name,
                    LastName = userM.LastName,
                    PhoneNumber = userM.PhoneNumber,
                    DateOfBirthday = userM.DateOfBirthday,
                    Salary = userM.Salary                    
                };
                _ = await users.Add(userMod);
                message = "Successfully record";
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
                {
                    message = "Duplicated register";
                }
                else
                {
                    message = ex.ToString();
                }
            }
            return message;
        }

        public async Task<string> Update(UsersModel userM)
        {
            string message;
            try
            {
                var userMod = new UsersAmadeus
                {
                    Email = userM.Email,
                    IDIdentifier = userM.IDIdentifier,
                    Name = userM.Name,
                    LastName = userM.LastName,
                    PhoneNumber = userM.PhoneNumber,
                    DateOfBirthday= userM.DateOfBirthday,
                    Salary = userM.Salary
                };
                _ = await users.Update(userMod);
                message = "Successfully edited";
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
                {
                    message = "Duplicated register";
                }
                else
                {
                    message = ex.ToString();
                }
            }
            return message;
        }

        public async Task<string> Delete(long id)
        {
            string message;
            var userMod = new UsersAmadeus
            {
                IDIdentifier = id,
            };
            _ = await users.Delete(userMod.IDIdentifier);
            message = "Successfully deleted";
            return message;
        }
    }
}
