using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StorageService
{
    [DataContract]
    public class Siba
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Client { get; set; }

        [DataMember]
        public List<SubSystem> SubSystemsList { get; set; }

        [DataMember]
        public DateTime DateNeeded { get; set; }

        public Siba()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Client: {Client}, Sub system list: {SubSystemsList}, Date needed: {DateNeeded}";
        }
    }
}