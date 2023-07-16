using System.ComponentModel.DataAnnotations;

namespace CRUDPractice
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        //public Student()
        //{
        //    Id = id;
        //    Name = name;
        //    Department = department;
        //}

        public Student()
        {
        }
    }
}