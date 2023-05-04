using System;
namespace hackatonBackend.ProjectServices.Services.Blob
{
	public class BlobImageDto
	{
		public BlobImageDto(BinaryData content, string contentType)
		{
			Content = content;
			ContentType = contentType;
		}

		public BinaryData Content { get; set; }
		public string ContentType { get; set; }
	}
}

