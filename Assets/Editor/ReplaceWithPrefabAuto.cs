using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class ReplaceWithPrefabAuto : EditorWindow
{

	[SerializeField]
	string assetPath = "Assets/Prefabs/";



    [MenuItem("Tools/Replace With Prefab Automatic")]
    static void CreateReplaceWithPrefabAuto()
    {
        EditorWindow.GetWindow<ReplaceWithPrefabAuto>();
    }

    private void OnGUI()
    {
        assetPath = (string)EditorGUILayout.TextField("Asset Path", assetPath);

        if (GUILayout.Button("Replace"))
        {
            var selection = Selection.gameObjects;

            for (var i = selection.Length - 1; i >= 0; --i)
            {
                var selected = selection[i];
				var selectedPrefabName = Regex.Replace(selected.name, @"\(Clone\).*", "");
				var prefabPath = assetPath + selectedPrefabName + ".prefab";
				GameObject prefab = (GameObject) AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
				Debug.Log(prefabPath);
                var prefabType = PrefabUtility.GetPrefabType(prefab);
                GameObject newObject;

                if (prefabType == PrefabType.Prefab)
                {
                    newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                }
                else
                {
                    newObject = Instantiate(prefab);
                    newObject.name = prefab.name;
                }

                if (newObject == null)
                {
                    Debug.LogError("Error instantiating prefab");
                    break;
                }

                Undo.RegisterCreatedObjectUndo(newObject, "Auto Replace With Prefabs");
                newObject.transform.parent = selected.transform.parent;
                newObject.transform.localPosition = selected.transform.localPosition;
                newObject.transform.localRotation = selected.transform.localRotation;
                newObject.transform.localScale = selected.transform.localScale;
                newObject.transform.SetSiblingIndex(selected.transform.GetSiblingIndex());
                Undo.DestroyObjectImmediate(selected);
            }
        }

        GUI.enabled = false;
        EditorGUILayout.LabelField("Selection count: " + Selection.objects.Length);
    }
}