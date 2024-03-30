using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class HuongDanVienDAO : DAO
    {
        public static List<HuongDanVien> List()
        {
            var list = new List<HuongDanVien>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM HuongDanVien", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new HuongDanVien
                        {
                            HuongDanVienID = reader.GetInt32(reader.GetOrdinal("HuongDanVienID")),
                            TenHuongDanVien = reader.GetString(reader.GetOrdinal("TenHuongDanVien")),
                            GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                            NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                            MatKhau = reader.GetString(reader.GetOrdinal("MatKhau"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static HuongDanVien Find(int id)
        {
            var item = new HuongDanVien();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM HuongDanVien WHERE HuongDanVienID = @HuongDanVienID", connection))
                {
                    command.Parameters.AddWithValue("@HuongDanVienID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new HuongDanVien
                            {
                                HuongDanVienID = reader.GetInt32(reader.GetOrdinal("HuongDanVienID")),
                                TenHuongDanVien = reader.GetString(reader.GetOrdinal("TenHuongDanVien")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                                SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(HuongDanVien item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO HuongDanVien (TenHuongDanVien, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, MatKhau) VALUES (@TenHuongDanVien, @GioiTinh, @NgaySinh, @SoDienThoai, @Email, @DiaChi, @MatKhau)", connection))
                {
                    command.Parameters.AddWithValue("@TenHuongDanVien", item.TenHuongDanVien);
                    command.Parameters.AddWithValue("@GioiTinh", item.GioiTinh);
                    command.Parameters.AddWithValue("@NgaySinh", item.NgaySinh);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@MatKhau", item.MatKhau);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, HuongDanVien item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE HuongDanVien SET TenHuongDanVien = @TenHuongDanVien, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SoDienThoai = @SoDienThoai, Email = @Email, DiaChi = @DiaChi, MatKhau = @MatKhau WHERE HuongDanVienID = @HuongDanVienID", connection))
                {
                    command.Parameters.AddWithValue("@TenHuongDanVien", item.TenHuongDanVien);
                    command.Parameters.AddWithValue("@GioiTinh", item.GioiTinh);
                    command.Parameters.AddWithValue("@NgaySinh", item.NgaySinh);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@MatKhau", item.MatKhau);
                    command.Parameters.AddWithValue("@HuongDanVienID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM HuongDanVien WHERE HuongDanVienID = @HuongDanVienID", connection))
                {
                    command.Parameters.AddWithValue("@HuongDanVienID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
