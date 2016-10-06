using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPCAT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Cat GetCat(Cat c);

        [OperationContract]
        List<Cat> GetAllCats();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Cat
    {
        private string _uniqeIdentifier;

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string UniqeIdentifier
        {
            get { return _uniqeIdentifier; }
            set { _uniqeIdentifier = value; }
        }
    }
}
