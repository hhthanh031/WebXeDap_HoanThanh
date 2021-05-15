using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserGroupDao
    {
        ShopXeDapDbContext db = null;

        public UserGroupDao()
        {
            db = new ShopXeDapDbContext();
        }

        public List<UserGroup> ListAll()
        {
            return db.UserGroups.ToList();
        }
    }
}
