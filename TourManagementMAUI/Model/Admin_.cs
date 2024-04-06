using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    public class Admin_
    {
        public int AdminID { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int NhanVienID { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
