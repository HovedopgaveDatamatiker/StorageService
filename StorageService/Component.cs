using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StorageService
{
    [DataContract]
    public class Component
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Specification { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public int EstDelivery { get; set; }

        [DataMember]
        public int Available { get; set; }


        public Component()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Specification: {Specification}, Price: {Price}, Link: {Link}, Note: {Note}, Estimated Delivery: {EstDelivery}, Quantity: {Quantity}, Available: {Available}";
        }
    }
}