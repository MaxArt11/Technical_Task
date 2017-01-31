using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score;
    public static Score Instance;

	void Start () {
        Instance = this;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(670, 10, 100, 100), "Score: " + score);
    }
}
