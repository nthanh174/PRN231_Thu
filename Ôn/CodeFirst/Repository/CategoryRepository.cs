using CodeFirst;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Delete(int id) => CategoryDAO.Delete(id);

        public Category Get(int id) => CategoryDAO.Get(id);

        public List<Category> GetAll() => CategoryDAO.GetAll();

        public void Insert(Category category) => CategoryDAO.Insert(category);

    public void Update(Category category)=> CategoryDAO.Update(category);
    }
}
