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
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryManagementContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var books = from book in context.Book join category in context.Categories on book.CategoryId equals category.CategoryId join author in context.Authors on book.AuthorId equals author.AuthorId select new BookDetailDto
                {
                    BookId = book.BookId,
                    AuthorName = author.AuthorName,
                    BookName = book.BookName,
                    CategoryName = category.CategoryName,
                    BookState = book.BookState,
                    PageCount = book.PageCount
                };
                return books.ToList();
            }
            
        }
    }
}
