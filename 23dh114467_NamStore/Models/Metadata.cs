using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23dh114467_NamStore.Models
{
    public class CategoryMetadata
    {
        [HiddenInput]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(50,MinimumLength =5)]
        public string CategoryName { get; set; }
    }
    public class UserMetadata
    {
        [Required(ErrorMessage ="Ussername is required")]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression("\r\n ^[a-zA-Z0-9]*$", ErrorMessage = "Only letters and numbers are allowed.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}
public class ProductMetadata
{
    [Display(Name="Mã sản phẩm")]
    public int ProductID { get; set; }
    [Display(Name = "Loại sản phẩm")]
    public int CategoryID { get; set; }
    [StringLength(50)]
    [Required(ErrorMessage ="Phai nhap ten san pham" ) ]
    [Display(Name = "Tên sản phẩm")]
    public string ProductName { get; set; }
    [Display(Name = "Mô tả sản phẩm")]
    public string ProductDescription { get; set; }
    [Display(Name = "Giá sản phẩm")]

    public decimal ProductPrice { get; set; }
    [Display(Name = "duong dan hình ảnh san pham")]
    [DefaultValue("~/Content/images/default_img.jfif")]
    public string ProductImage { get; set; }
}