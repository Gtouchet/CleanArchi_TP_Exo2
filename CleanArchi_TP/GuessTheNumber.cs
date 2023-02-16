namespace CleanArchi_TP;

public class GuessTheNumber
{
    private readonly Random generator = new Random();
    private readonly int maxAttempts;
    private readonly Range numberRange;

    private int attempts;
    private bool firstGame = true;
    
    public GuessTheNumber(
        int maxAttempts = 10,
        int maxNumber = 100)
    {
        this.maxAttempts = maxAttempts;
        this.numberRange = new Range(1, maxNumber);
    }

    public void Run()
    {
        while(this.PlayAgain())
        {
            Console.WriteLine($"Guess the number (between 1 and {this.numberRange.Max})!");
            
            int userGuess = -1;
            this.attempts = 0;
            int number = this.GenerateNumber();
            
            while(this.CanContinue(number, userGuess, attempts))
            {
                string? readLine = Console.ReadLine();
                this.attempts += 1;
                
                if (int.TryParse(readLine, out userGuess))
                {
                    this.InterpretInput(number, userGuess);
                }
                else
                {
                    Console.WriteLine($"your input was '{readLine}', please enter a valid integer. {this.maxAttempts - attempts}/{this.maxAttempts} tries left");
                }
            }
            
            if (number != userGuess)
            {
                Console.WriteLine($"you loose after {this.maxAttempts} tries, the expected number was {number}");
            }
        }
    }
    
    private bool PlayAgain()
    {
        if (this.firstGame)
        {
            this.firstGame = false;
            return true;
        }
        Console.WriteLine("Do you want to play again? (y/n)");
        string? readLine = Console.ReadLine();
        return readLine != null && readLine.ToLower() == "y";
    }

    private int GenerateNumber()
    {
        return this.generator.Next(1, this.numberRange.Max);
    }

    private bool CanContinue(int number, int userGuess, int attempts)
    {
        return number != userGuess && attempts < this.maxAttempts;
    }

    private void InterpretInput(int number, int userGuess)
    {
        if (userGuess != number)
        {
            Console.WriteLine(
                $"Wrong! your number is {(userGuess < number ? "smaller" : "greater")} than the correct one. " +
                $"{this.maxAttempts - this.attempts}/{this.maxAttempts} tries left");
        }
        else
        {
            Console.WriteLine($"You found it after {this.attempts} tries!");
        }
    }
}
