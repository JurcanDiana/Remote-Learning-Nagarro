using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Subscribers;
using System.Collections.Generic;

namespace iQuest.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    public class PrintingOffice
    {
        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newsPaperRepository;
        private readonly ILog log;
        private List<BookLover> bookLovers = new List<BookLover>();
        private List<NewsHunter> newsHunters = new List<NewsHunter>();

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository;
            this.newsPaperRepository = newspaperRepository;
            this.log = log;
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            for (int i = 0; i < bookCount; i++)
            {
                Book book = bookRepository.GetRandom();
                log.WriteInfo("\n-------------------<> A book is being printed ... <>-------------------");
                log.WriteInfo($"{book.Title} by {book.Author}, {book.Title} was printed.\n");
                NotifyBookLover();
            }

            for (int i = 0; i < newspaperCount; i++)
            {
                Newspaper newspaper = newsPaperRepository.GetRandom();
                log.WriteInfo("\n-------------------<> A newspaper is being printed ... <>-------------------");
                log.WriteInfo($"{newspaper.Title}, edition {newspaper.Number} was printed.\n");
                NotifyNewsHunter();
            }
        }

        public void NotifyBookLover()
        {
            foreach(BookLover bookLover in bookLovers)
            {
                bookLover.Update();
            }
        }

        public void NotifyNewsHunter()
        {
            foreach(NewsHunter newsHunter in newsHunters)
            {
                newsHunter.Update();
            }
        }

        public void AddBookLover(BookLover bookLover)
        {
            bookLovers.Add(bookLover);
        }

        public void RemoveBookLover(BookLover bookLover)
        {
            bookLovers.Remove(bookLover);
        }

        public void AddNewsHunter(NewsHunter newsHunter)
        {
            newsHunters.Add(newsHunter);
        }

        public void RemoveNewsHunter(NewsHunter newsHunter)
        {
            newsHunters.Remove(newsHunter);
        }
    }
}