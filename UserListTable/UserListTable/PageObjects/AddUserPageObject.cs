using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
    }
}
