using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserListTable.PageObjects
{
    public class AddUserPageObject
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/form/table/tbody/tr[1]/td[2]/input")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtUserName { get; set; }



        //IWebElement txtFirstName => driver.FindElement(By.Name("FirstName"));
        //IWebElement txtLastName => driver.FindElement(By.Name("LastName"));
        //IWebElement txtUserName => driver.FindElement(By.Name("UserName"));
        //IWebElement txtPassword => driver.FindElement(By.Name("Password"));
        //IWebElement radioCustomerA => driver.FindElement(By.CssSelector("input[value = '15']"));
        //IWebElement radioCustomerB => driver.FindElement(By.CssSelector("input[value = '16']"));
        //IWebElement selectRole => driver.FindElement(By.Name("RoleId"));
        //IWebElement txtEmail => driver.FindElement(By.Name("Email"));
        //IWebElement txtCell => driver.FindElement(By.Name("Mobilephone"));
        //IWebElement saveBtn => driver.FindElement(By.ClassName("btn btn-success"));
    }
}
