using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class Old
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
                                      CategoryId = e.CategoryId,
                                      Name = e.Name,
                                  }
                                  );

                return query.ToArray();
            }
        }

    }
}
