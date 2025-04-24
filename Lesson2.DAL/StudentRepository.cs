using Lesson2.DAL.Enteties;


namespace Lesson2.DAL
{
    public class StudentRepository { 

        private readonly AppDbContext _context;

        public StudentRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Student> GetAll()
        {
           return _context.Students;
        }
        
        public Student GetByName(string name)
        {
            return _context.Students.FirstOrDefault(s => s.Name == name);
        }

       

        //public void Delete(Student student)
        //{ 
        //    _context.Students.Remove(student);
        //    _context.SaveChanges();
        //}
        //public void Update(List<Student> student)
        //{
        //    _context.Students.UpdateRange(student);
        //    _context.SaveChanges();
        //}
        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void AddRange(List<Student> students)
        {
            _context.Students.AddRange(students);
            _context.SaveChanges();
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void DeleteRange(List<Student> students)
        {
            _context.Students.RemoveRange(students);
            _context.SaveChanges();
        }
        public void Delete(Student students)
        {
            _context.Students.Remove(students);
            _context.SaveChanges();
        }
    }

   
}
