using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StorageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //HTTP

        //GET all components
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "komponenter")
        ]
        List<Component> GetComponents();

        //POST component
        [OperationContract]
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                UriTemplate = "komponenter")
        ]
        void AddComponent(Component newKomponent);

        //PUT component
        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "komponenter")
        ]
        void UpdateComponent(Component component);

        //DELETE component
        [OperationContract]
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "komponenter?id={id}")
        ]
        void DeleteComponent(int id);


        //GET all reservations
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "reservations")
        ]
        List<Reservation> GetReservations();

        //POST new reservation
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "reservations")
        ]
        void AddReservation(Reservation reservation);

        //PUT resevervation
        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "reservation")
        ]
        void UpdateReservation(Reservation reservation);

        //DELETE reservation
        [OperationContract]
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "reservations?id={id}")
        ]
        void DeleteReservation(int id);

        //GET all in production
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "production")
        ]
        List<Reservation> GetAllInProduction();

        //GET all done
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "done")
        ]
        List<Reservation> GetAllDone();

    }
}
