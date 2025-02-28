class WebDialogPage {
  constructor(page) {
    this.page = page;
    this.addUserButton = page.getByRole('button', { name: 'Add User' });
    this.firstnameInput = page.locator('input[name="FirstName"]');
    this.lastnameInput = page.locator('input[name="LastName"]');
    this.usernameInput = page.locator('input[name="UserName"]');
    this.passwordInput = page.locator('input[name="Password"]');
    this.radioButtonA = page.getByRole('radio', { name: 'Company AAA' });
    this.radioButtonB = page.getByRole('radio', { name: 'Company BBB' });
    this.roleCombobox = page.getByRole('combobox');
    this.selectSalesRole = page.selectOption('select[name="RoleId"]', { value: '0' });
    this.selectCustomerRole = page.selectOption('select[name="RoleId"]', { value: '1' });
    this.selectAdminRole = page.selectOption('select[name="RoleId"]', { value: '2' });
    this.emailInput = page.locator('input[name="Email"]');
    this.cellphoneInput = page.locator('input[name="Mobilephone"]');
    this.saveButton = page.getByRole('button', { name: 'Save' });

  }

  async navigateTo(url) {
    await this.page.goto(url);
  }

  async findTable()
  {
    await this.table;
  }
  async enterFirstName(firstName) {
    await this.firstnameInput.fill(firstName);
  }

  async enterLastName(lastName) {
    await this.lastnameInput.fill(lastName);
  }

  async enterUserName(userName) {
    await this.usernameInput.fill(userName);
  }

  async enterPassword(password) {
    await this.passwordInput.fill(password);
  }

  async selectCompanyA() {
    await this.radioButtonA.check();
  }

  async selectCompanyB() {
    await this.radioButtonB.check();
  }

  async selectCombobox() {
    await this.roleCombobox.click();
  }

  async enterEmail(email) {
    await this.emailInput.fill(email);
  }

  async enterCellphone(cellNo) {
    await this.cellphoneInput.fill(cellNo);
  }

  async enterEmail(email) {
    await this.emailInput.fill(email);
  }

  async selectCustomer() {
    await this.selectCustomerRole;
  }

  async selectAdmin() {
    await this.selectAdminRole;
  }

  async selectSales() {
    await this.selectSalesRole;
  }

  async clickSave() {
    await this.saveButton.click();
  }

  async AddUser() {
    await this.addUserButton.click();
  }

}

module.exports = WebDialogPage;