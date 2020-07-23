using KanbanBoard.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace KanbanBoard.Framework
{
    public class ToDoColumn
    {
        /// <summary>
        /// Return Column element
        /// </summary>
        /// <returns></returns>
        public static IWebElement FindColumn()
        {
            IWebElement board = Driver.Instance.FindElement(By.CssSelector("#root>div>div>div"));
            IWebElement toDoColumn = board.FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)"));
            return toDoColumn;
        }

        /// <summary>
        /// Return Tickets section
        /// </summary>
        /// <returns></returns>
        public static IWebElement FindTicketsSection()
        {
            IWebElement ticketSection = FindColumn().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-fzoLsD.gmvgXk"));
            return ticketSection;
        }

        /// <summary>
        /// Click Add button to create new Ticket
        /// </summary>
        public static void ClickAddButton()
        {
            try
            {
                IWebElement addButton = FindColumn().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-AxheI.dNrDWH>button"));
                addButton.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Populate forwarded text to the Ticket
        /// </summary>
        /// <param name="text"></param>
        public static void PopulateText(string text)
        {
            try
            {
                IWebElement textField = FindTicketsSection().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-fzoLsD.gmvgXk>div:nth-child(1)>div"));
                textField.Click();
                Thread.Sleep(2000);
                textField.SendKeys(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Check Ticket text
        /// </summary>
        /// <param name="text"></param>
        public static bool CheckText(string text)
        {
            bool check = false;
            try
            {
                IWebElement textField = FindTicketsSection().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-fzoLsD.gmvgXk>div:nth-child(1)>div"));
                check = textField.Text == text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return check;
        }

        /// <summary>
        /// Count number of Tickets in the column
        /// </summary>
        /// <returns></returns>
        public static int CountTickets()
        {
            IWebElement numberField = FindColumn().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-AxheI.dNrDWH>div"));
            int number = Convert.ToInt32(numberField.Text.Substring(1, 1));

            return number;
        }

        /// <summary>
        /// Delete Ticket
        /// </summary>
        public static void ClickDeleteButton()
        {
            try
            {
                IWebElement textField = FindTicketsSection().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-fzoLsD.gmvgXk>div:nth-child(1)>div"));
                textField.Click();

                IWebElement deleteButton = textField.FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-fzoLsD.gmvgXk>div:nth-child(1)>div>button"));
                deleteButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Move added Ticket from 'To Do' to 'In Progress' column
        /// </summary>
        public static void MoveAddedTicketToInProgressColumn()
        {
            try
            {
                IWebElement inProgressSection = InProgressColumn.FindTicketsSection();
                IWebElement toDoSection = FindTicketsSection();
                IWebElement textField = FindTicketsSection().FindElement(By.CssSelector("#root>div>div>div>div:nth-child(1)>div.sc-fzoLsD.gmvgXk>div:nth-child(1)>div"));
                textField.Click();

                Actions action = new Actions(Driver.Instance);
                action.ClickAndHold(toDoSection).Build().Perform();
                Thread.Sleep(1000);
                action.MoveToElement(inProgressSection).Build().Perform();
                Thread.Sleep(1000);
                action.Release().Build().Perform();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}