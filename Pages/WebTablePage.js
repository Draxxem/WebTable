class WebTalePage {
  constructor(page) {
    this.page = page;
    this.addUserButton = page.getByRole('button', { name: 'Add User' });
  }

  async navigateTo(url) {
    await this.page.goto(url);
  }

  async AddUser() {
    await this.addUserButton.click();
  }

}

module.exports = WebTalePage;