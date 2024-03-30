using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class KhachHangDAO : DAO
    {
        public static List<KhachHang> List()
        {
            var list = new List<KhachHang>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM KhachHang", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new KhachHang
                        {
                            KhachHangID = reader.GetInt32(reader.GetOrdinal("KhachHangID")),
                            TenKhachHang = reader.GetString(reader.GetOrdinal("TenKhachHang")),
                            GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                            Tuoi = reader.GetInt32(reader.GetOrdinal("Tuoi")),
                            SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            DiaChi = reader.GetString(reader.GetOrdinal("DiaChi"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static KhachHang Find(int id)
        {
            var item = new KhachHang();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM KhachHang WHERE KhachHangID = @KhachHangID", connection))
                {
                    command.Parameters.AddWithValue("@KhachHangID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new KhachHang
                            {
                                KhachHangID = reader.GetInt32(reader.GetOrdinal("KhachHangID")),
                                TenKhachHang = reader.GetString(reader.GetOrdinal("TenKhachHang")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                Tuoi = reader.GetInt32(reader.GetOrdinal("Tuoi")),
                                SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                DiaChi = reader.GetString(reader.GetOrdinal("DiaChi"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(KhachHang item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO KhachHang (TenKhachHang, GioiTinh, Tuoi, SoDienThoai, Email, DiaChi) VALUES (@TenKhachHang, @GioiTinh, @Tuoi, @SoDienThoai, @Email, @DiaChi)", connection))
                {
                    command.Parameters.AddWithValue("@TenKhachHang", item.TenKhachHang);
                    command.Parameters.AddWithValue("@GioiTinh", item.GioiTinh);
                    command.Parameters.AddWithValue("@Tuoi", item.Tuoi);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, KhachHang item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE KhachHang SET TenKhachHang = @TenKhachHang, GioiTinh = @GioiTinh, Tuoi = @Tuoi, SoDienThoai = @SoDienThoai, Email = @Email, DiaChi = @DiaChi WHERE KhachHangID = @KhachHangID", connection))
                {
                    command.Parameters.AddWithValue("@TenKhachHang", item.TenKhachHang);
                    command.Parameters.AddWithValue("@GioiTinh", item.GioiTinh);
                    command.Parameters.AddWithValue("@Tuoi", item.Tuoi);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@KhachHangID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM KhachHang WHERE KhachHangID = @KhachHangID", connection))
                {
                    command.Parameters.AddWithValue("@KhachHangID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
