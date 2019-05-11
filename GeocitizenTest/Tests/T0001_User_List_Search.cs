using GeocitizenTest.Framework;
using GeocitizenTest.Framework.Helpers;
using GeocitizenTest.Framework.Models;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;

namespace GeocitizenTest.Tests
{
    [TestFixture]
    public class T0001_User_List_Search : BaseTest
    {
        private string LongSearchCriteria { get; set; }

        private string SearchCriteria1 { get; set; }

        private string SearchCriteria2 { get; set; }

        private string RandomString(int size)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (var i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        [SetUp]
        public void SetSearchCriteria()
        {
            LongSearchCriteria = RandomString(70);
            SearchCriteria1 = "Admin_123";
            SearchCriteria2 = "b";
        }

        [Description(@"<pre>
        <b>Preconditions:</b>
            1. Open login page
            2. Log in as admin
            3. Open administration page
        <b>Steps:</b>
            1. Open users list
            2. Click on Type field
            3. Select Admin type
            4. Set search criteria longer than 64 symbols
            5. Set non-existant search criteria
            6. Set search criteria #1
            7. Set search criteria #2
        </pre>")]
        [Test]
        public void T0001UserListSearch()
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

            ReportHelper.Instance.Info("4. Set search criteria longer than 64 symbols");
            usersList.SetSearchCriteria(LongSearchCriteria);
            Assert.AreEqual("Search criteria cannot be longer than 64 characters", usersList.EmptyGridNotification.Text,
                "Wrong message is displayed for long search criteria");

            ReportHelper.Instance.Info("5. Set non-existant search criteria");
            usersList.SetSearchCriteria(DateTime.Now.Ticks.ToString());
            Assert.AreEqual("No users found", usersList.EmptyGridNotification.Text,
                "Wrong message is displayed for non-existant search criteria");

            ReportHelper.Instance.Info("6. Set search criteria #1");
            usersList.SetSearchCriteria(SearchCriteria1);
            Assert.AreEqual(1, usersList.Rows.Count());
            Assert.AreEqual(SearchCriteria1, usersList.GetRowValues(1).ElementAt(loginIndex - 1), "Wrong result is displayed");

            ReportHelper.Instance.Info("7. Set search criteria #2");
            usersList.SetSearchCriteria(SearchCriteria2);
            var count = usersList.Rows.Count();
            Assert.GreaterOrEqual(10, count);
            Assert.IsTrue(types.All(t => t == UserType.Admin.Label), "Non-admin users are displayed");
            for (var i = 1; i <= count; i++)
            {
                var values = usersList.GetRowValues(i);
                Assert.IsTrue(values.Any(v => v.Contains(SearchCriteria2)), "Item without specified criteria is displayed");
            }
        }
    }
}
