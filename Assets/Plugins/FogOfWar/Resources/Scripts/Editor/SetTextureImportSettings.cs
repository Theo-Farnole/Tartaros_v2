using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetTextureImportSettings : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        Debug.Log("Importing Resistence map!");
#if UNITY_5_5_OR_NEWER

        if (assetPath.Contains("_ResistenceMap"))
        {
            TextureImporter Importer = (TextureImporter)assetImporter;
            Importer.textureType = TextureImporterType.Default;
            Importer.crunchedCompression = false;
            Importer.isReadable = true;
            Importer.mipmapEnabled = false;
            Importer.textureCompression = TextureImporterCompression.Uncompressed;
            Importer.compressionQuality = 0;
        }
#else
        if(assetPath.Contains("_ResistenceMap"))
        {
            TextureImporter Importer = (TextureImporter)assetImporter;
            Importer.textureType = TextureImporterType.Advanced;
            Importer.isReadable = true;
            Importer.mipmapEnabled = false;
            //Importer.compressionQuality = 0;
            Importer.textureFormat = TextureImporterFormat.RGBA32;
        }

#endif
    }
}