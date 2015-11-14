using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using DatumApps;
class TreeCreationWindow : EditorWindow
{
	[MenuItem ("Window/Low Poly Tree Creation")]
	public static void  ShowWindow ()
	{
		EditorWindow.GetWindow (typeof(TreeCreationWindow));

	}

	string treeName = "Tree";
	bool showAdvancedOptions = false;
	bool shiftOnPlace = true;
	bool embedMeshColors = false;

	TreeMaker maker = new TreeMaker();

	void OnGUI ()
	{
	

		treeName = EditorGUILayout.TextField ("Name", treeName);
		maker.origin = EditorGUILayout.Vector3Field ("Origin", maker.origin);
		shiftOnPlace = EditorGUILayout.Toggle("Randomize Origin",shiftOnPlace);
		maker.branchColor = EditorGUILayout.ColorField("Leaf Color",maker.branchColor);
		maker.trunkColor = EditorGUILayout.ColorField("Trunk Color",maker.trunkColor);
		maker.totalHeight = EditorGUILayout.FloatField("Tree Height",maker.totalHeight);

		EditorGUILayout.LabelField("Tree Type");
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button ("Poplar")) {
			maker.setDefaults(TreeMaker.TreePreset.Poplar);
		}
		else if (GUILayout.Button ("Pine")) {
			maker.setDefaults(TreeMaker.TreePreset.Pine);
		}
		else if (GUILayout.Button ("Oak")) {
			maker.setDefaults(TreeMaker.TreePreset.Oak);
		}
		EditorGUILayout.EndHorizontal();
		showAdvancedOptions = EditorGUILayout.BeginToggleGroup ("Advanced Settings", showAdvancedOptions);
		if(showAdvancedOptions){
			embedMeshColors = EditorGUILayout.Toggle("Use Mesh Colors",embedMeshColors);
			maker.topRadius = EditorGUILayout.FloatField("Top Radius",maker.topRadius);
			maker.bottomRadius = EditorGUILayout.FloatField("Bottom Radius",maker.bottomRadius);
			maker.treeHeight = EditorGUILayout.FloatField("Branch Height",maker.treeHeight);
			maker.trunkHeight = EditorGUILayout.FloatField("Trunk Height",maker.trunkHeight);
			maker.pointCount = EditorGUILayout.IntField("Number of Points",maker.pointCount);
			maker.trunkPointCount = EditorGUILayout.IntField("Number of Points on Trunk",maker.trunkPointCount);

			maker.pointyTop = EditorGUILayout.Toggle("Pointy Top",maker.pointyTop);
			maker.vertexNoise = EditorGUILayout.Toggle("Apply Noise",maker.vertexNoise);
		}
		EditorGUILayout.EndToggleGroup ();

		if (GUILayout.Button ("Grow Tree")) {
			MakeTree ();
		}
	}



	private void MakeTree ()
	{
		maker.MakeTree(treeName,shiftOnPlace,embedMeshColors);
	}



}