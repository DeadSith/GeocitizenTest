using GeocitizenTest.Framework;
using GeocitizenTest.Framework.Helpers;
using GeocitizenTest.Framework.Models;
using NUnit.Framework;
using System.Linq;

namespace GeocitizenTest.Tests
{
    [TestFixture]
    public class T0002_User_List_Sort : BaseTest
    {
        private string SearchCriteria2 { get; set; }

        [SetUp]
        public void SetSearchCriteria() => SearchCriteria2 = "b";

        [Description(@"<pre>
        <b>Preconditions:</b>
            1. Open login page
            2. Log in as admin
            3. Open administration page
        <b>Steps:</b>
            1. Open users list
            2. Click on Type field
            3. Select Admin type
            4. Set search criteria #2
            5. Click on Name header
            6. Clear search criteria, set user type to ""All""
        </pre>")]
        [Test]
        public void T0002UserListSort()
        {
            ReportHelper.Instance.Info("<b>Preconditions:</b>");
            var mainPage = OpenMainPage();

            ReportHelper.Instance.Info("1. Open login page");
            var loginPage = mainPage.OpenLoginPage();

            ReportHelper.Instance.Info("2. Log in as admin");
            loginPage.LogInAsAdmin();

            ReportHelper.Instance.Info("3. Open administration page");
            var adminPage = mainPage.OpenAdministrationPage();

            ReportHelper.Instance.Info("<b>Steps:</b>");
            ReportHelper.Instance.Info("1. Open users list");
            var usersList = adminPage.OpenUsersList();
            Assert.GreaterOrEqual(10, usersList.Rows.Count, "Too many rows are displayed");
            var loginIndex = usersList.GetColumnIndex(UserListColumn.Login);
            Assert.AreEqual(SortOrder.Asc, usersList.GetSortOrder(loginIndex));

            ReportHelper.Instance.Info("2. Click on Type field");
            usersList.OpenUserTypeSelect();
            Assert.IsTrue(usersList.UserTypeOptionsContainer.Displayed, "Type dropdown is not displayed");
            Assert.AreEqual(5, usersList.UserTypes.Count());

            ReportHelper.Instance.Info("3. Select Admin type");
            usersList.SetUserType(UserType.Admin);
            var typeIndex = usersList.GetColumnIndex(UserListColumn.Type);
            var types = usersList.GetColumnValues(typeIndex);
            Assert.AreEqual(UserType.Admin.Label, usersList.CurrentUserType);
            Assert.IsTrue(types.All(t => t == UserType.Admin.Label), "Non-admin users are displayed");

            ReportHelper.Instance.Info("4. Set search criteria #2");
            usersList.SetSearchCriteria(SearchCriteria2);
            var count = usersList.Rows.Count();
            Assert.GreaterOrEqual(10, count);
            Assert.IsTrue(types.All(t => t == UserType.Admin.Label), "Non-admin users are displayed");

            ReportHelper.Instance.Info("5. Click on Name header");
            var nameIndex = usersList.GetColumnIndex(UserListColumn.FirstName);
            usersList.ClickOnColumnHeader(nameIndex);
            Assert.GreaterOrEqual(10, usersList.Rows.Count());
            Assert.AreEqual(SortOrder.Asc, usersList.GetSortOrder(nameIndex));
            Assert.IsTrue(types.All(t => t == UserType.Admin.Label), "Non-admin users are displayed");
            var names = usersList.GetColumnValues(nameIndex);
            var sortedNames = names.OrderBy(n => n);
            CollectionAssert.AreEqual(sortedNames, names);

            ReportHelper.Instance.Info(@"6. Clear search criteria, set user type to ""All""");
            usersList.SetUserType(UserType.All);
            usersList.SetSearchCriteria("");
            Assert.GreaterOrEqual(10, usersList.Rows.Count());
            Assert.AreEqual(SortOrder.Asc, usersList.GetSortOrder(nameIndex));
            names = usersList.GetColumnValues(nameIndex);
            sortedNames = names.OrderBy(n => n);
            CollectionAssert.AreEqual(sortedNames, names);
        }
    }
}
