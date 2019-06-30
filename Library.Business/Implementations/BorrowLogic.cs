using Business;
using Core.Validators;
using Library.Business.Validators;
using Library.Data;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Library.Business
{
    public class BorrowLogic : BaseLogic<BorrowedBook, BorrowRepository>, IBorrowLogic
    {
        private readonly IBorrowRepository borrowRepository;
        private readonly IBookRepository bookRepository;

        public BorrowLogic(IBorrowRepository borrowRepository, IBookRepository bookRepository)
        {
            this.borrowRepository = borrowRepository;
            this.bookRepository = bookRepository;
        }

        public void BorrowBook(int bookId, string userId)
        {
            using (var transaction = new TransactionScope())
            {
                BorrowValidator validator = new BorrowValidator();
                var result = validator.Validate(new BorrowedBook());
                if (!result.IsValid)
                    throw new ValidationException(result.ValidationResultsLog);

                var book = this.bookRepository.Get(bookId);
                book.Booked = true;
                this.bookRepository.Update(book);

                this.borrowRepository.Add(new BorrowedBook() { BookID = bookId, Date = DateTime.Now, UserId = userId });

                transaction.Complete();
            }
        }

        public List<BorrowedBook> GetBorrowedBooksByUser(string userId)
        {
            return this.borrowRepository.GetBorrowedBooksByUser(userId);
        }
    }
}
