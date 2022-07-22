using Models;
using DataAccess;
using services;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

System.Console.WriteLine("Welcome \nNew User [1] \nLog in [2] \nExit [3]");

UserService BillsService = new UserService();
TicketServices BillsTix = new TicketServices();
int response1 = Convert.ToInt32(Console.ReadLine());
User WilliamConrad = new User();
User dummyuser = new User();

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
        if(b > 0){
            System.Console.WriteLine("Success");
            if(WilliamConrad.role == "Manager")
                mainmenumanager(WilliamConrad);}
            else if (WilliamConrad.role == "Employee"){
                mainmenuemployee(WilliamConrad);
            }
            
                
            
        else
            System.Console.WriteLine("Fail");

}

else if (response1 == 2){
        Console.WriteLine("Enter your Username:");
            string usernameresponse = Console.ReadLine();
            Console.WriteLine("Enter your Password:");
            string passwordresponse = Console.ReadLine();
            dummyuser = new User();
            dummyuser.username = usernameresponse;
            dummyuser.password = passwordresponse;
            AuthService authserv = new AuthService();
            dummyuser = authserv.Login(dummyuser);
           // Console.WriteLine(dummyuser.username);
           // Console.WriteLine(dummyuser.password);
            //Console.WriteLine(dummyuser.role);
            if(dummyuser.role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                mainmenumanager(dummyuser);
            }
            else
            {
                mainmenuemployee(dummyuser);
            }
            

}

else if (response1 == 3){
        System.Console.WriteLine("You have exited the program");
        Environment.Exit(0);


}

            void mainmenumanager(User link){
                int selection = 0;
                TicketServices t = new TicketServices();

            if(link.role.Equals("manager", StringComparison.OrdinalIgnoreCase))
            {
                do{
                    Console.WriteLine("");
                Console.WriteLine("Welcome, " + link.username);
                System.Console.WriteLine("Review Reimbursement Tickets [1]\nExit Program [2]");
                selection = Convert.ToInt32(Console.ReadLine());
                List<Ticket> tlist= new List<Ticket>();
                tlist = t.GetAllTickets();
                    if(selection == 1)
                    {
                        System.Console.WriteLine("Ticket ID " + "Author " + "Description  " + "Status " + "Amount ");
                        System.Console.WriteLine("================================================================");
                        for(int i = 0; i< tlist.Count(); i++)
                        {
                            System.Console.WriteLine(tlist[i].ID + "  " + tlist[i].authorid + "  " + tlist[i].reason + "  " + tlist[i].status + "  " + tlist[i].amount);
                            ;
                        }
                        System.Console.WriteLine("================================================================");
                        System.Console.WriteLine("");
                        //Console.ReadLine();

                        int gorgon = 0;
                        System.Console.WriteLine("Enter ID of Ticket you'd like to process:");
                        int ticketentry = Convert.ToInt32(Console.ReadLine());
                        Ticket thatticket = new Ticket();
                        thatticket = t.GetTicketsByID(ticketentry);
                        System.Console.WriteLine("Approve [1]\nDeny [2]");
                        gorgon = Convert.ToInt32(Console.ReadLine());
                        if(gorgon == 1){
                            //Ticket chenrez = new Ticket();
                            thatticket.status = "approved";
                            t.UpdateTicket(thatticket);
                        }
                        else if (gorgon == 2){
                          //  Ticket cheesepurohg = new Ticket();
                            thatticket.status = "denied";
                            t.UpdateTicket(thatticket);
                        }
                        
                        
                    }
                        
                } while (selection != 2);


            }

            
}

void mainmenuemployee (User zeld)
            {
                    int response2 = 0;
                    while(response2 == 1 || response2 == 2 || response2 == 0)
                    {
                    System.Console.WriteLine("");
                    System.Console.WriteLine("Welcome, " + zeld.username);
                    System.Console.WriteLine("Submit Ticket [1]\nReview Submitted Tickets [2]");
                    response2 = Convert.ToInt32(Console.ReadLine());
                    if(response2 == 1){
                    System.Console.WriteLine("Enter your reason for your request:");
                    string reasonresponse = Console.ReadLine();
                    Ticket theticket = new Ticket();
                    theticket.reason = reasonresponse;
                    System.Console.WriteLine("Enter Reimbursement amount:");
                    int amountresponse = Convert.ToInt32(Console.ReadLine());
                    theticket.amount = amountresponse;
                    theticket.authorid = zeld.ID;
                    theticket.resolverid = 1;
                    theticket.status = "unprocessed";
                    BillsTix.CreateTicket(theticket);
                    System.Console.WriteLine("Thank you for your Submission");
                    }

                    }

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