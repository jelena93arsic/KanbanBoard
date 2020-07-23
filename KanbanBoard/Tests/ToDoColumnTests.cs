using KanbanBoard.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KanbanBoard.Tests
{
    [TestClass]
    public class ToDoColumnTests : TestClassBase
    {
        [TestMethod]
        public void AddNewTicketAndPopulate()
        {
            string testName = "AddNewTicketAndPopulate";
            Console.WriteLine("Test " + testName + " has started.");
            string asserMsg = "";
            bool isTestPassed = false;

            try
            {
                XMLClass.LoadDocument();
                GoToURL(XMLClass.GetUrl());

                if(IsKanbanBoardOpened())
                {
                    ToDoColumn.ClickAddButton();
                    ToDoColumn.PopulateText(XMLClass.GetTicketText());

                    if (ToDoColumn.CheckText(XMLClass.GetTicketText()))
                    {
                        isTestPassed = true;
                        Console.WriteLine("Test passed.");
                    }
                    else
                        Console.WriteLine("Test failed.");
                }
            }
            catch (Exception ex)
            {
                asserMsg = ex.Message;
                Console.WriteLine(asserMsg);
            }
            finally
            {
                Assert.IsTrue(isTestPassed, asserMsg);
            }
        }

        [TestMethod]
        public void CountTicketsNumber()
        {
            string testName = "CountTicketsNumber";
            Console.WriteLine("Test " + testName + " has started.");
            string asserMsg = "";
            bool isTestPassed = false;

            try
            {
                XMLClass.LoadDocument();
                GoToURL(XMLClass.GetUrl());

                if (IsKanbanBoardOpened())
                {
                    int numberBeforeAddingTicket = ToDoColumn.CountTickets();
                    ToDoColumn.ClickAddButton();
                    int numberAfterAddingTicket = ToDoColumn.CountTickets();

                    if (numberAfterAddingTicket == numberBeforeAddingTicket + 1)
                    {
                        isTestPassed = true;
                        Console.WriteLine("Test passed.");
                    }
                    else
                        Console.WriteLine("Test failed.");
                }
            }
            catch (Exception ex)
            {
                asserMsg = ex.Message;
                Console.WriteLine(asserMsg);
            }
            finally
            {
                Assert.IsTrue(isTestPassed, asserMsg);
            }
        }

        [TestMethod]
        public void DeleteAddedTicket()
        {
            string testName = "DeleteAddedTicket";
            Console.WriteLine("Test " + testName + " has started.");
            string asserMsg = "";
            bool isTestPassed = false;

            try
            {
                XMLClass.LoadDocument();
                GoToURL(XMLClass.GetUrl());

                if (IsKanbanBoardOpened())
                {
                    int numberBeforeAddingTicket = ToDoColumn.CountTickets();
                    ToDoColumn.ClickAddButton();

                    ToDoColumn.ClickDeleteButton();
                    int numberAfterDeletingTicket = ToDoColumn.CountTickets();

                    if (numberAfterDeletingTicket == numberBeforeAddingTicket)
                    {
                        isTestPassed = true;
                        Console.WriteLine("Test passed.");
                    }
                    else
                        Console.WriteLine("Test failed.");
                }
            }
            catch (Exception ex)
            {
                asserMsg = ex.Message;
                Console.WriteLine(asserMsg);
            }
            finally
            {
                Assert.IsTrue(isTestPassed, asserMsg);
            }
        }

        [TestMethod]
        public void MoveTicketToInProgressColumn()
        {
            string testName = "MoveTicketToInProgressColumn";
            Console.WriteLine("Test " + testName + " has started.");
            string asserMsg = "";
            bool isTestPassed = false;

            try
            {
                XMLClass.LoadDocument();
                GoToURL(XMLClass.GetUrl());

                if (IsKanbanBoardOpened())
                {
                    ToDoColumn.ClickAddButton();
                    int numberBeforeMovingTicket = ToDoColumn.CountTickets();
                    int numberOfInProgressTickets = InProgressColumn.CountTickets();

                    ToDoColumn.MoveAddedTicketToInProgressColumn();
                    int numberOfToDoTickets = ToDoColumn.CountTickets();
                    int numberAfterMovingTicket = InProgressColumn.CountTickets();

                    if ((numberOfToDoTickets == numberBeforeMovingTicket - 1) && (numberAfterMovingTicket == numberOfInProgressTickets + 1))
                    {
                        isTestPassed = true;
                        Console.WriteLine("Test passed.");
                    }
                    else
                    {
                        Console.WriteLine("Drag and drop is not performed.");
                        Console.WriteLine("Test failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                asserMsg = ex.Message;
                Console.WriteLine(asserMsg);
                Console.WriteLine("Test failed.");
            }
            finally
            {
                Assert.IsTrue(isTestPassed, asserMsg);
            }
        }
    }
}