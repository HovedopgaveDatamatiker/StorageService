using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StorageService
{
    [DataContract]
    public class SubSystem
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Product { get; set; }

        [DataMember]
        public List<Component> ComponentsList { get; set; }

        [DataMember]
        public DateTime DateNeeded { get; set; }

        public SubSystem()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Product: {Product}, Components list: {ComponentsList}, Date needed: {DateNeeded}";
        }

    }
}