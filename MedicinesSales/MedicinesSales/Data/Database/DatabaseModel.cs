﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using MedicinesSales.Data.Model;
using MedicinesSales.Data.Other;


namespace MedicinesSales.Data.Database
{


    class DatabaseModel
    {
       static private string connString = "server=localhost;user=root;database=my_pharmacy;password=kot9820098teeh1234;";

       public MySqlConnection connection;
       private MySqlCommand command;

        public DatabaseModel() {
            connection = new MySqlConnection(connString);
            connection.Open();
        }

        #region verification account
        public bool CheckLogin(string login)
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
        public bool CheckMatchAccount(string login, string password)
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

        public void DeleteAccount(string login)
        {
            string query = "DELETE FROM `account` WHERE login=@login";
            command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@login",login);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void AddAccount(string login, string password)
        {
            string query = "INSERT INTO account(login, password) VALUES (@login, @password)";
            command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@login",login);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public EmployeeProfileModel GetProfileEmployee(int id_employee)
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
            EmployeeProfileModel profileEmployee = new EmployeeProfileModel();

            dr.Read();

            profileEmployee.firstName =  dr[1].ToString();
            profileEmployee.lastName =   dr[2].ToString();
            profileEmployee.middleName = dr[3].ToString();
            profileEmployee.age =  dr[4].ToString();
            profileEmployee.photo = ToolManager.byteArrayToImage((Byte[]) dr[5]);
            profileEmployee.email =  dr[6].ToString();
            profileEmployee.post =   dr[7].ToString();
            profileEmployee.status = dr[8].ToString();

            command.Dispose();
            return profileEmployee;

        }
        public HashSet <SearchItemModel> GetMedicines()
        {
            string query = "SELECT id, name, description FROM medicine";
            command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();
            HashSet <SearchItemModel> items = new HashSet<SearchItemModel>();
            SearchItemModel item;

            while (reader.Read())
            {
                item = new SearchItemModel();
                item.id = (int) reader.GetValue(0);
                item.title = reader.GetValue(1).ToString();
                item.description = reader.GetValue(2).ToString();

                items.Add(item);
            }
            command.Dispose();
            return items;
        }
        public HashSet<SearchItemModel> FindMedicines(string nameMedicine)
        {
            string query = "SELECT id, name, description FROM medicine WHERE name RLIKE @regex";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@regex", nameMedicine);

            MySqlDataReader reader = command.ExecuteReader();
            HashSet<SearchItemModel> items = new HashSet<SearchItemModel>();
            SearchItemModel item;

            while (reader.Read())
            {
                item = new SearchItemModel();
                item.id = (int)reader.GetValue(0);
                item.title = reader.GetValue(1).ToString();
                item.description = reader.GetValue(2).ToString();

                items.Add(item);
            }
            command.Dispose();
            return items;
        }
        public void DeleteMedicine (SearchItemModel medicine){
            string query = "DELETE FROM `medicine` WHERE id=@id_item";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_item", medicine.id);
            command.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
