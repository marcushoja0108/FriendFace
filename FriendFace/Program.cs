using System.Reflection.Metadata;
using FriendFace;

User loggedInUser = null;
User Users = new User ();
Users.loadDummyData();
Displays display = new Displays();


while(true)
{
    if(loggedInUser == null)
    {
        display.StartPage();
        string startSelect = Console.ReadLine();
        switch(startSelect)
        {
            case "1":
                Console.Write("Type your email: ");
                string userEmail = Console.ReadLine();
                Console.Write("Type your password: ");
                string userPassword = Console.ReadLine();
                Users.Login(userEmail, userPassword);
                loggedInUser = Users.GetUser(userEmail, userPassword);

                //int userID = Convert.ToInt32(Console.ReadLine());
                //loggedInUser = Users.GetUser(userID);
                if (loggedInUser != null)
                {
                    loggedInUser.loadDummyData();
                    display.LoggingIn(loggedInUser.Name);
                    Thread.Sleep(300);
                }

                break;
            case "2":
                Users.registerPage();
                break;
        }
        
    }
    else
    {
        display.mainMenu();
        int userinput = Convert.ToInt32(Console.ReadLine());
        switch (userinput)
        {
            case 1:
                loggedInUser.ShowUsers();
                Console.WriteLine("Type the name of the person you want to add as a friend");
                string addFriendName = Console.ReadLine();
                loggedInUser.addFriend(addFriendName);
                break;
            case 2:
                loggedInUser.ShowFriends();
                display.FriendDisplay();
                string select = Console.ReadLine();
                switch(select)
                {
                    case "1":
                        Console.WriteLine("Type the name of the friend you want to view");
                        string friendSelect = Console.ReadLine();
                        loggedInUser.ShowUser(friendSelect);
                        break;
                    case "2":
                        Console.WriteLine("Type the name of the friend you want to remove");
                        friendSelect = Console.ReadLine();
                        loggedInUser.RemoveFriend(friendSelect);
                        break;
                }
                break;
            case 3:
                display.LoggingOut(loggedInUser);
                loggedInUser = null;
                break;
        }

    }
}