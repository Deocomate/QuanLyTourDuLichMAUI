using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagementMAUI.Model
{
    internal class DaiLyDAO : DAO
    {
        public static List<DaiLy> List()
        {
            var list = new List<DaiLy>();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM DaiLy", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new DaiLy
                        {
                            DaiLyID = reader.GetInt32(reader.GetOrdinal("DaiLyID")),
                            TenDaiLy = reader.GetString(reader.GetOrdinal("TenDaiLy")),
                            DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                            SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static DaiLy Find(int id)
        {
            var item = new DaiLy();
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM DaiLy WHERE DaiLyID = @DaiLyID", connection))
                {
                    command.Parameters.AddWithValue("@DaiLyID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new DaiLy
                            {
                                DaiLyID = reader.GetInt32(reader.GetOrdinal("DaiLyID")),
                                TenDaiLy = reader.GetString(reader.GetOrdinal("TenDaiLy")),
                                DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                                SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                        }
                    }
                }
            }
            return item;
        }

        public static int Create(DaiLy item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO DaiLy (TenDaiLy, DiaChi, SoDienThoai, Email) VALUES (@TenDaiLy, @DiaChi, @SoDienThoai, @Email)", connection))
                {
                    command.Parameters.AddWithValue("@TenDaiLy", item.TenDaiLy);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }

        public static int Update(int id, DaiLy item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE DaiLy SET TenDaiLy = @TenDaiLy, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email WHERE DaiLyID = @DaiLyID", connection))
                {
                    command.Parameters.AddWithValue("@TenDaiLy", item.TenDaiLy);
                    command.Parameters.AddWithValue("@DiaChi", item.DiaChi);
                    command.Parameters.AddWithValue("@SoDienThoai", item.SoDienThoai);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@DaiLyID", id);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM DaiLy WHERE DaiLyID = @DaiLyID", connection))
                {
                    command.Parameters.AddWithValue("@DaiLyID", id);
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            return rowAffected;
        }
    }
}
