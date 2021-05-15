using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewModel
    {
        [Display(Name = "ID")]
        public long ID { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Tên người đặt")]
        public string ShipName { get; set; }
        [Display(Name = "SĐT")]
        public string ShipMobile { get; set; }
        [Display(Name = "Địa chỉ")]
        public string ShipAddress { get; set; }
        [Display(Name = "Email")]
        public string ShipEmail { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }
        [Display(Name = "Giá")]
        public decimal? Price { get; set; }
        [Display(Name = "Tên SP")]
        public string Name { get; set; }
        [Display(Name = "Mã SP")]
        public string Code { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
    }
}
