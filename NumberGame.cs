public class Game{
    public static void Main(string[] args){
        Game game = new Game();
        game.Start();
    }
    public void Start(){
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        ChooseDifficulty();
    }

    public void ChooseDifficulty(){
        Console.WriteLine("Choose a difficulty level: Easy, Medium, or Hard");
        string difficulty = Console.ReadLine().ToLower();

        switch (difficulty){
            case "easy":
                StartGame(10);
                break;
            case "medium":
                StartGame(5);
                break;
            case "hard":
                StartGame(3);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose Easy, Medium, or Hard.");
                ChooseDifficulty();
                break;
        }
    }
    public static void StartGame(int attempts){
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int userGuess = 0;

        Console.WriteLine($"You have {attempts} attempts to guess the number.");

        while (attempts > 0 && userGuess != numberToGuess){
            Console.Write("Enter your guess: ");
            if (int.TryParse(Console.ReadLine(), out userGuess)){
                if (userGuess < numberToGuess){
                    Console.WriteLine("Too low!");
                }
                else if (userGuess > numberToGuess){
                    Console.WriteLine("Too high!");
                }
                else{
                    Console.WriteLine("Congratulations! You've guessed the number!");
                    return;
                }
                attempts--;
                Console.WriteLine($"You have {attempts} attempts left.");
            }
            else{
                Console.WriteLine("Please enter a valid number.");
            }
        }
        if (userGuess != numberToGuess){
            Console.WriteLine($"Sorry, you've run out of attempts. The number was {numberToGuess}.");
            Console.WriteLine("Would you like to play again?");
            string playAgain = Console.ReadLine().ToLower();
            switch (playAgain){
                case "yes":
                    Game g = new Game();
                    g.Start();
                    break;
                case "no":
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 'yes' or 'no'.");
                    break;
            }
        }
    }
}

