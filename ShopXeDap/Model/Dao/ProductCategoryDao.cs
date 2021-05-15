using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        ShopXeDapDbContext db = null;

        public ProductCategoryDao()
        {
            db = new ShopXeDapDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public IEnumerable<Product> SanPhamCungTheLoai(string searchString, long catelogID)
        {
            ShopXeDapDbContext db = new ShopXeDapDbContext();
            IQueryable<Product> dsProduct = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                dsProduct = dsProduct.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));
            }
            return dsProduct.Where(x => x.CategoryID == catelogID).ToList();
        }
    }
}
