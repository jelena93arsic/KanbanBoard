using KanbanBoard.Framework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace KanbanBoard.Tests
{
    public class TestClassBase
    {
        [TestInitialize]
        public void Setup()
        {
            Driver.Initialize();
        }

        /// <summary>
        /// Go to forwarded URL
        /// </summary>
        /// <param name="url"></param>
        public static void GoToURL(string url)
        {
            Driver.Instance.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Check whether correct board is opened
        /// </summary>
        /// <returns></returns>
        public static bool IsKanbanBoardOpened()
        {
            try
            {
                IWebElement pageHeader = Driver.Instance.FindElement(By.ClassName("hLgJkJ"));
                if (pageHeader.Text == "Kanban Board")
                {
                    Console.WriteLine("Kanban Board is opened.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Kanban Board is not opened.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Close Browser after test
            Driver.Close();
        }
    }
}