using System.IO;
using UnityEngine;

namespace Tartaros.MeshViewer
{
	internal class TexturesPath
	{
		#region Fields
		public readonly string albedoPath = null;
		public readonly string normalPath = null;
		public readonly string aoPath = null;
		#endregion Fields

		#region Properties
		public Texture AlbedoTexture => FileHelper.LoadTexture(albedoPath);
		public Texture NormalTexture => FileHelper.LoadTexture(normalPath);
		public Texture AOTexture => FileHelper.LoadTexture(aoPath);
		#endregion Properties

		#region Ctor
		public TexturesPath(string albedoPath, string normalPath, string aoPath)
		{
			this.albedoPath = PathCorrector.CorrectPath(albedoPath);
			this.normalPath = PathCorrector.CorrectPath(normalPath);
			this.aoPath = PathCorrector.CorrectPath(aoPath);
		}
		#endregion Ctor

		#region Methods
		public static TexturesPath CreateFromFolder(string texturesFolder)
		{
			string albedoPath = FileHelper.GetFile(texturesFolder, "Albedo");
			string normalPath = FileHelper.GetFile(texturesFolder, "Normal");
			string aoPath = FileHelper.GetFile(texturesFolder, "AO");

			return new TexturesPath(albedoPath, normalPath, aoPath);
		}
		#endregion Methods
	}
}
