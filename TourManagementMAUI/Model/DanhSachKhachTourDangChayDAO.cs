using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class DanhSachKhachTourDangChayDAO : DAO
    {
        public static List<DanhSachKhachTourDangChay> List()
        {
            var list = new List<DanhSachKhachTourDangChay>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM DanhSachKhachTourDangChay", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new DanhSachKhachTourDangChay
                        {
                            DanhSachKhachTourDangChayID = reader.GetInt32(reader.GetOrdinal("DanhSachKhachTourDangChayID")),
                            TourDangChayID = reader.GetInt32(reader.GetOrdinal("TourDangChayID")),
                            KhachHangID = reader.GetInt32(reader.GetOrdinal("KhachHangID"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static DanhSachKhachTourDangChay Find(int id)
        {
            var item = new DanhSachKhachTourDangChay();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM DanhSachKhachTourDangChay WHERE DanhSachKhachTourDangChayID = @DanhSachKhachTourDangChayID", connection))
                {
                    command.Parameters.AddWithValue("@DanhSachKhachTourDangChayID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new DanhSachKhachTourDangChay
                            {
                                DanhSachKhachTourDangChayID = reader.GetInt32(reader.GetOrdinal("DanhSachKhachTourDangChayID")),
                                TourDangChayID = reader.GetInt32(reader.GetOrdinal("TourDangChayID")),
                                KhachHangID = reader.GetInt32(reader.GetOrdinal("KhachHangID"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(DanhSachKhachTourDangChay item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO DanhSachKhachTourDangChay (TourDangChayID, KhachHangID) VALUES (@TourDangChayID, @KhachHangID)", connection))
                {
                    command.Parameters.AddWithValue("@TourDangChayID", item.TourDangChayID);
                    command.Parameters.AddWithValue("@KhachHangID", item.KhachHangID);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, DanhSachKhachTourDangChay item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE DanhSachKhachTourDangChay SET TourDangChayID = @TourDangChayID, KhachHangID = @KhachHangID WHERE DanhSachKhachTourDangChayID = @DanhSachKhachTourDangChayID", connection))
                {
                    command.Parameters.AddWithValue("@TourDangChayID", item.TourDangChayID);
                    command.Parameters.AddWithValue("@KhachHangID", item.KhachHangID);
                    command.Parameters.AddWithValue("@DanhSachKhachTourDangChayID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM DanhSachKhachTourDangChay WHERE DanhSachKhachTourDangChayID = @DanhSachKhachTourDangChayID", connection))
                {
                    command.Parameters.AddWithValue("@DanhSachKhachTourDangChayID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
