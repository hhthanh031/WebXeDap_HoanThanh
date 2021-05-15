using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        ShopXeDapDbContext db = null;
        public OrderDao()
        {
            db = new ShopXeDapDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }

        public IEnumerable<OrderViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<OrderViewModel> model;
            model = from o in db.Orders
                    join d in db.OrderDetails on o.ID equals d.OrderID
                    join p in db.Products on d.ProductID equals p.ID
                    select new OrderViewModel()
                    {
                        ID = o.ID,
                        CreatedDate = o.CreatedDate,
                        Name = p.Name,
                        Code = p.Code,
                        Image = p.Image,
                        ShipName = o.ShipName,
                        ShipMobile = o.ShipMobile,
                        ShipAddress = o.ShipAddress,
                        ShipEmail = o.ShipEmail,
                        Status = o.Status,
                        Quantity = d.Quantity,
                        Price = d.Price,
                    };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipMobile.Contains(searchString));
            }

            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public IEnumerable<OrderViewModel> SapXepTheoThoiGianDatHang(string searchString, int page, int pageSize)
        {
            IQueryable<OrderViewModel> model;
            model = from o in db.Orders
                    join d in db.OrderDetails on o.ID equals d.OrderID
                    join p in db.Products on d.ProductID equals p.ID
                    select new OrderViewModel()
                    {
                        ID = o.ID,
                        CreatedDate = o.CreatedDate,
                        Name = p.Name,
                        Code = p.Code,
                        Image = p.Image,
                        ShipName = o.ShipName,
                        ShipMobile = o.ShipMobile,
                        ShipAddress = o.ShipAddress,
                        ShipEmail = o.ShipEmail,
                        Status = o.Status,
                        Quantity = d.Quantity,
                        Price = d.Price,
                    };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipMobile.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public OrderViewModel Details(long id)
        {
            IQueryable<OrderViewModel> model;
            model = from o in db.Orders
                    join d in db.OrderDetails on o.ID equals d.OrderID
                    join p in db.Products on d.ProductID equals p.ID
                    where o.ID == id
                    select new OrderViewModel()
                    {
                        ID = o.ID,
                        CreatedDate = o.CreatedDate,
                        Name = p.Name,
                        Code = p.Code,
                        Image = p.Image,
                        ShipName = o.ShipName,
                        ShipMobile = o.ShipMobile,
                        ShipAddress = o.ShipAddress,
                        ShipEmail = o.ShipEmail,
                        Status = o.Status,
                        Quantity = d.Quantity,
                        Price = d.Price,
                    };

            return model.FirstOrDefault(x=>x.ID==id);
        }
    }
}
