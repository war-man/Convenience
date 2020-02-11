﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.data.Infrastructure
{
    public class ApplicationDbSeed
    {
        public static void InitialApplicationDataBase(ApplicationDbContext dbContext,
            IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var user = new ApplicationUser
            {
                UserName = $"admin",
            };
            userManager.CreateAsync(user, "admin").Wait();
        }
    }
}