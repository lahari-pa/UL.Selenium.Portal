using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourcePool;
using SafewareReporting;

namespace Wercs.Selenium.PortalUX.Database_Functions
{
	static class dbRetailers
	{

		public static string getGUIDByRetailer(string retailerName)
		{
			SqlConnection conn = null;
			try

			{
				string connectionString = DbUtils.GetConnectionString();
				using (conn = new SqlConnection(connectionString))
				{
					using (var cmd = new SqlCommand("select f_GUID from T_CLIENT where F_NAME like '%" + retailerName  + "%'", conn))
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

		public static string getSupplierGUIDByUsername(string supplierUsername)
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
