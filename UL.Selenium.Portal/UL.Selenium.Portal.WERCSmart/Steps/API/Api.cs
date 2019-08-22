using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using NTTQA.Selenium.Cache;
using NTTQA.Selenium.Reporting.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using System.Xml;
using NPOI;
using NTTQA.Selenium.Classes;
using System.Data;

namespace UL.Selenium.Portal.WERCSmart.Steps.API
{
	class Api
	{
		internal bool Compare(string xmlSavedAs, string excelSavedAs)
		{
			string xmlFile = Context.GetFromContext(xmlSavedAs).ToString();
			var excelFile = (ExcelUtilities)Context.GetFromContext(excelSavedAs);

			var excelTable = excelFile.GetTable();
			var xmlTable = this.GetTable(xmlSavedAs);


			this.Parse(excelTable, xmlTable);

			return false;
		}

		private void Parse(Table excelTable, Table xmlTable)
		{
			throw new NotImplementedException();
		}

		internal Table GetTable(string savedAs)
		{
			int i = 0;
			var lists = new List<List<string>>();
			var dt = new DataTable();
			dt.ReadXmlSchema(savedAs);

			foreach (DataRow row in dt.Rows)
			{
				var list = (List<string>)row[i];
				lists.Add(list);
				i++;
			}

			var table = new Table(lists[0].ToArray());

			for (int x = 1; x < lists.Count; x++)
			{
				table.AddRow(lists[x].ToArray());
			}

			return table;
		}

		internal string[] ItemSyncRequestBody(List<string> list)
		{
			var result = new List<string> {
				"<upclist>"
			};
			foreach (string upc in list)
			{
				string str = "<upc gtin=\"" + upc.PadLeft(14, '0') + "\" status=\"\" >";
				result.Add(str);
			}
			result.Add("</upclist>");

			return result.ToArray();
		}
	}
}

public static class ExcelUtilitiesEtxensions
{
	public static Table GetTable(this ExcelUtilities xlu)
	{
		string[] headers = xlu.Excel_GetRow(0).ToArray();
		var table = new Table(headers);

		for (int i = 1; i < xlu.Excel_GetNoRows(); i++)
		{
			table.AddRow(xlu.Excel_GetRow(i).ToArray());
		}
		return table;
	}
}
