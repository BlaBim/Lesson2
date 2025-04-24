using Lesson2.DAL.Enteties;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class ServiceMenu
    {
        private StudentService _StudentService; 
        public ServiceMenu()
        {
           _StudentService = new StudentService();
        }
        public void Start()
        {
            //var context = new AppDbContext();
            bool cond = true;

            while (cond)
            {
                Console.WriteLine("1. Show all students");
                Console.WriteLine("2. Add new student");
                Console.WriteLine("3. Delete by id");
                Console.WriteLine("4. Delete by Name");
                Console.WriteLine("5. Delete by Description");
                Console.WriteLine("6. Update Name");
                Console.WriteLine("7. Update Description");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choise: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var students = _StudentService.GetAll();
                        foreach (var student in students)
                        {
                            Console.WriteLine($"ID: {student.Id} \t Name: {student.Name} \t Description: {student.Description}");
                        }
                        break;
                    case "2":
                        string name = ConsoleEnter("Enter students name: ");
                        string description = ConsoleEnter("Enter students description to delete: ");

                        var newStudent = new Student
                        {
                            Name = name,
                            Description = description
                        };
                        _StudentService.Add(newStudent);
                        Console.WriteLine("Student added");
                        break;
                    case "3":
                        int id = ConsoleEnterInt("Enter students id to Update");
                        _StudentService.DeleteById(id);
                        break;
                    case "4":
                        string nameDEL = ConsoleEnter("Enter students name to delete: ");
                        _StudentService.DeleteByName(nameDEL);
                        break;
                    case "5":
                        string desc = ConsoleEnter("Enter students description to delete: ");
                        _StudentService.DeleteByDesc(desc);
                        break;
                    case "6":
                        int idUPD = ConsoleEnterInt("Enter students id to Update");
                        string nameUPD = ConsoleEnter("Enter new students name : ");
                        _StudentService.UpdateName(idUPD ,nameUPD);
                        break;
                    case "7":
                        int idUPD2 = ConsoleEnterInt("Enter students id to Update");
                        string descUPD2 = ConsoleEnter("Enter new students description : ");
                        _StudentService.UpdateDesc(idUPD2, descUPD2);
                        break;
                    case "9":
                        cond = false;
                        break;
                    default:
                        Console.WriteLine("Eror choise");
                        break;
                }
            }
        }
        private string ConsoleEnter(string Text)
        {
            Console.Write($"{Text}");
            string value = Console.ReadLine();
            return value;
        }
        private int ConsoleEnterInt(string Text)
        {
            Console.Write($"{Text}");
            string value = Console.ReadLine();
            int.TryParse(value, out int result);
            return result;
        }
    }
    }
