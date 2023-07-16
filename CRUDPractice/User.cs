using System.ComponentModel.DataAnnotations;

namespace CRUDPractice
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string Userrole { get; internal set; }

        public User(int id, string username, string password, string userrole)
        {
            Id = id;
            Username = username;
            Password = password;
            Userrole = userrole;
        }

        //public User(int id, string username, string password, string userrole)
        //{
        //    id = 0;
        //    username = "admin";
        //    password = "123";
        //    userrole = "Admin";
        //}

        public User()
        {
        }

    }
    
}