using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class ProductDao
    {
        ShopXeDapDbContext db = null;

        public ProductDao()
        {
            db = new ShopXeDapDbContext();
        }

        //Xài cho trang Admin
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));
            }

            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        //Xài cho Client
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        //Danh mục sản phẩm chứa các sản phẩm
        public List<Product> ListByCategoryId(long categoryId, string sort)
        {
            var query = db.Products.Where(x => x.CategoryID == categoryId);

            switch (sort)
            {
                case "new":
                    query = query.OrderByDescending(x=>x.CreateDate);
                    break;
                case "pricethap":
                    query = query.OrderBy(x=>x.Price);
                    break;
                case "pricecao":
                    query = query.OrderByDescending(x=>x.Price);
                    break;
                default:
                    query = query;
                    break;
            }
            return query.ToList();

        }

        public List<Product> Search(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).ToList();

        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListRelatedProducts(long productId, int top)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).Take(top).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
