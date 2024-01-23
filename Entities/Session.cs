using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Contract;

namespace Backend.Entities
{
    public class Session : AuditableEntity
    {
        public string SessionName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentSession { get; set; }
    }
}