using MaintainContacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainContacts.Services
{
    public class CommonServices
    {
        public DbContactsContext db = new DbContactsContext();
        public LoggerRepository logger = new LoggerRepository();
    }
}
