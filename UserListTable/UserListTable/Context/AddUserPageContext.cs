using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UserListTable.PageObjects;

namespace UserListTable.Context
{
    public class AddUserPageContext
    {
        AddUserPageObject addUser = new AddUserPageObject();
        private IWebDriver driver;

        public AddUserPageContext(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void EnterFirstName(string firstName)
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => addUser.txtFirstName.Enabled);
            addUser.txtFirstName.SendKeys(firstName);
        }
    }
}
