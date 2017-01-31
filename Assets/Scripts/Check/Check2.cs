using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check2 : MonoBehaviour {

	public List<Vector3> comparePoints1;
	public static Check2 Instance;
	LineRenderer lr1;

	void Start () {
		Instance = this;
	}
    public void Check()
    {
        lr1 = gameObject.GetComponent<LineRenderer>();

			lr1.SetVertexCount (Circe.segments + 1);
			lr1.SetWidth (0.05f, 0.05f);
			lr1.SetColors (Color.blue, Color.blue);
			lr1.useWorldSpace = true;

            CreatePoints();
		
	}

    public void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        Vector3[] points1 = new Vector3[Circe.segments + 1];
        comparePoints1 = new List<Vector3>();

        for (int i = 0; i < Circe.segments + 1; i++)
        {

            x = (0.006f) * i + Line.Instance.center_x;
            y = (0.006f) * i + Line.Instance.center_y;

            points1[i] = new Vector3(x, y, z);

            comparePoints1.Add(points1[i]);

            lr1.SetPosition(i, points1[i]);
        }
    }
}
