using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Square : MonoBehaviour {

    public int pointsCount = 800;
    LineRenderer line;
    public List<Vector3> ModelPointList;
    public static Square Instance;

	void Start () {
        Score.Instance.score++;
        Instance = this;
	}

    public void Draw()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(pointsCount);
        line.useWorldSpace = true;
        line.SetWidth(0.05f, 0.05f);
        line.SetColors(Color.blue, Color.blue);
        CreatePoints();
    }

    public void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;
        Vector3[] squareTop = new Vector3[pointsCount/4];
        Vector3[] squareBottom = new Vector3[pointsCount/4];
        Vector3[] squareLeft = new Vector3[pointsCount/4];
        Vector3[] squareRight = new Vector3[pointsCount/4];

        ModelPointList = new List<Vector3>();

        float scale = Line.Instance.ex;

        for (int i = 0; i < (pointsCount / 4); i++)
        {
            x = Line.Instance.cx + scale;
            y = Line.Instance.cy + ((scale * 8) / pointsCount ) * i - scale;

            squareRight[i] = new Vector3(x, y, z);

            ModelPointList.Add(squareRight[i]);

            line.SetPosition(i, squareRight[i]);
        }

        for (int i = 0; i < (pointsCount / 4); i++)
        {
            x = Line.Instance.cx - ((scale * 8) / pointsCount) * i + scale;
            y = Line.Instance.cy + scale;

            squareTop[i] = new Vector3(x, y, z);

            ModelPointList.Add(squareTop[i]);

            line.SetPosition(i + (pointsCount / 4), squareTop[i]);
        }

        for (int i = 0; i < (pointsCount / 4); i++)
        {
            x = Line.Instance.cx - scale;
            y = Line.Instance.cy + scale - ((scale * 8) / pointsCount) * i;

            squareLeft[i] = new Vector3(x, y, z);

            ModelPointList.Add(squareLeft[i]);

            line.SetPosition(i + pointsCount/2, squareLeft[i]);
        }

        for (int i = 0; i < (pointsCount / 4); i++)
        {
            x = Line.Instance.cx - scale + ((scale * 8) / pointsCount) * i;
            y = Line.Instance.cy - scale;

            squareBottom[i] = new Vector3(x, y, z);

            ModelPointList.Add(squareBottom[i]);

            line.SetPosition(i + pointsCount*3/4, squareBottom[i]);
        }
    }
}
