using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountMsg
{
    [Serializable]
    public enum AccountMessageFlag
    {
        LOGIN,
        REGISTER,
        CHANGE
    }
    [Serializable]
    public enum RegisterFlag
    {
        SUCCESS,
        FAILED_EXSIT_USERNAME,
        FAILED_UNKNOWN
    }
    [Serializable]
    public enum UserSex
    {
        MALE,
        FEMALE,
        UNKNOWN
    }
    [Serializable]
    public enum LoginFlag
    {
        SUCCESS,
        INVALID_USERNAME,
        INVALID_PASSWORD
    }
    [Serializable]
    public class AccountMessage
    {
        private string password;
        private string userName;
        private string nickName;
        private UserSex sex;
        private int age;
        private AccountMessageFlag aFlag;
        private RegisterFlag rFlag;
        private LoginFlag lFlag;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
            }
        }
        public UserSex Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public AccountMessageFlag AFlag
        {
            get
            {
                return aFlag;
            }
            set
            {
                aFlag = value;
            }
        }
        public RegisterFlag RFlag
        {
            get
            {
                return rFlag;
            }
            set
            {
                rFlag = value;
            }
        }
        public LoginFlag LFlag
        {
            get
            {
                return lFlag;
            }
            set
            {
                lFlag = value;
            }
        }
    }

}
