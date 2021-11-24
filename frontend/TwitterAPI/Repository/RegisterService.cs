using DBContext;
using Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    //creating the class and implementing the interface
    public  class RegisterService:IRegisterService
    {

        SqlConnection sqlConnection;
        SqlCommand SqlCommand;

        //creating constructor
        public RegisterService()
        {
            sqlConnection = new SqlConnection(ApplicationContext.ConnectionStrings);
        }
        // database connection open  
        public void connectionOpen()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();

        }
        //database connection closed 
        public void closedConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }
      
        //implementing the abstract method 
        public bool UserRegister(Register register)
        {
            bool isSuccess = false;
            try
            {

                using (SqlCommand = new SqlCommand($"INSERT INTO Register VALUES ('" + register.UserName + "','" +
                  register.EmailID + "','" + register.Password + "','" + register.ConfirmPassword + "')", sqlConnection))
                {
                    connectionOpen();

                    SqlCommand.ExecuteNonQuery();
                    isSuccess = true;
                }

            }

            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }
           
            return isSuccess;
        }
        public bool UserTweet(string data)
        {
            bool isSuccess = false;
            try
            {

                using (SqlCommand = new SqlCommand($"INSERT INTO TweetMessage VALUES ('" + data + "')", sqlConnection))
                {
                    connectionOpen();

                    SqlCommand.ExecuteNonQuery();
                    isSuccess = true;
                }

            }

            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }

            return isSuccess;
        }
        public bool UserLogin(Login login)
        {
           bool isSuccess = false;

            try
            {
                using (SqlCommand = new SqlCommand("SELECT * from Register where EmailId='"+ login.EmailID+"'", sqlConnection))
                {
                    connectionOpen();

                    SqlDataReader reader = SqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        if (login.Password.Equals(reader[3]))
                        {
                            isSuccess = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }
            return isSuccess;
        }

        public bool ChangePassword(ChangePassword changePassword)
        {
            bool isSuccess = false;
            try
            {
                using (SqlCommand = new SqlCommand($"UPDATE Register SET Password= '" + changePassword.Password + "',ConfirmPassword='" + changePassword.ConfirmPassword + "' WHERE  EmailId='" + changePassword.EmailID + "'", sqlConnection))
                {
                    connectionOpen();

                  SqlCommand.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }
              return isSuccess;
        }
        public List<string> GetTwitterUsers()
        {
              List<string> _students = new List<string>();
          
            try
            {
                using (SqlCommand = new SqlCommand("SELECT ID,UserName from Register where ID>0", sqlConnection))
                {
                    connectionOpen();

                    SqlDataReader reader = SqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        _students.Add(reader.GetString(1));
                     
                    }
                  
                }
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }

            return _students;

        }
        public bool DeleteUserAccount(int id)
        {
            bool isSuccess = false;
            try
            {
                using (SqlCommand = new SqlCommand($"Delete Register  WHERE Id = {id}", sqlConnection))
                {
                    connectionOpen();

                    SqlCommand.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }
            return isSuccess;
        }
        public bool UserNameUpdation(ChangeUser name)
        {
            bool isSuccess = false;
            try
            {
                using (SqlCommand = new SqlCommand($"UPDATE Register SET UserName= '" + name.ChangeUserName + "' WHERE  EmailId='" + name.EmailID + "' ", sqlConnection))
                {
                    connectionOpen();

                    SqlCommand.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }
            return isSuccess;
        }
        public string ForgetPassword(string email)
        {
            string password = "";
            try
            {
                using (SqlCommand = new SqlCommand("SELECT Password from Register WHERE  EmailId='" + email + "' ", sqlConnection))
                {
                    connectionOpen();

                    password = Convert.ToString(SqlCommand.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            finally
            {
                closedConnection();
            }

            return password;

        }


    }
}
