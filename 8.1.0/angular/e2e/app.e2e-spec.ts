import { WebAPIBoilerPlateTemplatePage } from './app.po';

describe('WebAPIBoilerPlate App', function() {
  let page: WebAPIBoilerPlateTemplatePage;

  beforeEach(() => {
    page = new WebAPIBoilerPlateTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
