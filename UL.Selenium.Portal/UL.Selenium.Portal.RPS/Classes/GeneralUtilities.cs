using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;

namespace UL.Selenium.Portal.RPS.Classes
{
    public static class GeneralUtilities
    {

        public static void WaitForLoadingToFinish()
        {
            int i = 0;

            while (i < 10)
            {
                IWebElement PaceLoadingBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='pace pace-active']"), 2);
                IWebElement PaceLoadingBar_Inactive = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[contains(@class,'pace-inactive')]"), 2);

                if (PaceLoadingBar == null && PaceLoadingBar_Inactive != null)
                {
                    break;
                }
                else
                {
                    i++;
                    Delay.Seconds(1);
                }
            }
        }

        public static string ClassAttribute(this IWebElement el)
        {
            return el.GetAttribute("class");
        }

        public static bool NotNullAndDisplayed(this IWebElement el)
        {
            return el != null && el.Displayed;
        }

        public static FileInfo[] GetDownloads()
        {
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            DirectoryInfo downloads = new DirectoryInfo(downloadsFolder);
            return downloads.GetFiles();

        }

        public static Bitmap CreateBitmapFromFile(string file)
        {
            return new Bitmap(file);
        }

        public static bool CompareBitmaps(Bitmap bitmap1, Bitmap bitmap2)
        {
            return GeneralFunctions.CompareImages(bitmap1, bitmap2);
        }

        public static string ConvertTextToNoSpaceString(string orginalString)
        {
            string newStringUpdated1 = orginalString.Replace("\n", "");
            string newStringUpdated2 = newStringUpdated1.Replace("\t", "");
            string newStringUpdated3 = newStringUpdated2.Replace("\r", "");
            string newStringUpdated4 = newStringUpdated3.Replace(" ", "");
            return newStringUpdated4;

        }


        public static void OpenNewTabAndNavigateTo(string url)
        {
            string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
            Context.AddToContext("MainWindowHandle", currentHandle);
            ((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.open();");
            SeleniumBrowser.WebBrowser.SwitchTo().Window(SeleniumBrowser.WebBrowser.WindowHandles.Last());
            if (url.ToLower().Contains("savedas"))
            {
                url = (string)Context.GetFromContext(url);
            }
            SeleniumBrowser.WebBrowser.Url = url;
            SeleniumBrowser.WebBrowser.WaitForPageLoad();
        }

        public static Bitmap CreateBitmapFromURL(string url)
        {
            WebClient myClient = new WebClient();
            Stream myStream = myClient.OpenRead(url);
            return new Bitmap(myStream);
        }

        public static void openPNGfromFile(string file)
        {
            System.Diagnostics.Process.Start(file);

        }

        public static Dictionary<string, string> ConvertTwoListsToDictonary(List<string> keys, List<string> values)
        {
            var dictionary = keys.Zip(values, (k, v) => new { Key = k, Value = v })
                      .ToDictionary(x => x.Key, x => x.Value);
            return dictionary;
        }

        public static List<string> ConvertDictionaryToList(Dictionary<string, string> input)
        {
            var keysAsList = input.Keys.ToList();

            List<string> foundDataList = new List<string>();
            foreach (var item in keysAsList)
            {
                string value = input[item];
                string fullText = item + ": " + value;
                foundDataList.Add(fullText);
            }
            return foundDataList;
        }

        public static bool LoadingBarShowing()
        {
            int i = 0;
            while (i < 50)
            {

                if (SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath("pace pace-active"), 0) != null)
                {
                    return true;
                }
                i++;
                Delay.Seconds(0.1);
            }
            return false;

        }

        public static string SelectRandomFromListOfStrings(List<string> list)
        {
            var random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }


        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }

        public static bool DeleteFileFromDownloadsFolder(string fileName)
        {
            string downloadsFolder = KnownFolders.GetPath(KnownFolder.Downloads);
            Report.Info("Deleting any existing files with name: " + fileName + " in the directory: " + downloadsFolder + ".");
            var files = Directory.GetFiles(downloadsFolder, "*" + fileName, SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                try
                {
                    Report.Info("Deleting: " + file);
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    Report.Error("ERROR DELETING FILE: " + ex.Message);
                }
            }

            if (!Directory.GetFiles(downloadsFolder, "*" + fileName, SearchOption.TopDirectoryOnly).Any())
            {
                return true;
            }
            return false;
        }

        public static string GenerateRandomAlphanumericStric(int strLength)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[strLength];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}
