using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Services_Layer
{
    public class StoredProcedures
    {
        private static string connectionString = "Server = ServerGoesHere; Database = DBGoesHere; User Id = UserIdGoesHere; Password = PasswordGoesHere";

        //Adding stocks
        public string AddSupply(string SupplyName, string SupplyDescription, string SupplyAmount, string SupplyUnit, string Building, string CategoryTitle)
        {
            string result = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand AddOffSupCmd = new SqlCommand("AddOfficeSupply", con);
                    AddOffSupCmd.CommandType = CommandType.StoredProcedure;

                    AddOffSupCmd.Parameters.Add(new SqlParameter("@SupplyName", SupplyName));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@SupplyDescription", SupplyDescription));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@SupplyAmount", SupplyAmount));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@SupplyUnit", SupplyUnit));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@Building", Building));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@CategoryTitle", CategoryTitle));

                    AddOffSupCmd.ExecuteNonQuery();

                    result = result + SupplyName + " " + SupplyDescription + " " + SupplyAmount + " " + SupplyUnit + " " + Building + " " + CategoryTitle;
                }
                catch (SqlException e)
                {
                    return "ERROR: " + e.Message;
                }
            }
            return result;
        }

        //Adding category
        public string AddCategory(string CategoryTitle)
        {
            string result = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand AddOffSupCatCmd = new SqlCommand("AddCategoryTitle", con);
                    AddOffSupCatCmd.CommandType = CommandType.StoredProcedure;

                    AddOffSupCatCmd.Parameters.Add(new SqlParameter("@CategoryTitle", CategoryTitle));

                    AddOffSupCatCmd.ExecuteNonQuery();

                    result = result + "New category " + CategoryTitle;
                }
                catch (SqlException e)
                {
                    return "ERROR: " + e.Message;
                }
            }
            return result;
        }
        //Deleting stock
        public void DeleteOfficeSupply(int supplyID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand EditOffSupCmd = new SqlCommand("DeleteOfficeSupply", con);
                    EditOffSupCmd.CommandType = CommandType.StoredProcedure;

                    EditOffSupCmd.Parameters.Add(new SqlParameter("@SupplyID", supplyID));

                    EditOffSupCmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    //return "ERROR: " + e.Message;
                }
            }
        }
        //Deleting category
        public void DeleteCategory(string categoryTitle)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand EditOffSupCmd = new SqlCommand("DeleteCategory", con);
                    EditOffSupCmd.CommandType = CommandType.StoredProcedure;

                    EditOffSupCmd.Parameters.Add(new SqlParameter("@CategoryTitle", categoryTitle));

                    EditOffSupCmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    //return "ERROR: " + e.Message;
                }
            }
        }
        //Display category for stock
        public List<OfficeSupplies> SeeSupplyCategory()
        {
            string CategoryTitle = "";

            List<OfficeSupplies> result = new List<OfficeSupplies>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand seeOffSupCmd = new SqlCommand("SeeSupplyCategory", con);
                    seeOffSupCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = seeOffSupCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CategoryTitle = reader["CategoryTitle"].ToString();

                            result.Add(new OfficeSupplies()
                            {
                                categoryTitle = CategoryTitle
                            });
                        }
                    }
                }
                catch (SqlException e)
                {
                    //return "ERROR: " + e.Message;
                }
            }
            return result;
        }

        //See stocks
        public List<OfficeSupplies> SeeOfficeSupplies()
        {
            string SupplyID = "";
            string SupplyName = "";
            string SupplyDescription = "";
            string SupplyAmount = "";
            string SupplyUnit = "";
            string Building = "";
            string CategoryTitle = "";

            List<OfficeSupplies> result = new List<OfficeSupplies>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand seeOffSupCmd = new SqlCommand("SeeOfficeSupplies", con);
                    seeOffSupCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = seeOffSupCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SupplyID = reader["SupplyID"].ToString();
                            SupplyName = reader["SupplyName"].ToString();
                            SupplyDescription = reader["SupplyDescription"].ToString();
                            SupplyAmount = reader["SupplyAmount"].ToString();
                            SupplyUnit = reader["SupplyUnit"].ToString();
                            Building = reader["Building"].ToString();
                            CategoryTitle = reader["CategoryTitle"].ToString();

                            Int32.TryParse(SupplyID, out int convertedSupplyID);
                            Int32.TryParse(SupplyAmount, out int convertedSupplyAmount);

                            result.Add(new OfficeSupplies()
                            {
                                supplyID = convertedSupplyID,
                                supplyName = SupplyName,
                                supplyDescription = SupplyDescription,
                                supplyAmount = convertedSupplyAmount,
                                supplyUnit = SupplyUnit,
                                building = Building,
                                categoryTitle = CategoryTitle
                            });
                        }
                    }
                }
                catch (SqlException e)
                {
                    //return "ERROR: " + e.Message;
                }
            }
            return result;
        }
        //Editing stock
        public string ConfirmEdit(string SupplyID, string SupplyName, string SupplyDescription, string SupplyAmount, string SupplyUnit, string Building, string CategoryTitle)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand EditOffSupCmd = new SqlCommand("EditOfficeSupply", con);
                    EditOffSupCmd.CommandType = CommandType.StoredProcedure;

                    EditOffSupCmd.Parameters.Add(new SqlParameter("@SupplyID", SupplyID));
                    EditOffSupCmd.Parameters.Add(new SqlParameter("@SupplyName", SupplyName));
                    EditOffSupCmd.Parameters.Add(new SqlParameter("@SupplyDescription", SupplyDescription));
                    EditOffSupCmd.Parameters.Add(new SqlParameter("@SupplyAmount", SupplyAmount));
                    EditOffSupCmd.Parameters.Add(new SqlParameter("@SupplyUnit", SupplyUnit));
                    EditOffSupCmd.Parameters.Add(new SqlParameter("@Building", Building));
                    EditOffSupCmd.Parameters.Add(new SqlParameter("@CategoryTitle", CategoryTitle));

                    EditOffSupCmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    return "ERROR: " + e.Message;
                }
            }
            return "Stock has been updated";
        }
        //Count stock
        public string CountSupply(int countAmount, string countMonth, string countYear, int supplyID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand AddOffSupCmd = new SqlCommand("CountSupply", con);
                    AddOffSupCmd.CommandType = CommandType.StoredProcedure;

                    AddOffSupCmd.Parameters.Add(new SqlParameter("@CountAmount", countAmount));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@CountMonth", countMonth));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@CountYear", countYear));
                    AddOffSupCmd.Parameters.Add(new SqlParameter("@SupplyID", supplyID));

                    AddOffSupCmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    return "ERROR: " + e.Message;
                }
            }
            return "Counting has been registered";
        }
    }
}
