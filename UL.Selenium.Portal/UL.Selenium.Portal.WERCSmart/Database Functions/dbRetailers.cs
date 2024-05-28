using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UL.Selenium.Portal.WERCSmart.Database_Functions
{
	static class DbRetailers
	{

		public static string GetGUIDByRetailer(string retailerName)
		{
			SqlConnection conn = null;
			try

			{
				string connectionString = DbUtils.GetConnectionString();
				using (conn = new SqlConnection(connectionString))
				{
					using (var cmd = new SqlCommand("select f_GUID from T_CLIENT where F_NAME like '%" + retailerName + "%'", conn))
					{
						conn.Open();
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								return reader["f_GUID"].ToString();
							}
						}
					}
				}

				return null;
			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
				if ((conn != null) && (conn.State != ConnectionState.Closed))
				{
					conn.Close();
				}
			}
		}

		public static string GetSupplierGUIDByUsername(string supplierUsername)
		{
			SqlConnection conn = null;
			try

			{
				string connectionString = DbUtils.GetConnectionString();


				using (conn = new SqlConnection(connectionString))
				{
					using (var cmd = new SqlCommand("select f_Supplier_GUID from t_user where f_email = '" + supplierUsername + "'", conn))
					{
						conn.Open();
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								return reader["f_Supplier_GUID"].ToString();
							}
						}
					}
				}

				return null;
			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
				if ((conn != null) && (conn.State != ConnectionState.Closed))
				{
					conn.Close();
				}
			}
		}


	}
}
