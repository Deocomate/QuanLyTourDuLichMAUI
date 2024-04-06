using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    public class Tour
    {
        public int TourID { get; set; }
        public string TenTour { get; set; }
        public int ThoiLuongTour { get; set; }
        public string PhuongTienTour { get; set; }
        public string DiaDiem { get; set; }
        public string LichTrinhChiTiet { get; set; }
        public string HinhAnhTour { get; set; }
        public string MoTaTour { get; set; }
        public float GiaTourDaiLy { get; set; }
        public float GiaTourBanLe { get; set; }
        public int DaiLyID { get; set; }

        public DaiLy DaiLy;
    }
}
