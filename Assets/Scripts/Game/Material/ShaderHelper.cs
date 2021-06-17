namespace Tartaros
{
	using System.Collections;
	using UnityEngine;

	public static class ShaderHelper
	{

		public enum BlendMode
		{
			Opaque,
			Cutout,
			Fade,
			Transparent
		}

		public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
		{
			switch (blendMode)
			{
				case BlendMode.Opaque:
					standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
					standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
					standardShaderMaterial.SetInt("_ZWrite", 1);
					standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
					standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
					standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					standardShaderMaterial.renderQueue = -1;
					break;
				case BlendMode.Cutout:
					standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
					standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
					standardShaderMaterial.SetInt("_ZWrite", 1);
					standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
					standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
					standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					standardShaderMaterial.renderQueue = 2450;
					break;
				case BlendMode.Fade:
					standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
					standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
					standardShaderMaterial.SetInt("_ZWrite", 0);
					standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
					standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
					standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					standardShaderMaterial.renderQueue = 3000;
					break;
				case BlendMode.Transparent:
					standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
					standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
					standardShaderMaterial.SetInt("_ZWrite", 0);
					standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
					standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
					standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
					standardShaderMaterial.renderQueue = 3000;
					break;
			}
		}

		public static void ChangeMeshColorMaterials(MeshRenderer[] meshRenderers, Color color)
		{
			if (meshRenderers.Length >= 1)
			{
				color = new Color(color.r, color.g, color.b, 0.5f);

				foreach (var meshRenderer in meshRenderers)
				{
					if (meshRenderer != null)
					{
						if (meshRenderer.material.color != color)
						{
							meshRenderer.material.color = color;
							//ShaderHelper.ChangeRenderMode(meshRenderer.material, ShaderHelper.BlendMode.Transparent);
						}
					}
				}
			}
		}

		public static void ChangeSkinnedMeshColorMaterials(SkinnedMeshRenderer[] meshRenderers, Color color)
		{
			if (meshRenderers.Length >= 1)
			{

				color = new Color(color.r, color.g, color.b, 0.5f);

				if (meshRenderers[0].material.color != color)
				{
					foreach (var meshRenderer in meshRenderers)
					{
						meshRenderer.material.color = color;
						//ShaderHelper.ChangeRenderMode(meshRenderer.material, ShaderHelper.BlendMode.Transparent);
					}
				}
			}
		}
	}
}