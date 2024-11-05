using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;


namespace _23dh114467_NamStore.Models.ViewModel
{
    public class ProductSearchVM
    {
        //Tiêu chí search theo tên, mô tả sản phẩm hoặc loại sp
        public string SearchTerm { get; set; }
        public List<Product> Products { get; set; }

        //Các tiêu chí search theo giá
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        //Thứ tự sắp xếp
        public string SortOrder { get; set; }

        //Các thuộc tính hỗ trợ phân trang
        public int PageNumber { get; set; } //Trang hiện tại
        public int PageSize { get; set; } = 10; //Số sản phẩm mỗi trang

        //Danh sách sản phẩm đã phân trang
        public PagedList.IPagedList<Product> products { get; set; }

        //Danh sách sp thỏa điều kiện tìm kiếm
        //public List<Product> products { get; set; }
    }
}