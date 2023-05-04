using System;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.ProjectServices.Services.Blob
{
	public interface IBlobService
	{
		ActionResult<BlobImageDto> GetBlob(string name);
        ActionResult<bool> DeleteBlob(string name, string containerName);
        ActionResult<bool> UploadBlob(string name, IFormFile file, string containerName);
    }
}

