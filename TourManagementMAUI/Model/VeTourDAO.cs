using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class VeTourDAO : DAO
    {
        public static List<VeTour> List()
        {
            var list = new List<VeTour>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM VeTour", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new VeTour
                        {
                            VeTourID = reader.GetInt32(reader.GetOrdinal("VeTourID")),
                            NgayDatTour = reader.GetDateTime(reader.GetOrdinal("NgayDatTour")),
                            SoLuongKhach = reader.GetInt32(reader.GetOrdinal("SoLuongKhach")),
                            TongTien = (float)reader.GetDouble(reader.GetOrdinal("TongTien")),
                            TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                            TourDangChayID = reader.GetInt32(reader.GetOrdinal("TourDangChayID")),
                            KhachHangID = reader.GetInt32(reader.GetOrdinal("KhachHangID")),
                            NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static VeTour Find(int id)
        {
            var item = new VeTour();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM VeTour WHERE VeTourID = @VeTourID", connection))
                {
                    command.Parameters.AddWithValue("@VeTourID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new VeTour
                            {
                                VeTourID = reader.GetInt32(reader.GetOrdinal("VeTourID")),
                                NgayDatTour = reader.GetDateTime(reader.GetOrdinal("NgayDatTour")),
                                SoLuongKhach = reader.GetInt32(reader.GetOrdinal("SoLuongKhach")),
                                TongTien = (float)reader.GetDouble(reader.GetOrdinal("TongTien")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                                TourDangChayID = reader.GetInt32(reader.GetOrdinal("TourDangChayID")),
                                KhachHangID = reader.GetInt32(reader.GetOrdinal("KhachHangID")),
                                NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(VeTour item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO VeTour (NgayDatTour, SoLuongKhach, TongTien, TrangThai, TourDangChayID, KhachHangID, NhanVienID) VALUES (@NgayDatTour, @SoLuongKhach, @TongTien, @TrangThai, @TourDangChayID, @KhachHangID, @NhanVienID)", connection))
                {
                    command.Parameters.AddWithValue("@NgayDatTour", item.NgayDatTour);
                    command.Parameters.AddWithValue("@SoLuongKhach", item.SoLuongKhach);
                    command.Parameters.AddWithValue("@TongTien", item.TongTien);
                    command.Parameters.AddWithValue("@TrangThai", item.TrangThai);
                    command.Parameters.AddWithValue("@TourDangChayID", item.TourDangChayID);
                    command.Parameters.AddWithValue("@KhachHangID", item.KhachHangID);
                    command.Parameters.AddWithValue("@NhanVienID", item.NhanVienID);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, VeTour item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE VeTour SET NgayDatTour = @NgayDatTour, SoLuongKhach = @SoLuongKhach, TongTien = @TongTien, TrangThai = @TrangThai, TourDangChayID = @TourDangChayID, KhachHangID = @KhachHangID, NhanVienID = @NhanVienID WHERE VeTourID = @VeTourID", connection))
                {
                    command.Parameters.AddWithValue("@NgayDatTour", item.NgayDatTour);
                    command.Parameters.AddWithValue("@SoLuongKhach", item.SoLuongKhach);
                    command.Parameters.AddWithValue("@TongTien", item.TongTien);
                    command.Parameters.AddWithValue("@TrangThai", item.TrangThai);
                    command.Parameters.AddWithValue("@TourDangChayID", item.TourDangChayID);
                    command.Parameters.AddWithValue("@KhachHangID", item.KhachHangID);
                    command.Parameters.AddWithValue("@NhanVienID", item.NhanVienID);
                    command.Parameters.AddWithValue("@VeTourID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Delete(int id)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM VeTour WHERE VeTourID = @VeTourID", connection))
                {
                    command.Parameters.AddWithValue("@VeTourID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
