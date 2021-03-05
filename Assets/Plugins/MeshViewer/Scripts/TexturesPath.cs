using System.IO;
using UnityEngine;

namespace Tartaros.MeshViewer
{
	internal class TexturesPath
	{
		#region Fields
		private readonly string _albedoPath = null;
		private readonly string _normalPath = null;
		private readonly string _aoPath = null;
		#endregion Fields

		#region Properties
		public Texture AlbedoTexture
		{
			get
			{
				return FileHelper.LoadTexture(AlbedoPath);
			}
		}

		public Texture NormalTexture => FileHelper.LoadTexture(NormalPath);
		public Texture AOTexture => FileHelper.LoadTexture(AoPath);

		public string AlbedoPath => _albedoPath;
		public string NormalPath => _normalPath;
		public string AoPath => _aoPath;
		#endregion Properties

		#region Ctor
		public TexturesPath(string albedoPath, string normalPath, string aoPath)
		{
			if (string.IsNullOrEmpty(albedoPath)) Debug.LogWarning("Cannot get albedo texture");
			if (string.IsNullOrEmpty(normalPath)) Debug.LogWarning("Cannot get normal texture");
			if (string.IsNullOrEmpty(aoPath)) Debug.LogWarning("Cannot get ao texture");

			_albedoPath = albedoPath;
			_normalPath = normalPath;
			_aoPath = aoPath;
		}
		#endregion Ctor

		#region Methods
		public static TexturesPath CreateFromFolder(string texturesFolder)
		{
			string albedoPath = FileHelper.GetFile(texturesFolder, "Albedo");
			string normalPath = FileHelper.GetFile(texturesFolder, "Normal");
			string aoPath = FileHelper.GetFile(texturesFolder, "AO");

			if (string.IsNullOrEmpty(albedoPath)) Debug.LogWarning("Cannot get albedo texture");
			if (string.IsNullOrEmpty(normalPath)) Debug.LogWarning("Cannot get normal texture");
			if (string.IsNullOrEmpty(aoPath)) Debug.LogWarning("Cannot get ao texture");

			return new TexturesPath(albedoPath, normalPath, aoPath);
		}
		#endregion Methods
	}
}
