namespace Tartaros.Editor
{
	using Sirenix.Utilities.Editor;
	using System.Linq;
	using UnityEditor;
	using UnityEngine;

	public class OptimizationWindow : EditorWindow
	{
		private Material[] _materials = null;

		private Vector2 _scrollPosition = default;
		private int _fixedMaterials = 0;

		[MenuItem("Tartaros/Open optimization window", priority = 500)]
		public static void ShowWindow()
		{
			var w = GetWindow<OptimizationWindow>();
			w.titleContent = new GUIContent("Optimization Window");
		}

		private void OnGUI()
		{
			SirenixEditorGUI.Title("GPU Instancing", "", TextAlignment.Left, true);

			GUILayout.Label("{0} materials fixed.".Format(_fixedMaterials));

			if (_materials == null || _materials.Length == 0)
			{
				if (_materials != null && _materials.Length == 0)
				{
					GUILayout.Label("No materials to optimize found.");
				}

				if (GUILayout.Button("Search materials in Arts folder"))
				{
					_materials = FindMaterialsWithDisableInstancing();
				}
			}
			else
			{
				DrawMaterials();

				if (GUILayout.Button("Enable GPU instancing on materials"))
				{
					foreach (Material material in _materials)
					{
						material.enableInstancing = true;
					}

					_fixedMaterials = _materials.Length;
					_materials = null;
				}

			}
		}

		private void DrawMaterials()
		{
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Height(100));
			{
				foreach (Material material in _materials)
				{
					if (material != null)
					{
						GUILayout.BeginHorizontal();
						{
							GUILayout.Space(50);
							GUILayout.Label(material.name);
							EditorUtility.SetDirty(material);
						}
						GUILayout.EndHorizontal();
					}
				}
			}
			GUILayout.EndScrollView();
		}

		private Material[] FindMaterialsWithDisableInstancing()
		{
			Material[] materials = AssetDatabase.FindAssets("t:material", new string[] { "Assets/Arts" })
				.Select(guid => AssetDatabase.GUIDToAssetPath(guid))
				.Select(path => AssetDatabase.LoadAssetAtPath<Material>(path))
				.ToArray();

			return materials
				.Where(x => x.enableInstancing == false)
				.ToArray();
		}
	}
}