using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainContacts.Entities
{
    [Table("TblLookupStatus")]
    public class Status
    {
        public int StatusID { get; set; }

        [Display(Name = "Status")]
        public string StatusCode { get; set; }
    }
}
