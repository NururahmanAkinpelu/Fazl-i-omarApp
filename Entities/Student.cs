using Backend.Contract;
using Backend.Identity;

namespace Backend.Entities
{
    public class Student: AuditableEntity
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string StudentId{get;set;}
        public string Email { get;set;}
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public IList<StudentSubject> StudentSubjects { get; set; }
    }
}