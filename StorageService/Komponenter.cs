using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StorageService
{
    [DataContract]
    public class Komponenter
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titel { get; set; }

        [DataMember]
        public string Specification { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Bulk { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public double EstDelivery { get; set; }


        public Komponenter()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Titel: {Titel}, Specification: {Specification}, Price: {Price}, Bulk: {Bulk}, Link: {Link}, Note: {Note}, Estimated Delivery: {EstDelivery}";
        }
    }
}