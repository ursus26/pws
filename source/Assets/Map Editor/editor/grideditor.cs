using UnityEngine;
using UnityEditor;

using System.Collections;
using System.IO;

[CustomEditor(typeof(grid))]
public class GridEditor : Editor {
	
	grid grid;

	private int oldindex = 0;

	void OnEnable(){
		oldindex = 0;
		grid = (grid)target;
	}

	[MenuItem("Assets/Create/Tileset")]
	static void CreateTileSet(){
		var asset = ScriptableObject.CreateInstance<tileset> ();
		var path = AssetDatabase.GetAssetPath(Selection.activeObject);

		if (string.IsNullOrEmpty (path)) {
			path = "Assets";
		} else if (Path.GetExtension(path) != "") {
			path = path.Replace (Path.GetFileName (path), "");
		} else {
			path+="/";
		}

		var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "TileSet.asset");
		AssetDatabase.CreateAsset(asset,assetPathAndName);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
		asset.hideFlags = HideFlags.DontSave;
	}
	
	public override void OnInspectorGUI(){
		//base.OnInspectorGUI ();
		grid.width = createSlider ("Width", grid.width);
		grid.height = createSlider ("Height", grid.height);
		
		if(GUILayout.Button("Open Grid Window")){
			GridWindow window = (GridWindow)EditorWindow.GetWindow(typeof(GridWindow));
			window.init();
		}
		
		// Tile Prefab
		EditorGUI.BeginChangeCheck();
		var newTilePrefab = (Transform)EditorGUILayout.ObjectField("Tile Prefab",grid.tilePrefab,typeof(Transform), false);
		if(EditorGUI.EndChangeCheck()){
			grid.tilePrefab = newTilePrefab;
			Undo.RecordObject(target,"Grid Changed");
		}

		//Tile Map
		EditorGUI.BeginChangeCheck ();
		var newTileSet = (tileset)EditorGUILayout.ObjectField("Tileset", grid.tileset,typeof(tileset),false);
		if(EditorGUI.EndChangeCheck()){
			grid.tileset = newTileSet;
			Undo.RecordObject(target,"Target Changed");
		}

		if (grid.tileset != null) {
			EditorGUI.BeginChangeCheck();
			var names = new string[grid.tileset.prefabs.Length];
			var values = new int[names.Length];

			for(int i = 0; i < names.Length;i++){
				names[i] = grid.tileset.prefabs[i] != null ? grid.tileset.prefabs[i].name : "";
				values[i] = i;
			}

			var index = EditorGUILayout.IntPopup("Select Tile",oldindex,names,values);

			if(EditorGUI.EndChangeCheck()){
				Undo.RecordObject(target,"Grid Changed");
				if(oldindex != index){
					oldindex = index;
					grid.tilePrefab = grid.tileset.prefabs[index];

					float width = grid.tilePrefab.renderer.bounds.size.x;
					float height = grid.tilePrefab.renderer.bounds.size.y;

					grid.width = width;
					grid.height = height;
				}
			}
		}
	}
	
	private float createSlider(string labelName, float sliderPosition){
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Grid " + labelName);
		sliderPosition = EditorGUILayout.Slider (sliderPosition, 1f, 100f, null);
		GUILayout.EndHorizontal();
		
		return sliderPosition;
	}

	void OnSceneGUI(){
		int controlId = GUIUtility.GetControlID (FocusType.Passive);
		Event e = Event.current;
		Ray ray = Camera.current.ScreenPointToRay (new Vector3 (e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
		Vector3 mousePos = ray.origin;

		if (e.isMouse && e.type == EventType.MouseDown) {
			GUIUtility.hotControl = controlId;
			e.Use ();

			GameObject gameObject;
			Transform prefab = grid.tilePrefab;

			if(prefab){
				Undo.IncrementCurrentGroup();
				gameObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab.gameObject);
				Vector3 aligned = new Vector3(Mathf.Floor (mousePos.x/grid.width)*grid.width+grid.width/2.0f, Mathf.Floor (mousePos.y/grid.height)*grid.height+grid.height/2.0f,0.0f);
				gameObject.transform.position = aligned;
				gameObject.transform.parent = grid.transform;
				Undo.RegisterCreatedObjectUndo(gameObject,"Create" + gameObject.name);
			}
		}

		if (e.isMouse && e.type == EventType.MouseUp) {
			GUIUtility.hotControl = 0;	
		}
	}
}