using UnityEngine;
using UnityEditor;
using System.Collections;

public class GridWindow : EditorWindow {
	grid grid;
	
	public void init(){
		grid = (grid)FindObjectOfType (typeof(grid));
	}
	
	void OnGUI(){
		grid.color = EditorGUILayout.ColorField(grid.color,GUILayout.Width(200));
	}		
}