using MaintainContacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaintainContacts.Services
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatuses();
        string GetStatusCodeByID(int id);
        List<SelectListItem> GetAllStatusesWithSelectedByID(int id = -1);
    }
}
