using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    int window;

	void Start () {
        window = 1;
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
        if (window == 1)
        {
            if (GUI.Button(new Rect(10, 20, 180, 30), "START"))
            {
                Application.LoadLevel("Level1");
            }
            if (GUI.Button(new Rect(10, 70, 180, 30), "EXIT"))
            {
                Application.Quit();
            }
        }

        GUI.EndGroup();
    }

}
