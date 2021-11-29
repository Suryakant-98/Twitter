using DBContext;
using Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

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
            //access the database connection
            sqlConnection = new SqlConnection(ApplicationContext.ConnectionStrings);
        }
        // database connection open  
        public void connectionOpen()
        {
            //if the connection is closed then connection will be opened
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();

        }
        //database connection closed 
        public void closedConnection()
        {
            //if the connection is opened then connection will be closed
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }
      
        //implementing the abstract method and passing parameter as a class
        
        public bool UserRegister(Register register)
        {
            bool isSuccess = false;
            //within try block we are writing the code and raise the exceptions
            try
            {
               //inserting data into database by using sql server query
                using (SqlCommand = new SqlCommand($"INSERT INTO Register VALUES ('" + register.UserName + "','" +
                  register.EmailID + "','" + register.Password + "','" + register.ConfirmPassword + "')", sqlConnection))
                {
                    //here opening the connection method called
                    connectionOpen();
                    //executing the command
                    SqlCommand.ExecuteNonQuery();
                    isSuccess = true;
                }

            }
            //handling the execptions
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            //exception will be raised or not this block will always executed
            finally
            {
                //here closing the connection method called
                closedConnection();
            }
           
            return isSuccess;
        }
        //implementing the abstract method 
        public bool UserTweet(string data)
        {
            bool isSuccess = false;
            //within try block we are writing the code and raise the exceptions
            try
            {
                //inserting data into database by using sql server query
                using (SqlCommand = new SqlCommand($"INSERT INTO TweetMessage VALUES ('" + data + "')", sqlConnection))
                {
                    //here opening the connection method called
                    connectionOpen();
                    //executing the command
                    SqlCommand.ExecuteNonQuery();
                    isSuccess = true;
                }

            }
            //handling the execptions
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            // exception will be raised or not this block will always executed
            finally
            {
                //here closing the connection method called
                closedConnection();
            }

            return isSuccess;
        }
        //implementing the abstract method 
        public bool UserLogin(Login login)
        {
           bool isSuccess = false;
            //within try block we are writing the code and raise the exceptions
            try
            {
                //getting data into database by using sql server query
                using (SqlCommand = new SqlCommand("SELECT * from Register where EmailId='"+ login.EmailID+"'", sqlConnection))
                {
                    //here opening the connection method called
                    connectionOpen();
                    //executing the query
                    SqlDataReader reader = SqlCommand.ExecuteReader();
                    //reading the data
                    while (reader.Read())
                    {
                        if (login.Password.Equals(reader[3]))
                        {
                            isSuccess = true;
                        }
                    }
                }
                
            }
            //handling the execptions
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            // exception will be raised or not this block will always executed
            finally
            {
                //here closing the connection method called
                closedConnection();
            }
            return isSuccess;
        }
        //implementing the abstract method 
        public bool ChangePassword(ChangePassword changePassword)
        {
            bool isSuccess = false;
            //within try block we are writing the code and raise the exceptions
            try
            {
                //update the  data into database by using sql server query
                using (SqlCommand = new SqlCommand($"UPDATE Register SET Password= '" + changePassword.Password + "',ConfirmPassword='" + changePassword.ConfirmPassword + "' WHERE  EmailId='" + changePassword.EmailID + "'", sqlConnection))
                {
                    //here opening the connection method called
                    connectionOpen();
                    //executing the query

                    SqlCommand.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            //handling the execptions
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            // exception will be raised or not this block will always executed
            finally
            {
                //here closing the connection method called
                closedConnection();
            }
              return isSuccess;
        }
        //implementing the abstract method 
        public List<string> GetTwitterUsers()
        {
            //creating the list
              List<string> _students = new List<string>();
            //within try block we are writing the code and raise the exceptions
            try
            {
                //getting data into database by using sql server query
                using (SqlCommand = new SqlCommand("SELECT ID,UserName from Register where ID>0", sqlConnection))
                {
                    //here opening the connection method called
                    connectionOpen();
                    //executing the query

                    SqlDataReader reader = SqlCommand.ExecuteReader();
                    //reading the data
                    while (reader.Read())
                    {
                        _students.Add(reader.GetString(1));
                     
                    }
                  
                }
            }
            //handling the execptions
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
            // exception will be raised or not this block will always executed
            finally
            {
                //here closing the connection method called
            }

            return _students;

        }
        /// <summary>
        /// here implementing abstract method 
        /// by using id we can delete record in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>record is deleted</returns>
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
        /// <summary>
        /// here implementing abstract method 
        /// by using username we can update record in database
        /// </summary>
        /// <param name="name"></param>
        /// <returns>record is updated</returns>
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
        /// <summary>
        /// implemeting abstarct method
        /// return password by using email id 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>successfully getting password</returns>
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
        /// <summary>
        /// implemting the abstract method
        /// getting image in table 
        /// </summary>
        /// <returns>it will return image</returns>
        public string ImageChange()
        {

            string image1 = "";
            try
            {

                using (SqlCommand = new SqlCommand($"select * from  UploadProfile  ", sqlConnection))
                {
                    connectionOpen();
                   
                    image1 = Convert.ToString(SqlCommand.ExecuteScalar());
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

            return image1;
        }
    }
}
