using AdminPanelLesson.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminPanelLesson
{
    public class SecurityContext : DbContext
    {
        public SecurityContext() : base("SecurityContext")
        {}

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Employee> Employeers { get; set; }
    }
}