using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Models
{
    public class UserType
    {
        public static UserType All
        {
            get
            {
                var label = Properties.Resources.UserType_All;
                return new UserType(label);
            }
        }

        public static UserType Admin
        {
            get
            {
                var label = Properties.Resources.UserType_Admin;
                return new UserType(label);
            }
        }

        public static UserType Banned
        {
            get
            {
                var label = Properties.Resources.UserType_Banned;
                return new UserType(label);
            }
        }

        public static UserType Master
        {
            get
            {
                var label = Properties.Resources.UserType_Master;
                return new UserType(label);
            }
        }

        public static UserType User
        {
            get
            {
                var label = Properties.Resources.UserType_User;
                return new UserType(label);
            }
        }

        private UserType(string typeLabel)
        {
            Label = typeLabel;
        }

        public string Label { get; }
    }
}
