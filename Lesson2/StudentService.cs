using Lesson2.DAL.Enteties;
using Lesson2.DAL;
using Microsoft.EntityFrameworkCore;

public class StudentService
{
    private StudentRepository _studentRepository;
    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }

    public List<Student> GetAll()
    {
        return _studentRepository.GetAll().ToList();
    }

    public List<Student> GetAllById(int id)
    {


        return _studentRepository.GetAll()
                                    .Where(s => s.Id == id)
                                    .ToList();
    }

    public List<Student> GetAllByName(string name)
    {
        return _studentRepository.GetAll()
                                    .Where(s => s.Name == name)
                                    .ToList();
    }

    public Student? GetByName(string name)
    {
        return _studentRepository.GetAll()
                                    .FirstOrDefault(s => s.Name == name);
    }

    public void Add(Student students)
    {
        _studentRepository.Add(students);
    }
    public void AddRange(List<Student> students)
    {
        _studentRepository.AddRange(students);
    }
    public void DeleteById(int id)
    {
        var res = _studentRepository.GetAll()
                                        .FirstOrDefault(s => s.Id == id);
        _studentRepository.Delete(res);
    }
    public void DeleteByName(string name)
    {
        var res = _studentRepository.GetAll()
                                        .FirstOrDefault(s => s.Name == name);
        _studentRepository.Delete(res);
    }
    public void DeleteByDesc(string desc)
    {
        var res = _studentRepository.GetAll()
                                        .FirstOrDefault(s => s.Description == desc);
        _studentRepository.Delete(res);
    }
    public void UpdateName(int id, string name)
    {
        var res = _studentRepository.GetAll()
                                        .FirstOrDefault(s => s.Id == id);
        res.Name = name;
        _studentRepository.Update(res);
    }
    public void UpdateDesc(int id, string desc)
    {
        var res = _studentRepository.GetAll()
                                        .FirstOrDefault(s => s.Id == id);
        res.Description = desc;
        _studentRepository.Update(res);
    }
}