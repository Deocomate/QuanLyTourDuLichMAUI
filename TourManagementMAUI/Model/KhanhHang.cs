using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    public class KhachHang
    {
        public int KhachHangID { get; set; }
        public string TenKhachHang { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
    }
}
