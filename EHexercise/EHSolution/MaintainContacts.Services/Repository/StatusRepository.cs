using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainContacts.Entities;
using System.Web.Mvc;

namespace MaintainContacts.Services
{
    public class StatusRepository : CommonServices, IStatusRepository
    {
        /// <summary>
        /// Get all Statuses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Status> GetAllStatuses()
        {
            return db.Statuses.ToList();
        }
        
        /// <summary>
        /// Get Status Code by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetStatusCodeByID(int id)
        {
            return db.Statuses.SingleOrDefault(s => s.StatusID == id).StatusCode;
        }

        /// <summary>
        /// Get All Statuses with selected status using ID
        /// Used for Dropdown and radiobutton controls
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SelectListItem> GetAllStatusesWithSelectedByID(int id = -1)
        {
            return db.Statuses.Select(s => new SelectListItem { Text = s.StatusCode, Value = s.StatusID.ToString(), Selected = s.StatusID == id ? true : false }).ToList();
        }
    }
}
