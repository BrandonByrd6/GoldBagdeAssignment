using InsuranceClaims.Data;
using InsuranceClaims.Repository;
using static System.Console;

public class ProgramUI
{
    private readonly ClaimRespository repository = new ClaimRespository();

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Clear();
            WriteLine("Welcome to Komodo Insurance Claim Applications \n" +
            "1. Create a Claim \n" +
            "2. Get All Claims\n" +
            "3. Get Current Claim\n" +
            "4. Remove the Current Claim\n" +
            "0. Close Application");

            var userInput = GetUserMenuInput();
            if (userInput == -1)
            {
                continue;
            }

            switch (userInput)
            {
                case 1:
                    CreateClaim();
                    break;
                case 2:
                    GetAllClaims();
                    break;
                case 3:
                    GetCurrentClaim();
                    break;
                case 4:
                    RemoveCurrentClaim();
                    break;
                case 0:
                    isRunning = CloseApplication();
                    break;
                default:
                    WriteLine("Invalid Input: Number Entered isn't an option!");
                    break;
            }
        }
    }

    private void CreateClaim()
    {
        Clear();
        WriteLine("Enter What type of claim you want to create. \n" +
                "1. Car Claim  2. Theft Claim  3. Home Claim");
        var userInput = GetUserMenuInput();
        Claim claim = new CarClaim();

        if (userInput == -1)
        {
            return;
        }
        switch (userInput)
        {
            case 1:
                claim = new CarClaim();
                break;
            case 2:
                claim = new TheftClaim();
                break;
            case 3:
                claim = new HomeClaim();
                break;
            default:
                WriteLine("Invalid Input: Number Entered isn't an option!");
                break;
        }
        if (claim == null)
        {
            return;
        }
        WriteLine("Enter the Description of the Claim:");
        string userInputDescription = ReadLine()!;
        claim.Description = userInputDescription;

        WriteLine("Enter the Amount of the Claim:");
        double userInputAmount = double.Parse(ReadLine()!);
        claim.ClaimAmount = userInputAmount;

        WriteLine("Enter the Date of Incident for the Claim: (MMM dd, YYYY) ex.  Jan 01, 2025");
        DateTime userInputDOI = DateTime.Parse(ReadLine()!);
        claim.DateOfIncident = userInputDOI;

        claim.DateOfClaim = DateTime.Now;

        repository.AddClaim(claim);
    }

    private void GetAllClaims()
    {
        Clear();
        WriteClaimsTables(repository.GetAllClaims());
        PressAnyKey();
    }

    private void GetCurrentClaim()
    {
        Clear();
        Claim claim = repository.GetClaim();
        string ClaimType = "";
        if (claim is CarClaim)
        {
            ClaimType = " Car Claim ";
        }
        else if (claim is HomeClaim)
        {
            ClaimType = "Home Claim ";
        }
        else if (claim is TheftClaim)
        {
            ClaimType = "Theft Claim";
        }
        string valid = claim.IsValid ? "yes" : "no";
        WriteLine($"{ClaimType}  {claim.Description} {claim.ClaimAmount}  {valid} ");
        PressAnyKey();
    }

    private void RemoveCurrentClaim()
    {
        repository.RemoveFirstClaim();
        WriteLine("Removed the First Claim in the List");
        PressAnyKey();
    }

    private void WriteClaimsTables(Queue<Claim> claims)
    {
        WriteLine("+-------------+-------------+--------------+-------+");
        WriteLine("| Claim Type  | Description | Claim Amount | Vaild |");
        WriteLine("+-------------+-------------+--------------+-------+");
        foreach (Claim claim in claims)
        {
            string ClaimType = "";
            if (claim is CarClaim)
            {
                ClaimType = " Car Claim ";
            }
            else if (claim is HomeClaim)
            {
                ClaimType = "Home Claim ";
            }
            else if (claim is TheftClaim)
            {
                ClaimType = "Theft Claim";
            }
            string valid = claim.IsValid ? "yes" : "no";
            WriteLine($"+ {ClaimType} + {claim.Description} + {claim.ClaimAmount} + {valid} +");
        }
        WriteLine("+-------------+-------------+--------------+-------+");
    }

    private void PressAnyKey()
    {
        WriteLine("Press any key to continue.");
        ReadKey();
    }

    private bool CloseApplication()
    {
        Clear();
        WriteLine("Thank you for using the Application! ");
        PressAnyKey();
        return false;
    }
    private int GetUserMenuInput()
    {
        try
        {
            int userInput = int.Parse(ReadLine()!);
            return userInput;
        }
        catch (System.Exception)
        {
            WriteLine("Please Enter a Number");
            PressAnyKey();
            return -1;
        }
    }
}
