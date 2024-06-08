using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public CategoryDAO() { }

        public static List<Category> GetAll()
        {
            var list = new List<Category>();
            using(var context = new CodeFirstContext())
            {
                try
                {
                    list = context.Categories.ToList();
                }catch(Exception ex)
                {
                    throw;
                }
            }
            return list;
        }

        public static Category Get(int id)
        {
            var c = new Category();
            using (var context = new CodeFirstContext())
            {
                try
                {
                    c = context.Categories.FirstOrDefault(s => s.Id == id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return c;
        }

        public static void Insert(Category category)
        {
            using (var context = new CodeFirstContext())
            {
                try
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public static void Update(Category category)
        {
            using (var context = new CodeFirstContext())
            {
                try
                {
                    context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    var c = context.Categories.FirstOrDefault(s => s.Id==id);
                    context.Categories.RemoveRange(c);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
