using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.ProjectServices.Services.Blob
{
	public class BlobService : IBlobService
	{
		private readonly BlobServiceClient blobServiceClient;

		public BlobService(BlobServiceClient blobServiceClient)
		{
			this.blobServiceClient = blobServiceClient;
		}

		public ActionResult<FileModel> GetBlob(string name)
		{
			var containerClient = blobServiceClient.GetBlobContainerClient("hackaton-images");
			var blobClient = containerClient.GetBlobClient(name);

			var blobDownloadInfo = blobClient.DownloadContent();

            return null;
			//return new FileModel(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.Details.ContentType);
		}

        public ActionResult<bool> DeleteBlob(string name, string containerName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(name);

            blobClient.DeleteIfExists();

            return true;
        }

        public ActionResult<bool> UploadBlob(string name, IFormFile file)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("hackaton-images");

            // checking if the file exist 
            // if the file exist it will be replaced
            // if it doesn't exist it   will create a temp space until its uploaded
            var blobClient = containerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            blobClient.Upload(file.OpenReadStream(), httpHeaders);

            return true;
        }
    }
}

