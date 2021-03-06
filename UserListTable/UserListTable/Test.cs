using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using UserListTable.Test;
using System.IO;
using System.Diagnostics;
using System.Linq;
using UserListTable;
using Newtonsoft.Json;
using UserListTable.Model;
using System.Text.RegularExpressions;
using System.Collections.Generic;

[TestClass]
public class Test
{
    private IWebDriver driver;
    string url = "http://www.way2automation.com/angularjs-protractor/webtables/";
    Common common = new Common();

    [OneTimeSetUp]
    public void TestMethod1()
    {
        Process p = new Process();
        var processes = Process.GetProcessesByName("chromedriver.exe");
        processes.ToList().ForEach(x => x.Kill());
        var dir = Directory.GetCurrentDirectory();

        driver = new ChromeDriver(dir);
        driver.Navigate().GoToUrl(url);
    }

    [Test, Order(1)]
    public void Test1_Check_Url()
    {
        string currentURL = driver.Url.ToString();
        Assert.AreEqual(url, currentURL.ToString());
    }

    [Test, Order(2)]
    public void Test2_Check_Table()
    {
        bool table = driver.FindElement(By.ClassName("smart-table")).Displayed;
        Assert.IsTrue(table);
    }

    [Test, Order(3)]
    public void Test3_Add_User()
    {
        var content = common.ReadFile("Data/UserTestData.json");
        var users = JsonConvert.DeserializeObject<User[]>(content);

        string filePath = System.IO.Directory.GetCurrentDirectory();
        Base webTable = new Base(driver);

        users.ToList().ForEach(user =>
        {
            webTable.Click_Add_User();
            bool addUserForm = driver.FindElement(By.ClassName("modal-body")).Displayed;
            Assert.IsTrue(addUserForm);
            webTable.CompleteUserForm(user);
        });

        var tableData = webTable.GetTableData();
        List<User> userTableData = new List<User>();
        tableData = Regex.Replace(tableData, "Company AAA", "CompanyAAA");
        tableData = Regex.Replace(tableData, "Company BBB", "CompanyBBB");
        var test = Regex.Split(tableData, "Edit");
        test.ToList().ForEach(user =>
        {
            if (user.Length < 1)
                return;
            User tester = new User();
            user.Trim();
            var data = Regex.Split(user, @"\s+");
            List<string> list = new List<string>();
            var listing = data.ToList();
            if (listing.Count >= 8)
            {
                listing.RemoveAt(0);
            }
            if (listing.Count < 8)
            {
                listing.Insert(3, "");
            }

            for (int i = 0; i < listing.Count; i++)
            {
                list.Add(listing[i]);
            }

            if (list.Count > 0)
            {

                tester.FirstName = list[0];
                tester.Lastname = list[1];
                tester.Username = list[2];
                tester.Customer = list[3];
                tester.Role = list[4];
                tester.Email = list[5];
                tester.Cell = list[6];
                tester.Password = "";
                userTableData.Add(tester);
            }
        });

        int count = 0;

        userTableData.ForEach(user =>
        {
            var y = users.ToList().Where(x => x.FirstName == user.FirstName);
            if (y.FirstOrDefault() != null)
                count++;
        });

        Assert.IsTrue(count == users.Count());

    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

