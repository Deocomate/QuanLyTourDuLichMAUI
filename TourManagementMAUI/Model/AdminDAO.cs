using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class Admin_DAO : DAO
    {
        public static List<Admin_> List()
        {
            var list = new List<Admin_>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Admin_", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID"));
                        var item = new Admin_
                        {
                            AdminID = reader.GetInt32(reader.GetOrdinal("AdminID")),
                            TenDangNhap = reader.GetString(reader.GetOrdinal("TenDangNhap")),
                            MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                            NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID")),
                            NhanVien = NhanVienDAO.Find(NhanVienID),
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static Admin_ Find(int id)
        {
            var item = new Admin_();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Admin_ WHERE AdminID = @AdminID", connection))
                {
                    command.Parameters.AddWithValue("@AdminID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID"));
                            item = new Admin_
                            {
                                AdminID = reader.GetInt32(reader.GetOrdinal("AdminID")),
                                TenDangNhap = reader.GetString(reader.GetOrdinal("TenDangNhap")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                NhanVienID = reader.GetInt32(reader.GetOrdinal("NhanVienID")),
                                NhanVien = NhanVienDAO.Find(NhanVienID),
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(Admin_ item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Admin_ (TenDangNhap, MatKhau, NhanVienID) VALUES (@TenDangNhap, @MatKhau, @NhanVienID)", connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", item.TenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", item.MatKhau);
                    command.Parameters.AddWithValue("@NhanVienID", item.NhanVienID);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, Admin_ item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Admin_ SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, NhanVienID = @NhanVienID WHERE AdminID = @AdminID", connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", item.TenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", item.MatKhau);
                    command.Parameters.AddWithValue("@NhanVienID", item.NhanVienID);
                    command.Parameters.AddWithValue("@AdminID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM Admin_ WHERE AdminID = @AdminID", connection))
                {
                    command.Parameters.AddWithValue("@AdminID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
