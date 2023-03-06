using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Subscribers;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

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

        public delegate void BookPrintedHandler(Book book);
        public delegate void NewspaperPrintedHandler(Newspaper newspaper);

        public event BookPrintedHandler bookPrintedEvent;
        public event NewspaperPrintedHandler newspaperPrintedEvent;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository;
            this.newsPaperRepository = newspaperRepository;
            this.log = log;
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            log.WriteInfo("-------------------<> Printing ... <>-------------------");

            for (int i = 0; i < bookCount; i++)
            {
                Book book = bookRepository.GetRandom();
                OnBookPrinted(book);
                log.WriteInfo($"Have been notified that the book: {book.Title} by {book.Author}, {book.Title} was printed.\n");
            }

            for (int i = 0; i < newspaperCount; i++)
            {
                Newspaper newspaper = newsPaperRepository.GetRandom();
                OnNewspaperPrinted(newspaper);
                log.WriteInfo($"Have been notified that the newspaper: {newspaper.Title}, edition {newspaper.Number} was printed.\n");
            }
        }

        protected virtual void OnBookPrinted(Book book)
        {
            BookPrintedHandler bookPrinted = bookPrintedEvent;
            bookPrinted(book);
        }

        protected virtual void OnNewspaperPrinted(Newspaper newspaper)
        {
            NewspaperPrintedHandler newspaperPrinted = newspaperPrintedEvent;
            newspaperPrinted(newspaper);
        }
    }
}