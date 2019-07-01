using Business;
using Core.Validators;
using Library.Business.Validators;
using Library.Data;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Library.Business
{
    public class BorrowedBookLogic : BaseLogic<BorrowedBook, BorrowedBookRepository>, IBorrowedBookLogic
    {
        private readonly IBorrowedBookRepository borrowRepository;
        private readonly IBookRepository bookRepository;

        public BorrowedBookLogic(IBorrowedBookRepository borrowRepository, IBookRepository bookRepository)
        {
            this.borrowRepository = borrowRepository;
            this.bookRepository = bookRepository;
        }

        /// <summary>
        /// Save a borrowed book and update the book state. 
        /// </summary>
        /// <param name="bookId">Book to borrow</param>
        /// <param name="userId">Logged user</param>
        public void BorrowBook(int bookId, string userId, int quantity, int days)
        {
            using (var transaction = new TransactionScope())
            {
                BorrowValidator validator = new BorrowValidator();
                var result = validator.Validate(new BorrowedBook());
                if (!result.IsValid)
                    throw new ValidationException(result.ValidationResultsLog);

                var book = this.bookRepository.Get(bookId);
                book.Stock = book.Stock - quantity;
                this.bookRepository.Update(book);

                this.borrowRepository.Add(new BorrowedBook() { BookID = bookId, Date = DateTime.Now, UserId = userId, Days = days, Active = true, Quantity = quantity });

                transaction.Complete();
            }
        }

        public void ReturnBook(int borrowedBookId)
        {
            using (var transaction = new TransactionScope())
            {
                var borrowedBook = this.borrowRepository.Find(x => x.BorrowedBookID == borrowedBookId).FirstOrDefault();

                var book = this.bookRepository.Get(borrowedBook.BookID);
                book.Stock = book.Stock + borrowedBook.Quantity;
                this.bookRepository.Update(book);
                borrowedBook.Active = false;
                this.borrowRepository.Update(borrowedBook);

                transaction.Complete();
            }
        }

        /// <summary>
        /// Return borrowed books by user.
        /// </summary>
        /// <param name="userId">Logged user</param>
        /// <returns>List of borrowed books</returns>
        public List<BorrowedBook> GetBorrowedBooksByUser(string userId)
        {
            return this.borrowRepository.GetBorrowedBooksByUser(userId);
        }
    }
}
