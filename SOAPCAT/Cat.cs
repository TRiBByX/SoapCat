using System.Runtime.Serialization;

namespace SOAPCAT
{
    [DataContract]
    public class Cat
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        /// <summary>
        /// like a social security number
        /// </summary>
        [DataMember]
        public int UniqueIdentifier { get; set; }
    }
}