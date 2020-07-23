using KanbanBoard.Framework.Utils;
using OpenQA.Selenium;
using System;

namespace KanbanBoard.Framework
{
    public class InProgressColumn
    {
        /// <summary>
        /// Return Column element
        /// </summary>
        /// <returns></returns>
        public static IWebElement FindColumn()
        {
            IWebElement board = Driver.Instance.FindElement(By.CssSelector("#root>div>div>div"));
            IWebElement inProgressColumn = board.FindElement(By.CssSelector("#root>div>div>div>div:nth-child(2)"));
            return inProgressColumn;
        }

        /// <summary>
        /// Return Tickets section
        /// </summary>
        /// <returns></returns>
        public static IWebElement FindTicketsSection()
        {
            IWebElement ticketSection = FindColumn().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(2)>div.sc-fzoLsD.bmXcrz"));

            return ticketSection;
        }

        /// <summary>
        /// Count number of Tickets in the column
        /// </summary>
        /// <returns></returns>
        public static int CountTickets()
        {
            IWebElement numberField = FindColumn().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(2)>div.sc-AxheI.ixvuvG>div"));
            int number = Convert.ToInt32(numberField.Text.Substring(1, 1));

            return number;
        }
    }
}