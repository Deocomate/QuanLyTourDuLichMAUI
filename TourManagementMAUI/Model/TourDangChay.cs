using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    public class TourDangChay
    {
        public int TourDangChayID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public string TrangThaiTour { get; set; }
        public int TourID { get; set; }
        public int HuongDanVienID { get; set; }
    }

}
