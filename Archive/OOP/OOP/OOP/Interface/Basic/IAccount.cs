using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Interface.Basic
{

    #region Interface Declaration
    //internal: Accessible only from within this project
    //public: Accessible everywhere
    //private/protected/protected internal gives following error:
    //Error CS1527  Elements defined in a namespace cannot be explicitly declared as private, protected, or protected internal OOP E:\Users\C# Git Repository\OOP\OOP\OOP\Interface\Basic\IAccount.cs	9
    internal interface IAccount
    {

        #region Property
        //No Modifier (private/public/internal/protected) is valid for interface property. It's by default 'public'
        string AccountUserName { get; }
        string AccountPassWord { get; }
        //Following field declaration throws error because interface can only contain properties not fields
        //Error CS0525  Interfaces cannot contain fields    OOP E:\Users\C# Git Repository\OOP\OOP\OOP\Interface\Basic\IAccount.cs	20
        //string name;
        #endregion

        #region Method
        
        //No Modifier (private/public/internal/protected) is valid for interface method. It's by default 'public'
        bool StoreUserName(string userName);
        bool EncryptAndStorePassword(string passWord);

        #endregion
    }
    #endregion

    internal interface IPayrollAccount : IAccount
    {
        //This interface inherits from IAccount that is IPayrollAccount extends IAccount
        //So any class that implements IPayrollAccount have to provide implementation for
        //all methods of IAccount & IPayrollAccount

        void ValidatePayRoll();
    }

    //Note that class PayRoll provides implementation for all methods of IPayrollAccount & IAccount
    class PayRoll : IPayrollAccount
    {
        string IAccount.AccountPassWord { get { throw new NotImplementedException(); } }
        string IAccount.AccountUserName { get { throw new NotImplementedException(); } }

        bool IAccount.EncryptAndStorePassword(string passWord) { throw new NotImplementedException(); }
        bool IAccount.StoreUserName(string userName) { throw new NotImplementedException(); }

        void IPayrollAccount.ValidatePayRoll() { throw new NotImplementedException(); }
    }
}
