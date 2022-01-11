using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxAdministration
{
    static class Repository
    {
        public static SqlConnection connection;

        public static void Connect()
        {
            try
            {
                connection = new SqlConnection(@"Server=localhost;Database=tax_administration;Trusted_Connection=True;");
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public static async void Close()
        {
            await connection.CloseAsync();
        }

        public static List<T> Get<T>(string query) where T : new()
        {
            List<T> items = null;
            SqlCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                SqlDataReader sqlDataReader = command.ExecuteReader();

                items = Fill<T>(sqlDataReader);

                sqlDataReader.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            return items;
        }

        public static int Post(string query)
        {
            int affectedRows = 0;
            SqlCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = query;//"insert into organization (id, name, inn, phone_number) values (1, 'asd', '123', '1233');";
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            return affectedRows;
        }

        static List<T> Fill<T>(this SqlDataReader reader) where T : new()
        {
            List<T> res = new List<T>();
            while (reader.Read())
            {
                T t = new T();
                for (int inc = 0; inc < reader.FieldCount; inc++)
                {
                    Type type = t.GetType();
                    string name = reader.GetName(inc);
                    PropertyInfo prop = type.GetProperty(name);
                    if (prop != null)
                    {
                        if (name == prop.Name)
                        {
                            var value = reader.GetValue(inc);
                            if (value != DBNull.Value)
                            {
                                Type ty = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                object safeValue = (value == null) ? null : Convert.ChangeType(value, ty);
                                prop.SetValue(t, safeValue, null);
                            }
                        }
                    }
                }
                res.Add(t);
            }
            reader.Close();

            return res;
        }

        public static int Exec(string name,
            string paramName1, object o1,
            string paramName2, object o2
            )
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.Parameters.AddWithValue(paramName1, o1);
            command.Parameters.AddWithValue(paramName2, o2);
            return command.ExecuteNonQuery();
        }

        public static List<T> Exec<T>(string name,
            string paramName1, object o1,
            string paramName2, object o2,
            string paramName3, object o3
            ) where T : new()
        {
            List<T> items = null;
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.Parameters.AddWithValue(paramName1, o1);
            command.Parameters.AddWithValue(paramName2, o2);
            command.Parameters.AddWithValue(paramName3, o3);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            items = Fill<T>(sqlDataReader);

            sqlDataReader.Close();

            return items;
        }

        public static List<T> Exec<T>(string name,
            string paramName1, object o1,
            string paramName2, object o2,
            string paramName3, object o3,
            string paramName4, object o4,
            string paramName5, object o5
            ) where T : new()
        {
            List<T> items = null;
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.Parameters.AddWithValue(paramName1, o1);
            command.Parameters.AddWithValue(paramName2, o2);
            command.Parameters.AddWithValue(paramName3, o3);
            command.Parameters.AddWithValue(paramName4, o4);
            command.Parameters.AddWithValue(paramName5, o5);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            items = Fill<T>(sqlDataReader);

            sqlDataReader.Close();

            return items;
        }
    }
}
