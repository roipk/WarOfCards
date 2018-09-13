using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
#pragma warning disable CS0618 // Type or member is obsolete

	void OnGUI()
	{
		GUI.Box(new Rect(10 , Screen.height - 100 ,100 ,90), "Change Scene");
		if(GUI.Button( new Rect(20 , Screen.height - 70 ,80, 20), "Next"))
			LoadNextScene();
		if(GUI.Button(new Rect(20 ,  Screen.height - 40 ,80, 20), "Back"))
			LoadPreScene();
	}

	void LoadPreScene()
	{
        int nextLevel = Application.loadedLevel + 1;
        if ( nextLevel <= 1)
			nextLevel = Application.levelCount;

		Application.LoadLevel(nextLevel);
	}

	void LoadNextScene()
	{
		int nextLevel = Application.loadedLevel + 1;
		if( nextLevel >= Application.levelCount)
			nextLevel = 1;

		Application.LoadLevel(nextLevel);

	}
#pragma warning restore CS0618 // Type or member is obsolete
}
