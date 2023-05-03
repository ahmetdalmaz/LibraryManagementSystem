using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        void Add(Author author);
        List<Author> GetAll();
        void Delete(Author author);
        Author GetById(int id);
        void Update(Author author);

    }
}
