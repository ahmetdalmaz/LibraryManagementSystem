using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookTransactionDal : EfEntityRepositoryBase<BookTransaction, LibraryManagementContext>, IBookTransactionDal
    {
        public List<BookTransactionDto> GetBookTransactions()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var result = (from bookTransaction in context.BookTransactions
                             join book in context.Book on bookTransaction.BookId equals book.BookId
                             join members in context.Members on bookTransaction.MemberId equals members.MemberId
                             select new BookTransactionDto
                             {
                                 BookName = book.BookName,
                                 DueDate = bookTransaction.DueDate,
                                 IssueDate = bookTransaction.IssueDate,
                                 ISBN = book.ISBN,
                                 MemberSurname = members.MemberSurname,
                                 MemberName = members.MemberName,
                                 MemberEmail = members.MemberEmail,
                                 ReturnDate = bookTransaction.ReturnDate
                             }).ToList();
                return result;

            }
            
        }
    }
}
