using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLudoGame.Classes
{
    internal class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlServer(@"Data Source=den1.mssql8.gear.host;Initial Catalog=dbtheludogame;User id=dbtheludogame;password=Ip5ych-!9Vb1;");
        }
    }
}