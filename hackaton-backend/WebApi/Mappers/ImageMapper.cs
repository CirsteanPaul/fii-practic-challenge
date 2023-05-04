using System;
namespace hackatonBackend.WebApi.Mappers
{
	public static class ImageMapper
	{
		private readonly static string prefixUri = "https://hackatonpracticstorage.blob.core.windows.net/hackaton-images/";

		public static string AddPrefixToImage(string image) => string.Concat(prefixUri, image);
	}
}

