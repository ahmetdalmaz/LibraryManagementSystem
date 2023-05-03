using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        void Add(Book book);
        List<Book> GetAll();
        void Delete(Book book);
        Book GetById(int id);
        void Update(Book book);
    }
}
