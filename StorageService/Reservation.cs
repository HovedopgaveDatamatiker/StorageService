using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StorageService
{
    [DataContract]
    public class Reservation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Product { get; set; }
        //[DataMember]
        //public  ScheduledDate { get; set; }
        [DataMember]
        public bool IsInProduction { get; set; }
        [DataMember]
        public bool IsDone { get; set; }
        
        public Reservation()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Product: {Product}, IsDone: {IsDone}, IsInProduction: {IsInProduction}";
        }

    }
}