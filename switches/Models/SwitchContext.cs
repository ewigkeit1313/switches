using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Switches.Models
{
    public class SwitchContext : DbContext
    {

        public SwitchContext(): base("DBConnection")
        { }

        public DbSet<Switch> Switches { get; set; }
    }
}