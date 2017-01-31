using UnityEngine;
using System.Collections;

public class straight : MonoBehaviour {

    public float del;
    public float dyy;
    public int winner = 0;
    public static straight Instance;

    void Start()
    {
        Instance = this;

        if (triangleCompare.Instance.winner)
        {
            Timer.Instance.secondsTimer = 5;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(345, 30, 100, 100), "Draw this shape:");
    }

	void Update () {

        del = Line.Instance.extents_x;
        dyy = Line.Instance.extents_y;
        Camera.main.transform.position = new Vector3(Line.Instance.center_x, Line.Instance.center_y, -10.0f);

        if (Line.Instance.count == 0)
        {
            if ((dyy <= 0.1f)&&(del>=0.7f)&&(del<=1.5f))
            {
                Application.LoadLevel("Level2");
            }
        }
	}
}
