namespace DesignPatterns.Factory;

public class Example
{
    public void Run()
    {
        var documents = new List<Document>()
        {
            new Resume(),
            new Report()
        };

        foreach (var document in documents)
        {
            document.CreatePages();

            Console.WriteLine($"{document} --");
            foreach (var page in document.Pages)
            {
                Console.WriteLine($"Page: {page}");
            }
            Console.WriteLine();
        }
    }
}


public abstract class Page
{
    public override string ToString()
    {
        return GetType().Name;
    }
}

public class SkillsPage : Page
{
}

public class EducationPage : Page
{
}

public class ExperiencePage : Page
{
}

public class IntroductionPage : Page
{
}

public class ResultsPage : Page
{
}

public class ConclusionPage : Page
{
}

public class SummaryPage : Page
{
}

public class BibliographyPage : Page
{
}

public abstract class Document
{
    public List<Page> Pages { get; protected set; } = null!;

    public abstract void CreatePages();

    public override string ToString()
    {
        return GetType().Name;
    }
}

public class Resume : Document
{
    public override void CreatePages()
    {
        Pages = new()
        {
            new SkillsPage(),
            new EducationPage(),
            new ExperiencePage()
        };
    }
}

public class Report : Document
{
    public override void CreatePages()
    {
        Pages = new()
        {
            new IntroductionPage(),
            new ResultsPage(),
            new ConclusionPage(),
            new SummaryPage(),
            new BibliographyPage()
        };
    }
}