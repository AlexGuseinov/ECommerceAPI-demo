using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class SchoolContext:DbContext
    {
      public SchoolContext():base() { }
    public DbSet<Person> peope { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Entrollment> Entrollments{ get; set; }




  }
}
