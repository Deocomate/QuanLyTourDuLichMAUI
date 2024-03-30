using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class NhanVienDAO : DAO
    {
        public static List<NhanVien> List()
        {
            var list = new List<NhanVien>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM NhanVien", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new NhanVien
                        {
                            NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID")),
                            TenNhanVien = reader.GetString(reader.GetOrdinal("TenNhanVien")),
                            GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                            NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                            PhongBan = reader.GetString(reader.GetOrdinal("PhongBan")),
                            MatKhau = reader.GetString(reader.GetOrdinal("MatKhau"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static NhanVien Find(int id)
        {
            var item = new NhanVien();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE NhanVienID = @NhanVienID", connection))
                {
                    command.Parameters.AddWithValue("@NhanVienID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new NhanVien
                            {
                                NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID")),
                                TenNhanVien = reader.GetString(reader.GetOrdinal("TenNhanVien")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                                SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                                PhongBan = reader.GetString(reader.GetOrdinal("PhongBan")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(NhanVien item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO NhanVien (TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, PhongBan, MatKhau) VALUES (@TenNhanVien, @GioiTinh, @NgaySinh, @SoDienThoai, @Email, @DiaChi, @PhongBan, @MatKhau)", connection))
                {
                    command.Parameters.AddWithValue("@TenNhanVien", item.TenNhanVien);
                    command.Parameters.AddWithValue("@GioiTinh", item.GioiTinh);
                    command.Parameters.AddWithValue("@NgaySinh", item.NgaySinh);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@PhongBan", item.PhongBan);
                    command.Parameters.AddWithValue("@MatKhau", item.MatKhau);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, NhanVien item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE NhanVien SET TenNhanVien = @TenNhanVien, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SoDienThoai = @SoDienThoai, Email = @Email, DiaChi = @DiaChi, PhongBan = @PhongBan, MatKhau = @MatKhau WHERE NhanVienID = @NhanVienID", connection))
                {
                    command.Parameters.AddWithValue("@TenNhanVien", item.TenNhanVien);
                    command.Parameters.AddWithValue("@GioiTinh", item.GioiTinh);
                    command.Parameters.AddWithValue("@NgaySinh", item.NgaySinh);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@PhongBan", item.PhongBan);
                    command.Parameters.AddWithValue("@MatKhau", item.MatKhau);
                    command.Parameters.AddWithValue("@NhanVienID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM NhanVien WHERE NhanVienID = @NhanVienID", connection))
                {
                    command.Parameters.AddWithValue("@NhanVienID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
