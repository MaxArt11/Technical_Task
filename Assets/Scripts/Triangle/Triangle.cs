using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Triangle : MonoBehaviour {

    public int pointCount = 900;
    LineRenderer line;
    public List<Vector3> ModelPointList;
    public static Triangle Instance;

	void Start () {
        Instance = this;
        Score.Instance.score++;
	}

    public void Draw()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(pointCount);
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

        Vector3[] triangleLeft = new Vector3[pointCount/3];
        Vector3[] triangleRight = new Vector3[pointCount / 3];
        Vector3[] triangleBottom = new Vector3[pointCount / 3];

        ModelPointList = new List<Vector3>();

        float scale = Line.Instance.extents_x;
        float line_x = Line.Instance.center_x;
        float line_y = Line.Instance.center_y;

        for (int i = 0; i < (pointCount / 3); i++)
        {
            x = line_x - scale + (scale*6*i)/pointCount;
            y = line_y - scale;

            triangleBottom[i] = new Vector3(x, y, z);

            ModelPointList.Add(triangleBottom[i]);

            line.SetPosition(i, triangleBottom[i]);
        }

        for (int i = 0; i < (pointCount / 3); i++)
        {
            x = line_x + scale - (scale * 3*i) / pointCount;
            y = line_y - scale + (scale * 6 * i) / pointCount;

            triangleRight[i] = new Vector3(x, y, z);

            ModelPointList.Add(triangleRight[i]);

            line.SetPosition(i + pointCount / 3, triangleRight[i]);
        }

        for (int i = 0; i < (pointCount / 3); i++)
        {
            x = line_x - (scale * 3 * i) / pointCount;
            y = line_y + scale - (scale * 6 * i) / pointCount;

            triangleLeft[i] = new Vector3(x, y, z);

            ModelPointList.Add(triangleLeft[i]);

            line.SetPosition(i + pointCount * 2 / 3, triangleLeft[i]);
        }
    }
}
