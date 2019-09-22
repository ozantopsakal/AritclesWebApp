using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class MockUserTypes : IUserTypes
    {
        private List<UserTypes> _userTypeList;

        public MockUserTypes()
        {
            _userTypeList = new List<UserTypes>();
        }

        public List<UserTypes> GetAllUserTypes()
        {
            return _userTypeList;
        }
    }
}
