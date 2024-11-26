using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int UserID { get; set; }
        public List<User> friends { get; set; }


        public User(string name, string password, string email, int age, string country, int userID)
        {
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            Country = country;
            UserID = userID;
            friends = new List<User>();
            
        }
        public User()
        {
            
        }

        public List<User> Users = new List<User>();

        public List<User> GetUsers()
        {
            return Users;
        }

        public void Login(string email, string password)
        {
            foreach(var user in Users)
            {
                if(user.Email == email)
                {
                    if(user.Password == password)
                    {
                        Console.WriteLine("Success!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password");
                        return;
                    }
                }
            }
            Console.WriteLine("No user found with that email");
        }

        public void ShowUsers()
        {
            foreach(var user in Users)
            {
                Console.WriteLine();
                Console.WriteLine("Name:" + user.Name);
            }
        }
        public void loadDummyData()
        {
            User user1 = new User("Marcus", "123", "marcus@mail.com", 27, "Norway", 0);
            User user2 = new User("Mikael", "123", "mikael@mail.com", 24, "Norway", 1);
            User user3 = new User("Lisa", "123", "lisa@mail.com", 25, "England", 2);
            User user4 = new User("Jorge", "123", "jorge@mail.com", 30, "Spain", 3);

            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
            Users.Add(user4);

            user1.friends.Add(user2);
            user2.friends.Add(user1);
        }

        public void registerPage()
        {
            Console.WriteLine("    Register new user");
            Console.Write("Name:  ");
            string newUserName = Console.ReadLine();
            Console.Write("Password:  ");
            string newUserPassword = Console.ReadLine();
            Console.Write("email:  ");
            string newUserEmail = Console.ReadLine();
            Console.Write("Age:  ");
            int newUserAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Country:  ");
            string newUserCountry = Console.ReadLine();
            

            User newUser = new User(newUserName, newUserPassword, newUserEmail, newUserAge, 
                newUserCountry, Users.Count);
            Users.Add(newUser);
        }
        
        public User GetUser(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                    return user;
            }
            return null;
        }
        public void ShowUser(string username)
        {
            foreach(User user in Users)
            {
                if(user.Name == username)
                {
                    Console.WriteLine();
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.Age);
                    Console.WriteLine(user.Country);
                    Console.WriteLine(user.Email);
                    return;
                }
            }
            Console.WriteLine("No friend found by that name");

        }
        public List<User> GetFriends()
        {
            return friends;
        }

        public void ShowFriends()
        {
            if(friends.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You do not currently have any friends in your friendslist!");
            }
            foreach(var friend in friends)
            {
                Console.WriteLine();
                Console.WriteLine(friend.Name);
            }
        }
        public void addFriend(string friendName)
        {
            foreach (var user in Users)
            {
                if (friendName == user.Name)
                {
                    friends.Add(user);
                    Console.WriteLine($"{user.Name} was added to your friends list!");
                    return;
                }
            }
            Console.WriteLine("No user with that name was found, please check your spelling");
        }
        public void RemoveFriend(string friendSelect)
        {
            for(int i = 0; i < friends.Count; i++)
            {
                if(friendSelect == friends[i].Name)
                {
                    Thread.Sleep(400);
                    Console.WriteLine($"{friends[i].Name} has been removed from your friendslist!");
                    friends.Remove(friends[i]);
                }
            }
        }
    }
}
