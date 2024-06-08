using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(int id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int id);
        List<Book> FindByKeyword(string keyword);
    }
}
