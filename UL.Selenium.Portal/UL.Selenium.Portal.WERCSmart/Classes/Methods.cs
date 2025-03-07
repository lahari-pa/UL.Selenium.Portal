namespace UL.Selenium.Portal.WERCSmart.Classes
{
	public static class Methods
	{
		public static bool IsNullOrEmpty(this object compObj)
		{
			if (compObj == null)
			{
				return true;
			}

			if (compObj.GetType() == typeof(string))
			{
				return string.IsNullOrEmpty((string)compObj);
			}

			return compObj == null;
		}
	}
}
