using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPCAT
{
    [ServiceContract]
    public interface ICatService
    {

        [OperationContract]
        Cat GetCat(Cat c);

        [OperationContract]
        List<Cat> GetAllCats();

        [OperationContract]
        List<Cat> GetCatByName(string name);

        [OperationContract]
        bool UpdateCat(int index, Cat c);

        [OperationContract]
        bool DeleteCat(Cat c);

        [OperationContract]
        bool AddCat(Cat c);
    }
}
