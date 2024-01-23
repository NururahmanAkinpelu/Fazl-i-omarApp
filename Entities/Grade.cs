using Backend.Contract;

namespace Backend.Entities
{
    public class Grade : AuditableEntity
    {
        public string GradeName { get; set; }
    }
}