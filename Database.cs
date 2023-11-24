public class Database
{
    private static List<Movie> _movies;
    private static List<User> _users;

    static Database()
    {
        _movies = new()
        {
            new Movie{MovieId = 1, MovieName = "The Shawshank Redemption",Rating = 9.30, TotalVotes = 10},
            new Movie{MovieId = 2, MovieName = "The Dark Knight", Rating = 9.00, TotalVotes = 10},
            new Movie{MovieId = 3, MovieName = "12 Angry Men", Rating = 9.00, TotalVotes = 10},
            new Movie{MovieId = 4, MovieName = "Pulp Fiction", Rating = 8.90, TotalVotes = 10},
            new Movie{MovieId = 5, MovieName = "Forrest Gump", Rating = 8.80, TotalVotes = 10},
            new Movie{MovieId = 6, MovieName = "Inception", Rating = 8.80, TotalVotes = 10},
            new Movie{MovieId = 7, MovieName = "Fight Club", Rating = 8.80, TotalVotes = 10}
        };

        _users = new()
        {
            new User{UserName = "Grace Lucero", IsVoted = false},
            new User{UserName = "Erin Rivas", IsVoted = false},
            new User{UserName = "Summer Garcia", IsVoted = false},
            new User{UserName = "Emilia Scott", IsVoted = false},
            new User{UserName = "Daisy Johns", IsVoted = false}
        };
    }

    public static List<Movie> Movies => _movies;
    public static List<User> Users => _users;
}