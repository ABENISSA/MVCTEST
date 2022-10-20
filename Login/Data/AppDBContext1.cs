using System;
using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

#nullable disable

namespace Login.Data
{
    public partial class AppDBContext1 : IdentityDbContext
    {
         public AppDBContext1(DbContextOptions<AppDBContext1> options)
            : base(options)
        {
        }
        // to create the table after build the modual you have to create a constractor to be build in the databas
        
    }
}

