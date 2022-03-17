namespace DesignPatterns.Decorator.Better;

public class ExampleBetter
{
    public void Run()
    {
        var book = new Book("Worley", "Inside ASP.NET", 10);
        book.Display();

        var video = new Video("Spielberg", "Jaws", 23, 92);
        video.Display();

        Console.WriteLine("\nMaking video borrowable:");

        var enchancedVideo = new Borrowable<Video>(video);
        enchancedVideo.BorrowItem("Customer #1");
        enchancedVideo.BorrowItem("Customer #2");

        enchancedVideo.Display();
    }
}

public abstract class LibraryItem<T>
{
    public static int NumCopies { get; set; }

    public abstract void Display();
}

public class Book : LibraryItem<Book>
{
    private readonly string author;
    private readonly string title;

    public Book(string author, string title, int numCopies)
    {
        this.author = author;
        this.title = title;
        NumCopies = numCopies;
    }

    public override void Display()
    {
        Console.WriteLine("\nBook ------ ");
        Console.WriteLine($" Author: {author}");
        Console.WriteLine($" Title: {title}");
        Console.WriteLine($" # Copies: {NumCopies}");
    }
}

public class Video : LibraryItem<Video>
{
    private readonly string director;
    private readonly string title;
    private readonly int playTime;

    public Video(string director, string title,
        int numCopies, int playTime)
    {
        this.director = director;
        this.title = title;
        NumCopies = numCopies;
        this.playTime = playTime;
    }

    public override void Display()
    {
        Console.WriteLine("\nVideo ----- ");
        Console.WriteLine($" Director: {director}");
        Console.WriteLine($" Title: {title}");
        Console.WriteLine($" # Copies: {NumCopies}");
        Console.WriteLine($" Playtime: {playTime}\n");
    }
}

public abstract class Decorator<T> : LibraryItem<T>
{
    private readonly LibraryItem<T> libraryItem;

    public Decorator(LibraryItem<T> libraryItem)
    {
        this.libraryItem = libraryItem;
    }

    public override void Display() => libraryItem.Display();

}

public class Borrowable<T> : Decorator<T>
{
    private readonly List<string> borrowers = new();

    public Borrowable(LibraryItem<T> libraryItem)
        : base(libraryItem)
    {
    }

    public void BorrowItem(string name)
    {
        borrowers.Add(name);
        NumCopies--;
    }

    public void ReturnItem(string name)
    {
        borrowers.Remove(name);
        NumCopies++;
    }

    public override void Display()
    {
        base.Display();
        borrowers.ForEach(b => Console.WriteLine(" borrower: " + b));
    }
}