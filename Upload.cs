using System;
using NUnit.Framework;
using RestSharp;
using System.IO;

namespace WebApiTests
{
    [TestFixture()]
    public class Upload
    {
        [Test()]
        public void UploadFile()
        {
            string path = @"C:\Users\Kirill\Pictures\Saved Pictures\EUeA_3rWsAIahK-.jpg";
            String token = "CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH";
            RestClient restClient = new RestClient("https://content.dropboxapi.com/2/files/upload");

            byte[] image = File.ReadAllBytes(path);

            RestRequest uploadRequest = new RestRequest(Method.POST);
            uploadRequest.RequestFormat = DataFormat.Json;

            uploadRequest.AddHeader("Authorization", "Bearer " + token);
            uploadRequest.AddHeader("Dropbox-API-Arg", "{\"path\":\"/test/4k_image.jpg\"}");
            uploadRequest.AddParameter("application/octet-stream", image, "application/octet-stream", ParameterType.RequestBody);
            uploadRequest.AddHeader("Content-Type", "application/octet-stream");

            var response = restClient.Execute(uploadRequest);

            Assert.IsTrue(response.Content != null);
        }


    }

}
