using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
        private readonly string Name;
        private PrintingOffice PrintingOffice;
        private readonly ILog Log;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            Name = name;
            PrintingOffice = printingOffice;
            printingOffice.newspaperPrintedEvent += HandleNewspaperPrinted;
            Log = log;
        }

        private void HandleNewspaperPrinted(Newspaper newspaper)
        {
            Log.WriteInfo("News hunter: " + Name + ", ");
        }

    }
}