using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Interface.Basic
{
    class Account : IAccount
    {
        #region Property & Field

        //NOTE THIS PORTION:
            //Properties should be defined (re-implemented) in the class that implements interface
            //In-case property has no real implementation for that class-that implements the interface-those properties must be at least
            //re-defined (or re-stated). See bellow:
        public string AccountPassWord { get; }
        public string AccountUserName { get; }

        #endregion

        public bool EncryptAndStorePassword(string passWord)
        {
            return true;
        }

        public bool StoreUserName(string userName)
        {
            return false;
        }
    }
}
