using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UserListTable.Model;
using Assert = NUnit.Framework.Assert;
using UserListTable.Context;
using shortid;

namespace UserListTable.Test
{
    public class Base
    {
        private IWebDriver driver;
        private AddUserPageContext addUser;

        public Base(IWebDriver driver)
        {
            this.driver = driver;
            this.addUser = new AddUserPageContext(this.driver);
        }

        IWebElement txtFirstName => driver.FindElement(By.Name("FirstName"));
        IWebElement txtLastName => driver.FindElement(By.Name("LastName"));
        IWebElement txtUserName => driver.FindElement(By.Name("UserName"));
        IWebElement txtPassword => driver.FindElement(By.Name("Password"));
        IWebElement radioCustomerA => driver.FindElement(By.CssSelector("input[value = '15']"));
        IWebElement radioCustomerB => driver.FindElement(By.CssSelector("input[value = '16']"));
        IWebElement selectRole => driver.FindElement(By.Name("RoleId"));
        IWebElement txtEmail => driver.FindElement(By.Name("Email"));
        IWebElement txtCell => driver.FindElement(By.Name("Mobilephone"));
        IWebElement saveBtn => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/button[2]"));
        IWebElement table => driver.FindElement(By.XPath("/html/body/table/tbody"));
        IWebElement btnAddUser => driver.FindElement(By.XPath("//button[text()=' Add User']"));

        public void Click_Add_User()
        {
            btnAddUser.Click();
        }

        public void CompleteUserForm(User user)
        {
            ClearForm();

            txtFirstName.SendKeys(user.FirstName);
            txtLastName.SendKeys(user.Lastname);

            string id = ShortId.Generate();
            txtUserName.SendKeys(user.Username + id.ToString());

            txtPassword.SendKeys(user.Password);

            try
            {
                if (user.Customer.Equals("Company AAA"))
                {
                    radioCustomerA.Click();
                }
                else if (user.Customer.Equals("Company BBB"))
                {
                    radioCustomerB.Click();
                }
                else
                {
                    Assert.Fail("Company does not exist");
                }
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }

            selectRole.SendKeys(user.Role);
            txtEmail.SendKeys(user.Email);
            txtCell.SendKeys(user.Cell);
            saveBtn.Click();
        }

        public void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtCell.Clear();
        }

        public string GetTableData()
        {
           return table.Text;
        }
    }
}
