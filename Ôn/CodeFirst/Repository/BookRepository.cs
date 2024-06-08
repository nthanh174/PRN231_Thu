using CodeFirst;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        public void Delete(int id) => BookDAO.Delete(id);

        public Book Get(int id) => BookDAO.Get(id);

        public List<Book> GetAll() => BookDAO.GetAll();

        public void Insert(Book book) => BookDAO.Insert(book);

        public void Update(Book book) => BookDAO.Update(book);

        public List<Book> FindByKeyword(string keyword) => BookDAO.FindByKeyword(keyword);

    }
}