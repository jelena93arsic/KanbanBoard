using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace projectSeavus.Framework
{
    public static class Driver
    {
        public static IWebDriver Instance { get; set; }

        /// <summary>
        /// Initialize Chrome and maximaze window
        /// </summary>
        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Instance.Manage().Window.Maximize();
        }

        /// <summary>
        /// Close Chrome
        /// </summary>
        public static void Close()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Instance.Quit();
        }
    }
}