using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPCAT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CatService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CatService.svc or CatService.svc.cs at the Solution Explorer and start debugging.
    public class CatService : ICatService
    {
        public Cat GetCat(Cat c)
        {
            return DBHelper.GetCat(c);
        }

        public List<Cat> GetAllCats()
        {
            return DBHelper.GetAllCats();
        }

        public bool UpdateCat(int index, Cat c)
        {
            if (DBHelper.UpdateCat(index, c)) return true;
            return false;
        }

        public List<Cat> GetCatByName(string name)
        {
            return DBHelper.GetCatByName(name);
        }

        public bool DeleteCat(Cat c)
        {
            if (DBHelper.DeleteCat(c)) return true;
            return false;
        }

        public bool AddCat(Cat c)
        {
            if (DBHelper.AddCat(c)) return true;
            return false;
        }
    }
}
