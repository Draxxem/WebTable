// @ts-check
const { test, expect } = require('@playwright/test');
const WebTablePage = require('../Pages/WebTablePage');
const WebDialogPage = require('../Pages/WebDialogPage');
const testData = require('../test-data/testData.json');

test('Navigate to website and Verify table exists| @UItest', async ({ page }) => {
  const webtablePage = new WebTablePage(page);

  await webtablePage.navigateTo('https://www.way2automation.com/angularjs-protractor/webtables/');

  let tablelocator = page.locator('.smart-table.table.table-striped');
  await tablelocator.waitFor();
  await expect(tablelocator).toBeVisible();
});


test('Add 2 new users and verify that 2 new users have been added| @UItest', async ({ page }) => {

  const webDialogPage = new WebDialogPage(page);

  await webDialogPage.navigateTo('https://www.way2automation.com/angularjs-protractor/webtables/');

  for (let i = 1; i <= 2; i++) {
    await webDialogPage.AddUser();
    await webDialogPage.enterFirstName(`${testData.name}${i}`);
    await webDialogPage.enterLastName(`${testData.lastname}${i}`);
    await webDialogPage.enterUserName(`${testData.username}${i}`);
    await webDialogPage.enterPassword(`${testData.password}${i}`);

    if (i === 1) {
      await webDialogPage.selectCompanyA();
      await webDialogPage.selectCombobox();
      await webDialogPage.selectAdmin();
      await webDialogPage.selectCombobox();
      await webDialogPage.enterEmail(`${testData.adminEmail}`);
      await webDialogPage.enterCellphone(`${testData.mobile1}`);
    }
    else {
      await webDialogPage.selectCompanyB();
      await webDialogPage.selectCombobox();
      await webDialogPage.selectCustomer();
      await webDialogPage.selectCombobox();
      await webDialogPage.enterEmail(`${testData.custEmail}`);
      await webDialogPage.enterCellphone(`${testData.mobile2}`);
    }

    await webDialogPage.clickSave();
  }
  
  const rows = await page.locator('.smart-table.table.table-striped tbody tr');

  let rowCount = await rows.count();

  await expect(rowCount).toBe(9);
});
