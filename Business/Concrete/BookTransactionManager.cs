using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookTransactionManager : IBookTransactionService
    {
        private readonly IBookTransactionDal _bookTransactionDal;

        public BookTransactionManager(IBookTransactionDal bookTransactionDal)
        {
            _bookTransactionDal = bookTransactionDal;
        }

        public void Add(BookTransaction bookTransaction)
        {
            _bookTransactionDal.Add(bookTransaction);
        }

        public void Delete(BookTransaction bookTransaction)
        {
            _bookTransactionDal.Delete(bookTransaction);
        }

        public List<BookTransaction> GetAll()
        {
            return _bookTransactionDal.GetAll();
        }

        public List<BookTransactionDto> GetBookTransactionDetails()
        {
            return _bookTransactionDal.GetBookTransactions();
        }

        public BookTransaction GetById(int id)
        {
            return _bookTransactionDal.Get(b=>b.BookTransactionId == id);
        }

        public void Update(BookTransaction bookTransaction)
        {
            _bookTransactionDal.Update(bookTransaction);
        }
    }
}
