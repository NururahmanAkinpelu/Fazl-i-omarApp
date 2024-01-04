using Backend.Contract;
using Backend.Identity;

namespace Backend.Entities
{
    public class Teacher:AuditableEntity
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email { get;set;}
        public string TeacherId{get;set;}
        public User User { get; set; }
        public Guid UserId { get; set; }
        public IList<TeacherSubject> TeacherSubjects {get;set;}
    }
}