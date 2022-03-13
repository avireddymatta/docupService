using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;

namespace Persistence.SeedData
{
    public class UserDataSeed
    {
        public static async Task SetUserDataSeed(DocUpContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {

                var userList = new List<User>(){
                    new User(){UserName = "johndoe", Email = "johndoe@test.com"},
                    new User(){UserName = "creed", Email = "creed@test.com"},
                    new User(){UserName = "davinci", Email = "davinci@test.com"},
                    new User(){UserName = "lee", Email = "lee@test.com"}
                };

                foreach (var user in userList)
                {
                    await userManager.CreateAsync(user, "Qwerty@123");
                }
            }

        }
    }
}