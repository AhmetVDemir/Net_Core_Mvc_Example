using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC.Models
{
    public class SinavContext:DbContext
    {
        public SinavContext(DbContextOptions<SinavContext> options):base(options)
        {

        }

        public DbSet<Zaman> Zamans { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Admin> Admins { get; set; }

    }
}
