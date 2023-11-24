

internal class Program
{
    private static void Main(string[] args)
    {
        GetSelection();
    }

    private static void GetSelection()
    {
    getSelection:
        Console.WriteLine(
            "Please select one of the options below" +
            "\n\t1) Vote for movies" +
            "\n\t2) Show results"
        );

        string input = Console.ReadLine();



        switch (input)
        {
            case "1":
                MakeVote();
                break;
            case "2":
                ShowResult();
                break;

            default:
                Console.WriteLine("Invalid entry! Please push a button to try again.");
                Console.Read();
                break;
        }
        Console.Clear();
        goto getSelection;
    }
    private static void ShowResult()
    {
        Console.WriteLine("Vote Results: ");
        foreach (var item in Database.Movies)
        {
            Console.WriteLine($"\tMovie: {item.MovieName} Rating: {item.Rating} Total Votes: {item.TotalVotes}");
            Console.WriteLine();
        }
        Console.WriteLine("Push a button to show Main Menu...");
        Console.ReadKey();
    }

    private static void MakeVote()
    {
    tryAgain:
        Console.Write("Please enter your username: ");
        string userName = Console.ReadLine();

    tryVote:
        User user = new User();

        if (Database.Users.Any(u => u.UserName == userName))
        {
            user = Database.Users.First(u => u.UserName == userName);

            if (user.IsVoted == false)
            {
                foreach (var item in Database.Movies)
                {
                    Console.WriteLine($"Id: {item.MovieId} {item.MovieName}: {item.Rating}");
                }

            tryToVote:
                Console.WriteLine("Please enter Movie Id to vote : ");
                int choice = int.Parse(Console.ReadLine());

                if (Database.Movies.Any(m => m.MovieId == choice))
                {
                    var selectedMovie = Database.Movies.FirstOrDefault(m => m.MovieId == choice);
                    Console.WriteLine("Please enter a value between 1-10");
                    double voteRating = Double.Parse(Console.ReadLine());

                tryRating:
                    if (1 <= voteRating && voteRating <= 10)
                    {
                        double totalRating =  selectedMovie.Rating * selectedMovie.TotalVotes;
                        selectedMovie.Rating = Math.Round((totalRating + voteRating) / (selectedMovie.TotalVotes + 1), 2);
                        selectedMovie.TotalVotes++;
                        Console.WriteLine("Successfully voted. Please push a button...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Push a button to try again...");
                        goto tryRating;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input! Push a button to try again...");
                    goto tryToVote;
                }

            }
            else
            {
                Console.WriteLine($"{user.UserName} is voted already. Please enter a different user name: ");
                goto tryAgain;
            }
            user.IsVoted = true;
        }
        else
        {
            Console.WriteLine("User is not found. Push a button to register...");
            Console.ReadKey();

        tryUserName:
            Console.WriteLine("Please enter a user name: ");
            string newUser = Console.ReadLine();

            if (String.IsNullOrEmpty(newUser))
            {
                Console.WriteLine("Username can not be empty! Try again... ");
                goto tryUserName;
            }
            else
            {
                if (Database.Users.Any(n => n.UserName == newUser))
                {
                    Console.WriteLine("This user exists. Try another...");
                    goto tryUserName;
                }
                else
                {
                    user.UserName = newUser;
                    user.IsVoted = false;
                    Database.Users.Add(user);
                    Console.WriteLine("Your user name successfully registered. You are being directed to voting... Push a button...");
                    Console.ReadKey();
                    goto tryVote;
                }
            }
        }
    }
}
