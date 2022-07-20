using Models;
using DataAccess;
using services;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

System.Console.WriteLine("Welcome \nNew User [1] \nLog in [2]");

UserService BillsService = new UserService();
int response1 = Convert.ToInt32(Console.ReadLine());
User WilliamConrad = new User();

if(response1 == 1){
    System.Console.WriteLine("Create your username:");
    String enterusername = Console.ReadLine();
    WilliamConrad.username = enterusername;

    System.Console.WriteLine("Create your password:");
    String enterpassword = Console.ReadLine();
    WilliamConrad.password = enterpassword;

    System.Console.WriteLine("Employee [1]\n Manager [2]");
    int roleresponse = Convert.ToInt32(Console.ReadLine());
        if(roleresponse == 1){
            WilliamConrad.role = "Employee";
        }
        else if (roleresponse == 2){
            WilliamConrad.role = "Manager";
        }
        int b = BillsService.CreateUser(WilliamConrad);
        if(b > 0)
            System.Console.WriteLine("Success");
        else
            System.Console.WriteLine("Fail");
}


else if (response1 == 2){
        Console.WriteLine("Enter your Username:");
            string usernameresponse = Console.ReadLine();
            Console.WriteLine("Enter your Password:");
            string passwordresponse = Console.ReadLine();
            User dummyuser = new User();
            dummyuser.username = usernameresponse;
            dummyuser.password = passwordresponse;
            AuthService authserv = new AuthService();
            authserv.Login(dummyuser);





}





//UserService fields = new UserService();
//System.Console.WriteLine(fields.getUserByUsername("dummyManager"));






/*
TicketRepository ticketrepos = new TicketRepository();

Ticket mayno = new Ticket(3, 2, 2, " cand", "blah", 2.3);


System.Console.WriteLine(ticketrepos.UpdateTicket(mayno));

/*UserRepository UserRepository = new UserRepository();
List<User> blanklist = new List<User>();


blanklist = UserRepository.GetAllUsers();
Console.WriteLine(blanklist[0].password);

for ( int i = 0 ; i < blanklist.Count ; i ++ ){
        System.Console.WriteLine(blanklist[i].username + " " + blanklist[i].password + " " + blanklist[i].role);
    }


System.Console.WriteLine(UserRepository.GetUserById(1).ID);
    
    User james = new User("street sweep", "over", "skidrow1414", 528 );


    UserRepository.CreateUser(james);
        User dummymanager = new User("dummymanager", "dummymanager", "Dummymanager", 2);

    System.Console.WriteLine(UserRepository.GetUserByUsername(dummymanager.username).password); */