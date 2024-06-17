using CodeFirst;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class BookDAO
    {
        public BookDAO() { }

        public static List<Book> GetAll()
        {
            var list = new List<Book>();
            using (var context = new CodeFirstContext())
            {
                try
                {
                    list = context.Books.Include(s => s.Category).ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }

        public static Book Get(int id)
        {
            var book = new Book();
            using (var context = new CodeFirstContext())
            {
                try
                {
                    book = context.Books.Include(s => s.Category).FirstOrDefault(b => b.Id == id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return book;
        }

        public static void Insert(Book book)
        {
            using (var context = new CodeFirstContext())
            {
                try
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void Update(Book book)
        {
            using (var context = new CodeFirstContext())
            {
                try
                {
                    context.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void Delete(int id)
        {
            using (var context = new CodeFirstContext())
            {
                try
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == id);
                    if (book != null)
                    {
                        context.Books.Remove(book);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static List<Book> FindByKeyword(string keyword)
        {
            var list = new List<Book>();
            using (var context = new CodeFirstContext())
            {
                try
                {
                    list = context.Books.Include(s => s.Category)
                        .Where(b => b.Name.Contains(keyword) || b.Category.Name.Contains(keyword))
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }
    }
}
