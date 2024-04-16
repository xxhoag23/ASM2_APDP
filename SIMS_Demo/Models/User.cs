using System;
namespace SIMS_Demo.Models
{
    public class User
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String PassWord { get; set; }
        public String Role { get; set; }
        public User()
        { 

        }

        public User(int id, string userName, string passWord, string role)
        {
            Id = id;
            UserName = userName;
            PassWord = passWord;
            Role = role;
        }
    }
    
}

