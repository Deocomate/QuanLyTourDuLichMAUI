using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class TourDAO : DAO
    {
        public static List<Tour> List()
        {
            var list = new List<Tour>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Tour", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new Tour
                        {
                            TourID = reader.GetInt32(reader.GetOrdinal("TourID")),
                            TenTour = reader.GetString(reader.GetOrdinal("TenTour")),
                            ThoiLuongTour = reader.GetInt32(reader.GetOrdinal("ThoiLuongTour")),
                            PhuongTienTour = reader.GetString(reader.GetOrdinal("PhuongTienTour")),
                            DiaDiem = reader.GetString(reader.GetOrdinal("DiaDiem")),
                            LichTrinhChiTiet = reader.GetString(reader.GetOrdinal("LichTrinhChiTiet")),
                            HinhAnhTour = reader.GetString(reader.GetOrdinal("HinhAnhTour")),
                            MoTaTour = reader.GetString(reader.GetOrdinal("MoTaTour")),
                            GiaTourDaiLy = (float)reader.GetDouble(reader.GetOrdinal("GiaTourDaiLy")),
                            GiaTourBanLe = (float)reader.GetDouble(reader.GetOrdinal("GiaTourBanLe")),
                            DaiLyID = reader.GetInt32(reader.GetOrdinal("DaiLyID"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static Tour Find(int id)
        {
            var item = new Tour();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Tour WHERE TourID = @TourID", connection))
                {
                    command.Parameters.AddWithValue("@TourID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new Tour
                            {
                                TourID = reader.GetInt32(reader.GetOrdinal("TourID")),
                                TenTour = reader.GetString(reader.GetOrdinal("TenTour")),
                                ThoiLuongTour = reader.GetInt32(reader.GetOrdinal("ThoiLuongTour")),
                                PhuongTienTour = reader.GetString(reader.GetOrdinal("PhuongTienTour")),
                                DiaDiem = reader.GetString(reader.GetOrdinal("DiaDiem")),
                                LichTrinhChiTiet = reader.GetString(reader.GetOrdinal("LichTrinhChiTiet")),
                                HinhAnhTour = reader.GetString(reader.GetOrdinal("HinhAnhTour")),
                                MoTaTour = reader.GetString(reader.GetOrdinal("MoTaTour")),
                                GiaTourDaiLy = (float)reader.GetDouble(reader.GetOrdinal("GiaTourDaiLy")),
                                GiaTourBanLe = (float)reader.GetDouble(reader.GetOrdinal("GiaTourBanLe")),
                                DaiLyID = reader.GetInt32(reader.GetOrdinal("DaiLyID"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(Tour item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Tour (TenTour, ThoiLuongTour, PhuongTienTour, DiaDiem, LichTrinhChiTiet, HinhAnhTour, MoTaTour, GiaTourDaiLy, GiaTourBanLe, DaiLyID) VALUES (@TenTour, @ThoiLuongTour, @PhuongTienTour, @DiaDiem, @LichTrinhChiTiet, @HinhAnhTour, @MoTaTour, @GiaTourDaiLy, @GiaTourBanLe, @DaiLyID)", connection))
                {
                    command.Parameters.AddWithValue("@TenTour", item.TenTour);
                    command.Parameters.AddWithValue("@ThoiLuongTour", item.ThoiLuongTour);
                    command.Parameters.AddWithValue("@PhuongTienTour", item.PhuongTienTour);
                    command.Parameters.AddWithValue("@DiaDiem", item.DiaDiem);
                    command.Parameters.AddWithValue("@LichTrinhChiTiet", item.LichTrinhChiTiet);
                    command.Parameters.AddWithValue("@HinhAnhTour", item.HinhAnhTour);
                    command.Parameters.AddWithValue("@MoTaTour", item.MoTaTour);
                    command.Parameters.AddWithValue("@GiaTourDaiLy", item.GiaTourDaiLy);
                    command.Parameters.AddWithValue("@GiaTourBanLe", item.GiaTourBanLe);
                    command.Parameters.AddWithValue("@DaiLyID", item.DaiLyID);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, Tour item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Tour SET TenTour = @TenTour, ThoiLuongTour = @ThoiLuongTour, PhuongTienTour = @PhuongTienTour, DiaDiem = @DiaDiem, LichTrinhChiTiet = @LichTrinhChiTiet, HinhAnhTour = @HinhAnhTour, MoTaTour = @MoTaTour, GiaTourDaiLy = @GiaTourDaiLy, GiaTourBanLe = @GiaTourBanLe, DaiLyID = @DaiLyID WHERE TourID = @TourID", connection))
                {
                    command.Parameters.AddWithValue("@TenTour", item.TenTour);
                    command.Parameters.AddWithValue("@ThoiLuongTour", item.ThoiLuongTour);
                    command.Parameters.AddWithValue("@PhuongTienTour", item.PhuongTienTour);
                    command.Parameters.AddWithValue("@DiaDiem", item.DiaDiem);
                    command.Parameters.AddWithValue("@LichTrinhChiTiet", item.LichTrinhChiTiet);
                    command.Parameters.AddWithValue("@HinhAnhTour", item.HinhAnhTour);
                    command.Parameters.AddWithValue("@MoTaTour", item.MoTaTour);
                    command.Parameters.AddWithValue("@GiaTourDaiLy", item.GiaTourDaiLy);
                    command.Parameters.AddWithValue("@GiaTourBanLe", item.GiaTourBanLe);
                    command.Parameters.AddWithValue("@DaiLyID", item.DaiLyID);
                    command.Parameters.AddWithValue("@TourID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM Tour WHERE TourID = @TourID", connection))
                {
                    command.Parameters.AddWithValue("@TourID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
