namespace GeocitizenTest.Framework.Models
{
    public class UserListColumn
    {
        public static UserListColumn Login
        {
            get
            {
                var columnName = Properties.Resources.UserListColumn_Login;
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn Email
        {
            get
            {
                var columnName = Properties.Resources.UserListColumn_Email;
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn FirstName
        {
            get
            {
                var columnName = Properties.Resources.UserListColumn_FirstName;
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn LastName
        {
            get
            {
                var columnName = Properties.Resources.UserListColumn_LastName;
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn Type
        {
            get
            {
                var columnName = Properties.Resources.UserListColumn_Type;
                return new UserListColumn(columnName);
            }
        }

        private UserListColumn(string columnName)
        {
            Name = columnName;
        }

        public string Name { get; }
    }
}
