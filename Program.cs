using System.Reflection.Metadata;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;

public class cardHolder
{
  string cardNum;
  int Pin;
  string FirstName;
  string LastName;
  double balance;

  public cardHolder(string cardNum, int Pin, string FirstName, string LastName, double balance)
  {
    this.cardNum = cardNum;
    this.Pin = Pin;
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.balance = balance;
  }

  public string getNum()
  {
    return cardNum;
  }

  public int getPin()
  {
    return Pin;
  }

  public string getFirstName()
  {
    return FirstName;
  }

  public string getLastName()
  {
    return LastName;
  }

  public double getbalance()
  {
    return balance;
  }

  
  public void setNum(string newcardNum)
  {
    cardNum = newcardNum;
  }

  public void setPin(int newPin)
  {
    Pin = newPin;
  }

  public void setFirstName(string newFirstName) 
  {
    FirstName = newFirstName;
  }

  public void setLastName(string newLastName) 
  {
    LastName = newLastName;
  }

  public void setbalance(double newbalance) 
  {
    balance = newbalance;
  }

  public static void Main(string[] args)
  {
    void printOption() 
    {
      string[] options = {"1. Deposit", "2. Withdrawl", "3. Show Balance", "4. Exit \n"};
      Console.WriteLine("Please Enter one of the following options.....");
      foreach (var item in options)
      {
        Console.WriteLine(item);
      }

    }

    void Deposit(cardHolder currentuser) 
    {
      Console.WriteLine("How much $$ do you want to deposit:) ");
      double deposit = Double.Parse(Console.ReadLine());
      currentuser.setbalance(currentuser.getbalance() + deposit);
      Console.WriteLine("Thanks for your $$.");
      Console.WriteLine("Your new balance is " + currentuser.getbalance());
    }

    void Withdrawl(cardHolder currentuser)
    {
      Console.WriteLine("How much $$ do you want to withdrawl :) ");
      double withdrawl = Double.Parse(Console.ReadLine());

      if (withdrawl > currentuser.getbalance())
      {
        Console.WriteLine("Insufficient Balance.");
      }
      else
      {
        double newBalance = currentuser.getbalance() - withdrawl;
        currentuser.setbalance(newBalance);
        Console.WriteLine("You are good to go!. Thank You. \n ");
      }
    }

    void balance (cardHolder currentuser)
    {
      Console.WriteLine("Current Balance: " + currentuser.getbalance());
    }

    
    List<cardHolder> cardHolders = new List<cardHolder>();
    cardHolders.Add(new cardHolder("7031692720", 2720, "John", "Mike", 150.67));
    cardHolders.Add(new cardHolder("7038271651", 1651, "Green", "Stone", 137.97));
    cardHolders.Add(new cardHolder("7036613415", 3415, "Itadori", "Yuji", 223.00));
    cardHolders.Add(new cardHolder("7047829273", 9273, "Nezuko", "Namikaze", 478.69));
    cardHolders.Add(new cardHolder("7048462864", 2864, "Sunku", "Uchiha", 346.18));



    // Prompt user
    Console.WriteLine("Welcome to Simple ATM system \n");
    Console.WriteLine("Please enter your debit card number :) ");
    string debitcardnum = " ";
    cardHolder currentuser;

    while (true)
    {
      try
      {
        debitcardnum = Console.ReadLine();
        // Check our list db
        currentuser = cardHolders.FirstOrDefault(a => a.cardNum == debitcardnum);
        if (currentuser != null)
        {
          break;
          Console.ReadKey();
        }
        else
        {
          Console.WriteLine("Debit Card Number is not recognized.  Please Try Again. \n");
        }

      }
      catch (System.Exception)
      {
        Console.WriteLine("Debit Card Number is not recognized.  Please Try Again. \n");
      }
    }



    Console.WriteLine("Please Enter your Pin :) ");
    int userPin = 0;

    while (true)
    {
      try
      {
        userPin = int.Parse(Console.ReadLine() + "\n");
        if (currentuser.getPin() == userPin)
        {
          break;
        }
        else
        {
          Console.WriteLine("Incorrect Pin.  Please Try Again. \n ");
        }
      }
      catch (System.Exception)
      {
        Console.WriteLine("Incorrect Pin.  Please Try Again. \n ");
      }
    }


    Console.WriteLine("Welcome " + currentuser.getFirstName() + " :) \n");
    int option = 0;
    do
    {
      printOption();
      try
      {
        option = int.Parse(Console.ReadLine() + "\n");
      }
      catch (System.Exception)
      {
        Console.WriteLine("Please select an option. \n");
      }


      
      if (option == 1)
      {
        Deposit(currentuser);
      }
      else if (option == 2)
      {
        Withdrawl(currentuser);
      }
      else if (option == 3)
      {
        balance(currentuser);
      }
      else if (option == 4)
      {
        break;
      }
      else
      {
        option = 0;
      }
    }
    while (option != 4);
    Console.WriteLine("Thanks You!  Have a nice day :)");
    Console.ReadKey();
  }
}