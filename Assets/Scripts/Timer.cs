using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour {

    public int secondsTimer;
    private DateTime timer = new DateTime();
    private int secondsLeft;
    private bool run = true;
    bool check = false;
    public static Timer Instance;

    void Start()
    {
        Instance = this;
    }

	void Update () {
        timer = timer.AddSeconds(Time.deltaTime);

        if (run)
        {
            secondsLeft = secondsTimer - timer.Second;
            if (secondsLeft == 0)
            {
                run = false;
                check = true;
            }
        }
	}

    void OnGUI()
    {
        GUILayout.Label("Seconds left " + secondsLeft);

        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));

        if (check)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Your score is " + Score.Instance.score);

            if (GUI.Button(new Rect(10, 40, 180, 30), "TRY AGAIN"))
            {
                Application.LoadLevel("Level1");
            }
        }
        GUI.EndGroup();
    }

}
