using NUnit.Framework;
using System.IO;
using System;
using RestSharp;

namespace Babich_WebApi
{
    public class Tests
    {
        
        [Test]
        public void UploadFile()
        {
            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Bitmap1.bmp");
            
            string token = "CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH";
            RestClient uploadClient = new RestClient("https://content.dropboxapi.com/2/files/upload");

            byte[] picture = File.ReadAllBytes(startupPath);

            RestRequest uploadRequest = new RestRequest(Method.POST);
            uploadRequest.RequestFormat = DataFormat.Json;

            uploadRequest.AddHeader("Authorization", "Bearer " + token);
            uploadRequest.AddHeader("Dropbox-API-Arg", "{\"path\":\"/test/my_image.jpg\"}");
            uploadRequest.AddParameter("application/octet-stream", picture, "application/octet-stream", ParameterType.RequestBody);
            uploadRequest.AddHeader("Content-Type", "application/octet-stream");

            var response = uploadClient.Execute(uploadRequest);

            Assert.IsTrue(response.Content != null);
        }
        
        [Test]

        public void GetFileMetadata()
        {
            string token = "CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH";
            RestClient getClient = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");

            RestRequest getRequest = new RestRequest(Method.POST);
            getRequest.RequestFormat = DataFormat.Json;

            getRequest.AddHeader("Authorization", "Bearer " + token);
            getRequest.AddHeader("Content-Type", "application/json");
            getRequest.AddJsonBody("{\"path\":\"/test/my_image.jpg\"}");

            var response = getClient.Execute(getRequest);
            Assert.IsTrue(response.Content != null);
        }

        [Test]

        public void DeleteFile()
        {
            string token = "CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH";
            RestClient deleteClient = new RestClient("https://api.dropboxapi.com/2/files/delete_v2\n");

            RestRequest deleteRequest = new RestRequest(Method.POST);
            deleteRequest.RequestFormat = DataFormat.Json;

            deleteRequest.AddHeader("Authorization", "Bearer " + token);
            deleteRequest.AddHeader("Content-Type", "application/json");
            deleteRequest.AddJsonBody("{\"path\":\"/test/my_image.jpg\"}");

            var response = deleteClient.Execute(deleteRequest);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.Content != null);
        }
    }
}