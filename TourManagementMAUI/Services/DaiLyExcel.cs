using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagementMAUI.Model;

namespace TourManagementMAUI.Services
{
    internal class DaiLyExcel : ExcelService
    {
        public void ExportToExcel(List<DaiLy> daiLies)
        {
            string fileName = "DanhSachDaiLy_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string filePath = Path.Combine(userDownloadsFolder, fileName);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DaiLies");
                worksheet.Cell("A1").Value = "Mã Đại Lý";
                worksheet.Cell("B1").Value = "Tên Đại Lý";
                worksheet.Cell("C1").Value = "Địa Chỉ";
                worksheet.Cell("D1").Value = "Số Điện Thoại";
                worksheet.Cell("E1").Value = "Email";

                int row = 2;
                foreach (var daiLy in daiLies)
                {
                    worksheet.Cell(row, 1).Value = daiLy.DaiLyID;
                    worksheet.Cell(row, 2).Value = daiLy.TenDaiLy;
                    worksheet.Cell(row, 3).Value = daiLy.DiaChi;
                    worksheet.Cell(row, 4).Value = daiLy.SoDienThoai;
                    worksheet.Cell(row, 5).Value = daiLy.Email;
                    row++;
                }
                workbook.SaveAs(filePath);
            }
        }
    }
}
