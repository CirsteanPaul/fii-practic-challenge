using System;
namespace hackatonBackend.WebApi.Mappers
{
	public static class ImageMapper
	{
		private readonly static string prefixUri = "https://hackatonpracticstorage.blob.core.windows.net/hackaton-images/";

		public static string AddPrefixToImage(string image)
		{
			if (image is null) {
				return null;
			}

			return string.Concat(prefixUri, image);
		}
	}
}

