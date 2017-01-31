using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class wedge : MonoBehaviour
{

    public int pointCount = 600;
    LineRenderer line;
    public List<Vector3> ModelPointList;
    public static wedge Instance;

    void Start()
    {
        Instance = this;
        if (triangleCompare.Instance.winner)
        {
            Timer.Instance.secondsTimer = 2;
        }
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

        Vector3[] triangleLeft = new Vector3[pointCount / 2];
        Vector3[] triangleRight = new Vector3[pointCount / 2];

        ModelPointList = new List<Vector3>();

        float scale = (Line.Instance.extents_x + Line.Instance.extents_y)/2;
        float line_x = Line.Instance.center_x;
        float line_y = Line.Instance.center_y;


        for (int i = 0; i < (pointCount / 2); i++)
        {
            x = line_x + scale - (scale * 2 * i) / pointCount;
            y = line_y - scale + (scale * 4 * i) / pointCount;

            triangleRight[i] = new Vector3(x, y, z);

            ModelPointList.Add(triangleRight[i]);

            line.SetPosition(i, triangleRight[i]);
        }

        for (int i = 0; i < (pointCount / 2); i++)
        {
            x = line_x - (scale * 2 * i) / pointCount;
            y = line_y + scale - (scale * 4 * i) / pointCount;

            triangleLeft[i] = new Vector3(x, y, z);

            ModelPointList.Add(triangleLeft[i]);

            line.SetPosition(i + pointCount / 2 , triangleLeft[i]);
        }
    }
}