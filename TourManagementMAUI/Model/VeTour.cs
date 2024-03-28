using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    public class VeTour
    {
        public int VeTourID { get; set; }
        public DateTime NgayDatTour { get; set; }
        public int SoLuongKhach { get; set; }
        public float TongTien { get; set; }
        public string TrangThai { get; set; }
        public int TourDangChayID { get; set; }
        public int KhachHangID { get; set; }
        public int NhanVienID { get; set; }
    }
}
