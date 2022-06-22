using POM.BaseClass;
using POM.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Test
{
    [TestFixture]

    public class POMTest : BaseTest       
    {
        string validuserID = "standard_user";
        string validPassword = "secret_sauce";
        string firstName = "Divyaraj";
        string lastName = "Dodia";
        string postalCode = "382431";
        string expectedTitle = "Swag Labs";

        [Test]
        [TestCase(TestName ="TC105")]
        [Description(@"Feature:POM with flow
                       Given:User is a valid user
                       When:User enters 'standard_user' as username
                       And:User enters 'secret_sauce' as password
                       And:User clicks on Login button
                       Then:User should be logged in successfully
                       And:User should be redirected to inventory page
                       When:User clicks on product one
                       And:User clicks on product two
                       And:User clicks on cart icon
                       Then:User should be redirected to cart page
                       When:User clicks on checkout button 
                       Then:User should be redirected on checkout one page
                       When:User enters 'Divyaraj' as first name
                       And:User enters 'Dodia' as last name
                       And:User enters '382431' as postal code
                       And:User clicks on enter button
                       Then: User should be redirected to checkout two page
                       When: User clicks finish button
                       Then:User should be redirected to checkout complete page")] 
        public void TestMethod()
        {
            string expectedAfterLoginUrl = "https://www.saucedemo.com/inventory.html";

            string expectedAfterProductUrl = "https://www.saucedemo.com/cart.html";

            string expectedAfterCheckCartUrl = "https://www.saucedemo.com/checkout-step-one.html";

            string expectedAfterDetailesUrl = "https://www.saucedemo.com/checkout-step-two.html";

            string expectedFinishUrl = "https://www.saucedemo.com/checkout-complete.html";

            LoginPage lp = new LoginPage(driver);
            ProductPage pp = new ProductPage(driver);
            CartPage cp = new CartPage(driver);

            lp.userLogin(validuserID, validPassword, out var afterLoginUrl);
            lp.getTitle(out var actualTitle);
            pp.productSelection(out var afterProductUrl);
            cp.checkCart(out var afterCheckCartUrl);
            cp.enterDetails(firstName, lastName, postalCode, out var afterDetailesUrl);
            cp.finish(out var finalUrl);

            Assert.IsNotNull(actualTitle, "Title should not be Null");
            Assert.AreEqual(expectedTitle, actualTitle,"Expected title and actual titles should be same");
            Assert.That(afterLoginUrl,Is.EqualTo(expectedAfterLoginUrl),"Url after login does not match expected url");
            Assert.That(afterProductUrl, Is.EqualTo(expectedAfterProductUrl), "Url after product selection does not match expected url");
            Assert.That(afterCheckCartUrl, Is.EqualTo(expectedAfterCheckCartUrl), "Url after cart check does not match expected url");
            Assert.That(afterDetailesUrl,Is.EqualTo(expectedAfterDetailesUrl),"Url after details does not match expected url");
            Assert.That(finalUrl, Is.EqualTo(expectedFinishUrl), "Url after finish click does not match expected url");

        }
    }
}
