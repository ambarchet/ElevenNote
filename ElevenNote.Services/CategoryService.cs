using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                Name = model.Name

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Categories.Select(
                             e =>
                                  new CategoryListItem
                                  {
                                      Id = e.Id,
                                      Name = e.Name,
                                  }
                                  );

                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.Id == id);
                    return new CategoryDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
            }
        }
        public bool UpdateCategory (CategoryEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.Id == model.Id);
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.Id == id);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

