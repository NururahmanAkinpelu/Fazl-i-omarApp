using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dto
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public string SessionName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentSession { get; set; }
    }
}