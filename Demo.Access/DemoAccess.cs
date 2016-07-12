using demo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Model;
using System.Data;

namespace Demo.Access
{
   public class DemoAccess:BaseDataAccess
    {
           #region Constructor
        public DemoAccess(BaseDataAccess baseaccess)
            : base(baseaccess)
        {

        }
        public DemoAccess()
        {

        }
        #endregion

        public User GetLoginDetails()
        {
            DBParameters.Clear();
           
            IDataReader sqlReader = ExecuteReader("AuthenticateUser");
            User accountVM = new User();
            accountVM = PopulateAccountViewModel(sqlReader);
            sqlReader.Close();
            return accountVM;
        }
        private User PopulateAccountViewModel(IDataReader sqlReader)
        {
            User accountVM = new User();
            while (sqlReader.Read())
            {
                accountVM.username = GetFieldValue(sqlReader, "UserName", string.Empty);
                accountVM.password = GetFieldValue(sqlReader, "password", string.Empty);
                accountVM.email = GetFieldValue(sqlReader, "email", string.Empty);
              }

           
            return accountVM;
        }


    }
}
