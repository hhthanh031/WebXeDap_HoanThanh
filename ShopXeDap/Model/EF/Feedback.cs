namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int ID { get; set; }

        [StringLength(50)]
        
        [Display(Name = "Tên người gửi")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        
        public string Phone { get; set; }

        [StringLength(50)]
        
        public string Email { get; set; }

        [StringLength(50)]
        
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(250)]
        
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Ngày gửi")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
