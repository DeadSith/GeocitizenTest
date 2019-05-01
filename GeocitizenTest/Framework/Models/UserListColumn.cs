using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Models
{
    public class UserListColumn
    {
        public static UserListColumn Login
        {
            get
            {
                var columnName = "Login";
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn Email
        {
            get
            {
                var columnName = "Email";
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn FirstName
        {
            get
            {
                var columnName = "First name";
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn LastName
        {
            get
            {
                var columnName = "Last name";
                return new UserListColumn(columnName);
            }
        }

        public static UserListColumn Type
        {
            get
            {
                var columnName = "Type";
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
