using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Kogane
{
	public static class AllSceneTester
	{
		private static readonly Func<string, bool> DEFAULT_IS_TARGET_SCENE_DELEGATE = _ => true;

		public static void Test
		(
			[NotNull]   Func<Scene, bool>  isValid,
			[CanBeNull] Func<string, bool> isTargetScene = null
		)
		{
			if ( isTargetScene == null )
			{
				isTargetScene = DEFAULT_IS_TARGET_SCENE_DELEGATE;
			}

			var setup = EditorSceneManager.GetSceneManagerSetup();

			var scenePaths = AssetDatabase
					.FindAssets( "t:Scene" )
					.Select( x => AssetDatabase.GUIDToAssetPath( x ) )
					.Where( x => x.StartsWith( "Assets/" ) )
					.Where( x => isTargetScene( x ) )
					.ToArray()
				;

			var invalidScenePathList = new List<string>();

			foreach ( var scenePath in scenePaths )
			{
				var scene = EditorSceneManager.OpenScene( scenePath );
				if ( isValid( scene ) ) continue;
				invalidScenePathList.Add( scene.path );
			}

			EditorSceneManager.RestoreSceneManagerSetup( setup );

			if ( invalidScenePathList.Count <= 0 ) return;

			Assert.Fail( string.Join( "\n", invalidScenePathList ) );
		}
	}
}