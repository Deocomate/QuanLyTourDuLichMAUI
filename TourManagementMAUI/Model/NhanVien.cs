using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    public class NhanVien
    {
        public int NhanVienID { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string PhongBan { get; set; }
        public string MatKhau { get; set; }
    }
}
