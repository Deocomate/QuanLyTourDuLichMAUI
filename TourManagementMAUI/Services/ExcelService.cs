using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagementMAUI.Model;
using ClosedXML.Excel;

namespace TourManagementMAUI.Services
{
    internal class ExcelService
    {
        public string userDownloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        public string fileName = "DanhSachDaiLy_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
    }
}