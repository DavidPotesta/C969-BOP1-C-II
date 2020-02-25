using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_BOP1_Potesta_David_001243829
{
    class Controller
    {
        private static int UserId;
        private static string UserName;
        private static string UTCdateTimeString = DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss");
        internal static int retrieveUserId()
        {
            return UserId;
        }

        internal static void setUserId(int userId)
        {
            UserId = userId;
        }

        internal static void setUserName(string userName)
        {
            UserName = userName;
        }

        internal static string getUserName()
        {
            return UserName;
        }

        internal static DataSet searchByCustomerName(string customerSearchString)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM customer WHERE customerName LIKE '{customerSearchString}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething && ds.Tables[0].Rows.Count == 1)
                {
                        return ds;
                }
                else
                {
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }
            }
        }

        internal static bool deleteAppointment(int appointmentId)
        {
            try
            {
                flexibleDelete("appointment", "appointmentId", appointmentId);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        internal static DataSet searchByCustomerId(int customerId)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM customer WHERE customerId LIKE '{customerId}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething && ds.Tables[0].Rows.Count == 1)
                {
                    return ds;
                }
                else
                {
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }
            }
        }

        internal static bool insertAppointment(Appointment appointmentInfo)
        {
            if(!CheckAppointmentConflicts(appointmentInfo))
            {
                {
                    using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
                    {
                        con.Open();
                        using (MySqlCommand command = new MySqlCommand($"INSERT INTO appointment (customerId,userId,title,description,location,contact,type,url,start,end,createDate,createdBy,lastUpdateBy) " +
                                                                       $"VALUES ('{appointmentInfo.customerId}','{appointmentInfo.userId}','{appointmentInfo.title}','{appointmentInfo.description}','{appointmentInfo.location}'," +
                                                                       $"'{appointmentInfo.contact}','{appointmentInfo.type}','{appointmentInfo.url}','{appointmentInfo.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}','{appointmentInfo.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}','{UTCdateTimeString}'," +
                                                                       $"'{Controller.getUserName()}','{UTCdateTimeString}')", con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static DataSet getCountryRecordByCountryID(int useThisCountryID)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM country WHERE countryId LIKE '{useThisCountryID}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        //MessageBox.Show("Returned One Country");
                        return ds;
                    }
                    else
                    {
                        MessageBox.Show("Your search returned more than one record.  Please try again with a more specific search.");
                        DataSet emptyDS = new DataSet();
                        return emptyDS;
                    }
                }
                else
                {
                    MessageBox.Show("Your search returned no records.  Please try again.");
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }
            }
        }

        internal static DataSet getCityRecordByCityID(int useThisCityID)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM city WHERE cityId LIKE '{useThisCityID}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        //MessageBox.Show("Returned One City");
                        return ds;
                    }
                    else
                    {
                        MessageBox.Show("Your search returned more than one record.  Please try again with a more specific search.");
                        DataSet emptyDS = new DataSet();
                        return emptyDS;
                    }
                }
                else
                {
                    MessageBox.Show("Your search returned no records.  Please try again.");
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }
            }
        }

        internal static bool deleteCustomer(int currentCustomerId, int currentAddressId, int currentCityId, int currentCountryId)
        {
            try
            {
                // DELETE CUSTOMER
                flexibleDelete("customer", "customerId", currentCustomerId);

                // FIND ADDRESS FROM THIS CUSTOMER AND DELETE
                flexibleDelete("address", "addressId", currentAddressId);

                // FIND CITY FROM THIS CUSTOMER AND DELETE
                flexibleDelete("city", "cityId", currentCityId);

                // FIND COUNTRY FROM THIS CUSTOMER AND DELETE
                flexibleDelete("country", "countryId", currentCountryId);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        internal static bool insertCustomer(Customer customerInfo)
        {
            try
            {
                
                // FIND COUNTRY FROM THIS CUSTOMER AND INSERT
                int foundId = checkIfRecordExistsInDatabase("country", "country", customerInfo.Country);
                if (foundId == 0)
                {
                    // Didn't find the ID in database, so add it and then call checkIfRecordExistsInDatabase to get and set the countryId in the customerInfo object for later use
                    flexibleInsert("country", "country,createDate,createdBy,lastUpdateBy", $"'{customerInfo.Country}','{UTCdateTimeString}','{customerInfo.loggedInUser}','{UTCdateTimeString}'");
                    foundId = checkIfRecordExistsInDatabase("country", "country", customerInfo.Country);
                    customerInfo.countryId = foundId;
                }
                else
                {
                    customerInfo.countryId = foundId;
                }
                // FIND CITY FROM THIS CUSTOMER AND INSERT
                int foundCityId = checkIfRecordExistsInDatabase("city", "city", customerInfo.City);
                if (foundCityId == 0)
                {
                    // Didn't find the ID in database, so add it and then call checkIfRecordExistsInDatabase to get and set the countryId in the customerInfo object for later use
                    flexibleInsert("city", "city,countryId,createDate,createdBy,lastUpdate,lastUpdateBy", $"'{customerInfo.City}','{customerInfo.countryId}','{UTCdateTimeString}','{customerInfo.loggedInUser}','{UTCdateTimeString}','{customerInfo.loggedInUser}'");
                    foundCityId = checkIfRecordExistsInDatabase("city", "city", customerInfo.City);
                    customerInfo.cityId = foundCityId;
                }
                else
                {
                    customerInfo.cityId = foundCityId;
                }
                // FIND ADDRESS FROM THIS CUSTOMER AND INSERT
                flexibleInsert("address", "address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdateBy", $"'{customerInfo.Address}','{customerInfo.Address2}','{customerInfo.cityId}','{customerInfo.PostalCode}','{customerInfo.Phone}','{UTCdateTimeString}','{customerInfo.loggedInUser}','{customerInfo.loggedInUser}'");
                int foundAddressId = checkIfAddressExistsInDatabase(customerInfo.Address,customerInfo.Address2,customerInfo.cityId,customerInfo.PostalCode);
                if (foundAddressId == 0)
                {
                    // Didn't find the addressID in database, so add it and then call checkIfAddressExistsInDatabase to get and set the addressID in the customerInfo object for later use
                    flexibleInsert("address", "address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdateBy", $"'{customerInfo.Address}','{customerInfo.Address2}','{customerInfo.cityId}','{customerInfo.PostalCode}','{customerInfo.Phone}','{UTCdateTimeString}','{customerInfo.loggedInUser}','{customerInfo.loggedInUser}'");
                    foundAddressId = checkIfAddressExistsInDatabase(customerInfo.Address, customerInfo.Address2, customerInfo.cityId, customerInfo.PostalCode);
                    customerInfo.addressId = foundAddressId;
                }
                else
                {
                    customerInfo.addressId = foundAddressId;
                }

                // INSERT CUSTOMER
                flexibleInsert("customer", "customerName,addressId,active,createDate,createdBy,lastUpdateBy", $"'{customerInfo.Name}','{customerInfo.addressId}','1','{UTCdateTimeString}','{customerInfo.loggedInUser}','{customerInfo.loggedInUser}'");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static bool updateAppointment(List<object> appointment)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
                {

                    con.Open();
                    using (MySqlCommand command = new MySqlCommand($"UPDATE appointment set `title` = '{appointment[2]}', `description` = '{appointment[3]}', `location` = '{appointment[4]}', `contact` = '{appointment[5]}',`type` = '{appointment[6]}',`url` = '{appointment[7]}', `start` = '{appointment[8]}', `end` = '{appointment[9]}',`lastUpdate` = '{UTCdateTimeString}',`lastUpdateBy` = '{Controller.UserName}' WHERE appointmentId = '{appointment[10]}';", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        internal static bool updateCustomer(Customer customerInfo)
        {
            try
            {
                // 1. Get all needed IDs:  countryId, cityId, addressId, customerId:
                // 2.  WE WILL NEVER "UPDATE" a COUNTRY or CITY because it IS what it IS.  If a customer moves to a new country, we will add as new INSERT
                string UTCdateTimeString = DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss");
                // FIND COUNTRY FROM THIS CUSTOMER AND INSERT IF NOT ALREADY THERE
                int foundId = checkIfRecordExistsInDatabase("country", "country", customerInfo.Country);
                if (foundId == 0)
                {
                    // Didn't find the ID in database, so add it and then call checkIfRecordExistsInDatabase to get and set the countryId in the customerInfo object for later use
                    flexibleInsert("country", "country,createDate,createdBy,lastUpdateBy", $"'{customerInfo.Country}','{UTCdateTimeString}','{customerInfo.loggedInUser}','{UTCdateTimeString}'");
                    foundId = checkIfRecordExistsInDatabase("country", "country", customerInfo.Country);
                    customerInfo.countryId = foundId;
                }
                else
                {
                    customerInfo.countryId = foundId;
                }
                // FIND CITY FROM THIS CUSTOMER AND INSERT IF NOT ALREADY THERE
                int foundCityId = checkIfRecordExistsInDatabase("city", "city", customerInfo.City);
                if (foundCityId == 0)
                {
                    // Didn't find the ID in database, so add it and then call checkIfRecordExistsInDatabase to get and set the countryId in the customerInfo object for later use
                    flexibleInsert("city", "city,countryId,createDate,createdBy,lastUpdate,lastUpdateBy", $"'{customerInfo.City}','{customerInfo.countryId}','{UTCdateTimeString}','{customerInfo.loggedInUser}','{UTCdateTimeString}','{customerInfo.loggedInUser}'");
                    foundCityId = checkIfRecordExistsInDatabase("city", "city", customerInfo.City);
                    customerInfo.cityId = foundCityId;
                }
                else
                {
                    customerInfo.cityId = foundCityId;
                }


                //NOW WE START TO HAVE TO UPDATE THINGS

                // FIND ADDRESS FROM THIS CUSTOMER AND UPDATE
                int foundAddressId = getAddressId(customerInfo);
                using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
                {
                    con.Open();
                    using (MySqlCommand command = new MySqlCommand($"UPDATE address set address = '{customerInfo.Address}', address2 = '{customerInfo.Address2}', cityId = '{customerInfo.cityId}', postalCode = '{customerInfo.PostalCode}', phone = '{customerInfo.Phone}', lastUpdateBy = '{customerInfo.loggedInUser}' WHERE addressId = '{foundAddressId}';", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }

                // UPDATE CUSTOMER
                using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
                {
                    con.Open();
                    using (MySqlCommand command = new MySqlCommand($"UPDATE customer set customerName = '{customerInfo.Name}' WHERE customerId = '{customerInfo.customerId}';", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static void flexibleDelete(string table, string columnName, int identifier)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
                {
                    con.Open();
                    using (MySqlCommand command = new MySqlCommand("DELETE FROM " + table + " WHERE " + columnName + " = '" + identifier + "'", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }

        internal static void flexibleInsert(string table, string columns, string values)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"INSERT INTO {table} ({columns}) VALUES ({values})", con))
                {
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }


        internal static DataSet getAddressRecordByAddressId(int useThisAddress)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM address WHERE addressId LIKE '{useThisAddress}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        //MessageBox.Show("Returned One Address");
                        return ds;
                    }
                    else
                    {
                        MessageBox.Show("Your search returned more than one record.  Please try again with a more specific search.");
                        DataSet emptyDS = new DataSet();
                        return emptyDS;
                    }
                }
                else
                {
                    MessageBox.Show("Your search returned no records.  Please try again.");
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }
            }
        }
        //This flexible method takes in a table name, a column name and value (as strings),
        //and returns a dataset which includes a customer row
        // A Lambda expression is used to extract only the desired Id (which is the column
        // appended with 'Id' and returns this Id as an int
        internal static int checkIfRecordExistsInDatabase(string table,string column, string value)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {table} WHERE {column} LIKE '{value}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    var foundId = ds.Tables[0].AsEnumerable().
                                    Select(a => new { foundId = a.Field<int>(column+"Id") }).ToList();

                    //return (int)foundId[0].GetType().GetProperty(column+"Id").GetValue(foundId[0], null);
                    return foundId[0].foundId;
                }
                else
                {
                    return 0;
                }
            }
        }

        //This method takes in a Customer Object, returns a dataset which includes a customer row
        // A Lambda expression is used to extract only the AddressId and returns the AddressId
        // as an int
        internal static int getAddressId(Customer customer)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM customer WHERE customerId LIKE '{customer.customerId}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    var foundId = ds.Tables[0].AsEnumerable().
                                    Select(a => new { foundId = a.Field<int>("addressId") }).ToList();

                    //return (int)foundId[0].GetType().GetProperty(column+"Id").GetValue(foundId[0], null);
                    return foundId[0].foundId;
                }
                else
                {
                    return 0;
                }
            }
        }
        //This method takes in a Customer Name string, returns a customerId
        // A Lambda expression is used to extract only the CustomerId and returns the CustomerId
        // as an int
        internal static int getCustomerId(string customerName)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM customer WHERE customerName LIKE '{customerName}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    var foundId = ds.Tables[0].AsEnumerable().
                                    Select(a => new { foundId = a.Field<int>("customerId") }).ToList();

                    return foundId[0].foundId;
                }
                else
                {
                    return 0;
                }
            }
        }

        //This method takes in a userId string, returns a userName
        // A Lambda expression is used to extract only the userName and returns the userName
        // as a string
        internal static string getUserNameFromDB(int userId)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM user WHERE userId LIKE '{userId}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    var foundId = ds.Tables[0].AsEnumerable().
                                    Select(a => new { foundId = a.Field<string>("userName") }).ToList();

                    return foundId[0].foundId;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        //This is a method to check multiple columns to ensure that an address is not duplicated
        // Checks for: Unique address and address2 combinations for Apartment number with same street address
        // Different customers at existing addresses will not duplicate an address, but use existing addressID
        // A Lambda expression is used to extract only the AddressId if it exists
        // and returns the AddressId as an int

        internal static int checkIfAddressExistsInDatabase(string address, string address2, int cityId, string postalCode)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM address WHERE address LIKE '{address}' AND address2 LIKE '{address2}' AND cityId LIKE '{cityId}' AND postalCode LIKE '{postalCode}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool returnedSomething = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (returnedSomething)
                {
                    var addressId = ds.Tables[0].AsEnumerable().
                        Select(a => new { addressId = a.Field<int>("addressId") }).ToList();
                    return (int)addressId[0].GetType().GetProperty("addressId").GetValue(addressId[0], null);
                }
                else
                {
                    return 0;
                }
            }
        }

        internal static bool CheckAppointmentConflicts(Appointment appointmentInfo)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                //MySqlCommand cmd = new MySqlCommand($"SELECT * FROM appointment WHERE start < '{appointmentInfo.end}' AND end > '{appointmentInfo.start}' AND customerId LIKE '{appointmentInfo.customerId}'");
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM appointment WHERE '{appointmentInfo.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' > start AND '{appointmentInfo.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' < end AND userId LIKE '{appointmentInfo.userId}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool conflictFound = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (conflictFound)
                {
                    MessageBox.Show("There is a conflict with another appointment.  Please modify your appointment time for this appointment");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        internal static bool ValidateTextBoxes(Form form)
        {
            bool validation = true;
            foreach (Control c in form.Controls)
            {
                if (c is TextBox && (c.Name != "txtCustomerAddress2" && c.Name != "txtCustomerUpdatedBy"))
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        MessageBox.Show(c.Name + " cannot be empty");
                        validation = false;
                    }

                }
             }
            return validation;
        }

        internal static bool ValidateDateTime(DateTimePicker start, DateTimePicker end)
        {
            bool validation = true;
            if(start.Value > end.Value)
            {
                MessageBox.Show("Start Time cannot be later than End Time");
                validation = false;
            }
            if(start.Value < DateTime.Now || end.Value < DateTime.Now)
            {
                MessageBox.Show("Start Time or End Time cannot occur in the past");
                validation = false;
            }
            if (start.Value.Hour < 8 || start.Value.Hour >= 17 || (end.Value.Hour >= 17 && end.Value.Minute > 1))
            {
                MessageBox.Show("Your times must be during business hours of 08:00AM and 05:00PM");
                validation = false;
            }
            return validation;
        }

        internal static DataSet ReportAppointmentTypeByMonth()
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT MONTH(start),type,COUNT(*) FROM appointment GROUP BY MONTH(start)");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                         return ds;
                    }
                    else
                    {
                        DataSet emptyDS = new DataSet();
                        return emptyDS;
                    }
                
            }
        }

        internal static DataSet ReportConsultantScheduleByConsultant()
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT userId,start,end FROM appointment ORDER BY MONTH(customerId);");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }

            }
        }

        internal static DataSet ReportFindLongAppointments()
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT userId,start,end FROM appointment WHERE TIMEDIFF(end,start) > '02:59:00' ORDER BY userId;");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataSet emptyDS = new DataSet();
                    return emptyDS;
                }

            }
        }


    }
}
