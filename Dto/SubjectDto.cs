using Backend.Entities;
using Backend.Identity;

namespace Backend.Dto
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set; }
        public int LevelId { get; set; }
        public int UserId { get; set; }
        public IList<StudentSubject> StudentSubjects { get; set; }
    }
}