using System;
using System.Collections.Generic;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using NTTQA.Selenium.Classes;
using System.Data;

namespace UL.Selenium.Portal.WERCSmart.Steps.API
{
	class Api
	{
		//internal Table GetTable(string savedAs)
		//{
		//			int i = 0;
		//			var lists = new List<List<string>>();
		//			var dt = new DataTable();
		//			dt.ReadXmlSchema(savedAs);

		//			foreach (DataRow row in dt.Rows)
		//			{
		//				var list = (List<string>)row[i];
		//				lists.Add(list);
		//				i++;
		//			}

		//			var table = new Table(lists[0].ToArray());

		//			for (int x = 1; x < lists.Count; x++)
		//			{
		//				table.AddRow(lists[x].ToArray());
		//			}

		//			return table;
		//		}
		//	}
		//}

		//public static class ExcelUtilitiesEtxensions
		//{
		//	public static Table GetTable(this ExcelUtilities xlu)
		//	{
		//		string[] headers = xlu.Excel_GetRow(0).ToArray();
		//		var table = new Table(headers);

		//		for (int i = 1; i < xlu.Excel_GetNoRows(); i++)
		//		{
		//			table.AddRow(xlu.Excel_GetRow(i).ToArray());
		//		}
		//		return table;
	}
}
