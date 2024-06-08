using CodeFirst;
using System.Collections.Generic;

namespace Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
