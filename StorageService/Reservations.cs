using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StorageService
{
    public class Reservations
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public DateTime ScheduledDate { get; set; }

        public bool IsInProduction { get; set; }

        public bool IsDone { get; set; }

        public Reservations()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Product: {Product}, Scheduled Date Needed: {ScheduledDate}, In Production: {IsInProduction}, Done: {IsDone}";
        }

    }
}