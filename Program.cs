Movie[] movieCatalog = new Movie[100];
int movieCount = 0;

while (movieCount < movieCatalog.Length)
{
    Console.Write("Enter movie title: ");
    string movieTitle = Console.ReadLine()?.Trim() ?? "";
    if (IsExitCommand(movieTitle)) break;

    Console.Write("Enter movie duration in miutes: ");
    string durationInput = Console.ReadLine()?.Trim() ?? "";
    if (IsExitCommand(durationInput)) break;

    bool hasTitle = !string.IsNullOrWhiteSpace(movieTitle);
    bool hasDuration = int.TryParse(durationInput, out int duration) && duration > 0;

    if (!hasTitle && !hasDuration)
        movieCatalog[movieCount] = new Movie();
    else if (!hasDuration)
        movieCatalog[movieCount] = new Movie(movieTitle);
    else
        movieCatalog[movieCount] = new Movie(movieTitle, duration);

    movieCount++;
    Console.WriteLine();
}

Console.WriteLine("\n--- Movie List ---");
for (int i = 0; i < movieCount; i++)
{
    movieCatalog[i].Print(i + 1);
}

bool IsExitCommand(string input)
{
    return input.Equals("done", StringComparison.OrdinalIgnoreCase) || input.Equals("print", StringComparison.OrdinalIgnoreCase);
}

class Movie
{
    public string movieName;
    public int movieDuration;

    public Movie()
    {
        movieName = "Unknown";
        movieDuration = 0;
    }

    public Movie(string name)
    {
        movieName = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
        movieDuration = 0;
    }

    public Movie(string name, int duration)
    {
        movieName = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
        movieDuration = duration;
    }

    public void Print(int number)
    {
        string durationText = movieDuration > 0 ? movieDuration.ToString() : "Empty";

        Console.WriteLine($"\n{number}. Movie title: \"{movieName}\"");
        Console.WriteLine($"   Movie Duration: \"{durationText}\"");
    }
}