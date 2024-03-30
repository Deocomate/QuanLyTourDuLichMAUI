using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class TourDangChayDAO : DAO
    {
        public static List<TourDangChay> List()
        {
            var list = new List<TourDangChay>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM TourDangChay", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new TourDangChay
                        {
                            TourDangChayID = reader.GetInt32(reader.GetOrdinal("TourDangChayID")),
                            NgayBatDau = reader.GetDateTime(reader.GetOrdinal("NgayBatDau")),
                            TrangThaiTour = reader.GetString(reader.GetOrdinal("TrangThaiTour")),
                            TourID = reader.GetInt32(reader.GetOrdinal("TourID")),
                            HuongDanVienID = reader.GetInt32(reader.GetOrdinal("HuongDanVienID"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static TourDangChay Find(int id)
        {
            var item = new TourDangChay();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM TourDangChay WHERE TourDangChayID = @TourDangChayID", connection))
                {
                    command.Parameters.AddWithValue("@TourDangChayID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new TourDangChay
                            {
                                TourDangChayID = reader.GetInt32(reader.GetOrdinal("TourDangChayID")),
                                NgayBatDau = reader.GetDateTime(reader.GetOrdinal("NgayBatDau")),
                                TrangThaiTour = reader.GetString(reader.GetOrdinal("TrangThaiTour")),
                                TourID = reader.GetInt32(reader.GetOrdinal("TourID")),
                                HuongDanVienID = reader.GetInt32(reader.GetOrdinal("HuongDanVienID"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(TourDangChay item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO TourDangChay (NgayBatDau, TrangThaiTour, TourID, HuongDanVienID) VALUES (@NgayBatDau, @TrangThaiTour, @TourID, @HuongDanVienID)", connection))
                {
                    command.Parameters.AddWithValue("@NgayBatDau", item.NgayBatDau);
                    command.Parameters.AddWithValue("@TrangThaiTour", item.TrangThaiTour);
                    command.Parameters.AddWithValue("@TourID", item.TourID);
                    command.Parameters.AddWithValue("@HuongDanVienID", item.HuongDanVienID);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, TourDangChay item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE TourDangChay SET NgayBatDau = @NgayBatDau, TrangThaiTour = @TrangThaiTour, TourID = @TourID, HuongDanVienID = @HuongDanVienID WHERE TourDangChayID = @TourDangChayID", connection))
                {
                    command.Parameters.AddWithValue("@NgayBatDau", item.NgayBatDau);
                    command.Parameters.AddWithValue("@TrangThaiTour", item.TrangThaiTour);
                    command.Parameters.AddWithValue("@TourID", item.TourID);
                    command.Parameters.AddWithValue("@HuongDanVienID", item.HuongDanVienID);
                    command.Parameters.AddWithValue("@TourDangChayID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM TourDangChay WHERE TourDangChayID = @TourDangChayID", connection))
                {
                    command.Parameters.AddWithValue("@TourDangChayID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
