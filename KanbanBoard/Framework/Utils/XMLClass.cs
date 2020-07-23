using System.IO;
using System.Xml;

namespace KanbanBoard.Framework
{
    public class XMLClass
    {
        static XmlDocument DataDocument = new XmlDocument();

        /// <summary>
        /// Load Document containing Test Data
        /// </summary>
        public static void LoadDocument()
        {
            string fullPath = "..\\..\\..\\Tests\\TestDataDocument.xml";
            DataDocument.Load(fullPath);
        }

        /// <summary>
        /// Get URL value from XML
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            XmlNodeList elemList = DataDocument.GetElementsByTagName("url");
            return elemList[0].InnerXml;
        }

        /// <summary>
        /// Get Ticket Text value from XML
        /// </summary>
        /// <returns></returns>
        public static string GetTicketText()
        {
            XmlNodeList elemList = DataDocument.GetElementsByTagName("ticketText");
            return elemList[0].InnerXml;
        }
    }
}