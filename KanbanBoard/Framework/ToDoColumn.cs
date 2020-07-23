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
            IWebElement board = Driver.Instance.FindElement(By.ClassName("hRBsWH"));
            IWebElement toDoColumn = board.FindElement(By.ClassName("fxWvvr"));
            return toDoColumn;
        }

        /// <summary>
        /// Return Tickets section
        /// </summary>
        /// <returns></returns>
        public static IWebElement FindTicketsSection()
        {
            IWebElement ticketSection = FindColumn().FindElement(By.ClassName("gmvgXk"));
            
            return ticketSection;
        }

        /// <summary>
        /// Click Add button to create new Ticket
        /// </summary>
        public static void ClickAddButton()
        {
            try
            {
                IWebElement addButton = FindColumn().FindElement(By.ClassName("hvJMgY"));
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
                IWebElement textField = FindTicketsSection().FindElement(By.ClassName("jOSNSb"));
                textField.Click();
                textField.SendKeys(text);
                Thread.Sleep(1000);
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
                IWebElement textField = FindTicketsSection().FindElement(By.ClassName("jOSNSb"));
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
            var numberFields = Driver.Instance.FindElements(By.ClassName("dteCCc"));
            int number = Convert.ToInt32(numberFields[0].Text.Substring(1, 1));

            return number;
        }

        /// <summary>
        /// Delete Ticket
        /// </summary>
        public static void ClickDeleteButton()
        {
            try
            {
                IWebElement textField = FindTicketsSection().FindElement(By.ClassName("jOSNSb"));
                textField.Click();
                Thread.Sleep(1000);

                IWebElement deleteButton = Driver.Instance.FindElement(By.ClassName("eSbheu"));
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