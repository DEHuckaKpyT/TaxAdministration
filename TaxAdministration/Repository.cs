using System;
using System.Collections.Generic;
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
        static SqlConnection connection;

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

        public static void Post(string query)
        {
            SqlCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = query;//"insert into organization (id, name, inn, phone_number) values (1, 'asd', '123', '1233');";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
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
                                prop.SetValue(t, Convert.ChangeType(value, prop.PropertyType), null);
                            }
                            //prop.SetValue(t, value, null);

                        }
                    }
                }
                res.Add(t);
            }
            reader.Close();

            return res;
        }
    }
}
