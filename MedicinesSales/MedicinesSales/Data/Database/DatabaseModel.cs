using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Controls;


namespace MedicinesSales.Data.Database
{


    class DatabaseModel
    {
       static private string connString = "server=localhost;user=root;database=my_pharmacy;password=kot9820098teeh1234;";

       static public MySqlConnection connection;
       static private MySqlCommand command;

        public DatabaseModel() {
            connection = new MySqlConnection(connString);
            connection.Open();
        }

        #region verification account
        public static bool CheckLogin(string login)
        {
            string query = "SELECT COUNT(*) FROM account WHERE login = @login";
            command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@login", login);

            Int32 countAccounts = Convert.ToInt32(command.ExecuteScalar());
            if (countAccounts == 0)
            {
                command.Dispose();
                return false;
            }

            else { command.Dispose(); return true; }
        }
        public static bool CheckMatchAccount(string login, string password)
        {
            string query = "SELECT login, password FROM account WHERE login= @login";
            command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@login",login);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if ((reader["login"].ToString() == login) && (reader["password"].ToString() == password))
                {
                    reader.Close();
                    command.Dispose();
                    return true;
                }
            }
            command.Dispose();
            return false;
        }
        #endregion

        public static void DeleteAccount(string login)
        {
            string query = "DELETE FROM `account` WHERE login=@login";
            command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@login",login);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public static void AddAccount(string login, string password)
        {
            string query = "INSERT INTO account(login, password) VALUES (@login, @password)";
            command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@login",login);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public static ProfileEmployee GetProfileEmployee(int id_employee)
        {
            string query = "SELECT employee.id, employee.first_name, employee.last_name, employee.middle_name, employee.age, employee.employee_photo, account.email, employee_post.post, employee_status.status " +
                           "FROM employee " +
                           "LEFT JOIN account ON employee.account=account.id " +
                           "LEFT JOIN employee_post ON employee.employee_post_id = employee_post.id " +
                           "LEFT JOIN employee_status ON employee.employee_status_id = employee_status.id " +
                           "WHERE employee.id = @id_employee";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_employee", id_employee);

            MySqlDataReader dr = command.ExecuteReader();
            ProfileEmployee profileEmployee = new ProfileEmployee();

            dr.Read();
            profileEmployee.id = (int) dr[0];
            profileEmployee.firstName =  (string)dr[1];
            profileEmployee.lastName =   (string)dr[2].ToString();
            profileEmployee.middleName = (string)dr[3].ToString();
            profileEmployee.age =  (int)dr[4];
            profileEmployee.photo = (Byte[]) dr[5];
            profileEmployee.email = (string)dr[6];
            profileEmployee.post = (string)dr[7];
            profileEmployee.status = (string)dr[8];

            command.Dispose();
            return profileEmployee;

        }
    }
}
