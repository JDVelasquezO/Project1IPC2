using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserOperative_Logic
    {
        UserOperative_Data operative_Data = new UserOperative_Data();

        public List<UserOperative_Entity> searchOperators(int id)
        {
            return operative_Data.searchOperators(id);
        }

        public List<UserOperative_Entity> returnCredentials()
        {
            return operative_Data.returnCredentials();
        }

        public UserOperative_Entity searchOperativeById(int id)
        {
            return operative_Data.searchOperativeById(id);
        }
    }
}
