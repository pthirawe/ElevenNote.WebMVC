using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        // Create
        public bool CreateCategory(Category newCategory)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(newCategory);
                return ctx.SaveChanges() == 1;
            }
        }
        // Read
        public IEnumerable<Category> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var categories = ctx.Categories.ToArray();

                return categories;
            }
        }

        public Category GetCategoryByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx.Categories.Find(id);

                return category;
            }
        }
        // Update
        public bool UpdateCategory(Category model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(model).State = EntityState.Modified;
                return ctx.SaveChanges()==1;
            }
        }
        // Delete
        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx.Categories.Find(id);
                ctx.Categories.Remove(category);
                return ctx.SaveChanges()==1;
            }
        }
    }
}
