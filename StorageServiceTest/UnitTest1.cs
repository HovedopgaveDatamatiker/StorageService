using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StorageServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        private static string URL = "http://storageservice2018.azurewebsites.net/Service1.svc/";

        [TestMethod]
        public void TestGetAllComponents()
        {
            ////Arrange
            //var handler = new HttpClientHandler();
            ////Creates a new HttpClientHandler.
            //handler.UseDefaultCredentials = true;
            ////true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.

            ////Act
            //var json = CommonIntegrationTestFunctions.GetFromWebservice(URL, "komponenter");

            //Arrange
            var handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.

            //Act
            string json = null;
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(URL);
                var task = client.GetAsync("komponenter");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = task.Result;
                response.EnsureSuccessStatusCode();
                json = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine("JSON Gotten from webservice: " + json);

            //Assert
            Assert.IsNotNull(json);
        }
    }
}
