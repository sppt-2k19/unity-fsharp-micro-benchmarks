using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
using UnityEditor;
using UnityEngine.Playables;
using Debug = UnityEngine.Debug;

public class FSharpImporter : AssetPostprocessor
{

	private static string projectLocation = "FSharp/FSharp.sln";
	private static string dllLocation = "FSharp/bin/Debug/UFSharp.dll";
	private static string dllTarget = "Assets/Libs/UFSharp.dll";
	private static string buildTool = "msbuild";


	private const string MenuItemRecompile = "FSharp/Recompile F#";
	private const string MenuItemAutoToggle = "FSharp/Enable Autocompile";
	private static bool autoRecompileEnabled;

	static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		if (!autoRecompileEnabled)
		{
			Debug.Log("Not recompiling on import");
			return; 
		}
		
		foreach (string str in importedAssets)
		{
			Debug.Log("Reimported Asset:  " + str);
			if (str.EndsWith(".fs"))
			{
				SystemCall();
			}
		}
		foreach (string str in deletedAssets)
		{
			Debug.Log("Deleted Asset: " + str);
		}

		for (int i = 0; i < movedAssets.Length; i++)
		{
			Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
		}
	}

	
    [MenuItem(MenuItemRecompile)]
	static void SystemCall()
	{
		UnityEngine.Debug.Log ("Beginning F# compilation");
		try
		{

			var dir = Directory.GetCurrentDirectory();
			Debug.Log(Path.Combine(dir, projectLocation));
			var p = Process.Start("msbuild", Path.Combine(dir, projectLocation));
			p?.WaitForExit();
			var target = Path.Combine(dir, dllTarget);
			FileUtil.DeleteFileOrDirectory(target);
			FileUtil.CopyFileOrDirectory(Path.Combine(dir, dllLocation), target);
			Debug.Log("Done compiling F#");

		} catch (System.Exception e) {
			UnityEngine.Debug.LogError(e);
		}
		finally
		{
			UnityEngine.Debug.Log("Finished compiling F#");
		}
	}

	[MenuItem(MenuItemAutoToggle)]
	private static void ToggleAction()
	{
		ChangeAutoCompile(!autoRecompileEnabled);
	}

	private static void ChangeAutoCompile(bool enabled)
	{
		Menu.SetChecked(MenuItemAutoToggle, enabled);
		EditorPrefs.SetBool(MenuItemAutoToggle, enabled);
		autoRecompileEnabled = enabled;
		
	}
}
