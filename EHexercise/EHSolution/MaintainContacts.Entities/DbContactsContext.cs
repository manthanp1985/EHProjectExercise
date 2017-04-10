using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainContacts.Entities
{
    public class DbContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
