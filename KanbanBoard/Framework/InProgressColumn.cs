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
            IWebElement board = Driver.Instance.FindElement(By.ClassName("hRBsWH"));
            var inProgressColumn = board.FindElements(By.ClassName("fxWvvr"));

            return inProgressColumn[1];
        }

        /// <summary>
        /// Return Tickets section
        /// </summary>
        /// <returns></returns>
        public static IWebElement FindTicketsSection()
        {
            IWebElement ticketSection = FindColumn().FindElement(By.ClassName("bmXcrz"));
            return ticketSection;
        }

        /// <summary>
        /// Count number of Tickets in the column
        /// </summary>
        /// <returns></returns>
        public static int CountTickets()
        {
            var numberFields = Driver.Instance.FindElements(By.ClassName("dteCCc"));
            int number = Convert.ToInt32(numberFields[1].Text.Substring(1, 1));

            return number;
        }
    }
}