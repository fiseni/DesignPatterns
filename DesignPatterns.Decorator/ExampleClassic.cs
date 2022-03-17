namespace DesignPatterns.Decorator.Classic;

public class ExampleClassic
{
    public void Run()
    {
        var book = new Book("Worley", "Inside ASP.NET", 10);
        book.Display();

        var video = new Video("Spielberg", "Jaws", 23, 92);
        video.Display();

        Console.WriteLine("\nMaking video borrowable:");

        var borrowvideo = new Borrowable(video);
        borrowvideo.BorrowItem("Customer #1");
        borrowvideo.BorrowItem("Customer #2");

        borrowvideo.Display();

        Console.ReadKey();
    }
}

public abstract class LibraryItem
{
    private int numCopies;

    public int NumCopies
    {
        get { return numCopies; }
        set { numCopies = value; }
    }

    public abstract void Display();
}

public class Book : LibraryItem
{
    private readonly string author;
    private readonly string title;

    public Book(string author, string title, int numCopies)
    {
        this.author = author;
        this.title = title;
        this.NumCopies = numCopies;
    }

    public override void Display()
    {
        Console.WriteLine("\nBook ------ ");
        Console.WriteLine(" Author: {0}", author);
        Console.WriteLine(" Title: {0}", title);
        Console.WriteLine(" # Copies: {0}", NumCopies);
    }
}

public class Video : LibraryItem
{
    private readonly string director;
    private readonly string title;
    private int playTime;

    public Video(string director, string title, int numCopies, int playTime)
    {
        this.director = director;
        this.title = title;
        this.NumCopies = numCopies;
        this.playTime = playTime;
    }

    public override void Display()
    {
        Console.WriteLine("\nVideo ----- ");
        Console.WriteLine(" Director: {0}", director);
        Console.WriteLine(" Title: {0}", title);
        Console.WriteLine(" # Copies: {0}", NumCopies);
        Console.WriteLine(" Playtime: {0}\n", playTime);
    }
}

public abstract class Decorator : LibraryItem
{
    protected LibraryItem libraryItem;

    public Decorator(LibraryItem libraryItem)
    {
        this.libraryItem = libraryItem;
    }

    public override void Display()
    {
        libraryItem.Display();
    }
}

public class Borrowable : Decorator
{
    protected readonly List<string> borrowers = new List<string>();

    public Borrowable(LibraryItem libraryItem)
        : base(libraryItem)
    {
    }

    public void BorrowItem(string name)
    {
        borrowers.Add(name);
        libraryItem.NumCopies--;
    }

    public void ReturnItem(string name)
    {
        borrowers.Remove(name);
        libraryItem.NumCopies++;
    }

    public override void Display()
    {
        base.Display();

        foreach (var borrower in borrowers)
        {
            Console.WriteLine(" borrower: " + borrower);
        }
    }
}