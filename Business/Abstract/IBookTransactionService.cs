using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookTransactionService
    {
        void Add(BookTransaction bookTransaction);
        List<BookTransaction> GetAll();
        void Delete(BookTransaction bookTransaction);
        BookTransaction GetById(int id);
        void Update(BookTransaction bookTransaction);
        List<BookTransactionDto> GetBookTransactionDetails();
    }
}
