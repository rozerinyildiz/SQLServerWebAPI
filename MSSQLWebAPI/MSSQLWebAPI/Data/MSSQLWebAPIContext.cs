using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSSQLWebAPI.Models;

namespace MSSQLWebAPI.Data
{
    public class MSSQLWebAPIContext : DbContext
    {
        public MSSQLWebAPIContext (DbContextOptions<MSSQLWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MSSQLWebAPI.Models.User> User { get; set; } = default!;
        public DbSet<MSSQLWebAPI.Models.Customer> Customer { get; set; } = default!;
        public DbSet<MSSQLWebAPI.Models.Device> Device { get; set; } = default!;
        public DbSet<MSSQLWebAPI.Models.DeviceLocation> DeviceLocation { get; set; } = default!;
    }
}
