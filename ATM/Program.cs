public class cardHolder
{
    string cardNum;
    string fName;
    string lName;
    int pin;
    double balance;

    // creating a constructer
    public cardHolder (string cardNum, string fName, string lName, int pin, double balance) //passing in 
    {
        //instantiating : 
        this.cardNum = cardNum;
        this.fName = fName;
        this.lName = lName;
        this.pin = pin;
        this.balance = balance;
    }


   //setting up getters for the properties above:
    public string getNum()
    {
        return cardNum;
    }

    public string getFName()
    {
        return fName;
    }

    public string getLName()
    {
        return lName;
    }

    public int getPin()
    {
        return pin;
    }

    public double getBalance()
    {
        return balance;
    }

    //creating setters
    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setFName(string newFName)
    {
        fName = newFName;
    }

    public void setLName(string newLName)
    {
        lName = newLName;
    }

    public void setPin (int newPin)
    {
        pin = newPin;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }



    //Main Method to run the ATM
    public static void Main(string[] args)
    {
        // a funiction to show user opitions:
        void printOptions()
        {
            Console.WriteLine("Please Select from one of the following opitons...");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
        }

        //This funiction handles deposites
        void deposit(cardHolder currentUser)
        {
            
            try
            {
                Console.WriteLine("How much would you like to deposit? ");
                double deposit = Double.Parse(Console.ReadLine());

                currentUser.setBalance(currentUser.getBalance() + deposit);

                if (deposit == null)
                {
                    Console.WriteLine("How much would you like to deposit? ");
                }
                else if (deposit == 0)
                {
                    Console.WriteLine("How much would you like to deposit? ");
                }
                else { Console.WriteLine("Thank you for your deposit. Your current balance is: " + currentUser.getBalance()); }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
          

        }

        // now a funcition for withdraws
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to Withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // System to check if balance can handle the withdraw amount
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Withdraw was successful, Current Balance: " + currentUser.getBalance());
            }

        }

        // funcition for balance
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance:" + currentUser.getBalance());
        }

        //creating card holders since we dont have a DB
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1122334455", "John", "Doe", 1452, 358.20));
        cardHolders.Add(new cardHolder("5566778899", "Phil", "Smith", 7894, 120.25));
        cardHolders.Add(new cardHolder("7711993355", "Mary", "Holy", 5896, 1000.89));
        cardHolders.Add(new cardHolder("1155997733", "Jane", "Doe", 1739, 854.00));

        //prompt the User
        Console.WriteLine("Welcome to the ATM");
        Console.WriteLine("Please insert your debit card: ");
        //intake the "debit care"
        string debitCardNum = "";
        cardHolder currentUser;


        // protect the program from wrong card  and not crash program
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check the DataBase if We had one.
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                // ^^ FirstorDefault allows out to numberate a list and allows us to seach for certain properties and return the entire onject, So if the cardnum match it will return all properites.
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized, Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized, Please try again"); }
        }

        // Now creating the Pin funcition
        Console.WriteLine("Please Enter Pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Pin was not recognized, Please try again"); }
            }
            catch { Console.WriteLine("Pin was not recognized, Please try again"); }
        }


        // Now welcome the user once they have successfully
        Console.WriteLine("Welcome " + currentUser.getFName() + " " + currentUser.getLName() + ".");
        int option = 0;

        do
        {
            printOptions(); // this shows the 4 options created earlier in the code
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch { }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        // the reason for 4 is the exit key
        Console.WriteLine("Thank you for your business.");

    }

    
}