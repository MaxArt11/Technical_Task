using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check3 : MonoBehaviour {

	public List<Vector3> comparePoints2;
	public static Check3 Instance;
	LineRenderer lr2;

	void Start () {
		Instance = this;
}
    public void Check()
    {
			lr2 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points2 = new Vector3[Circe.segments + 1];
            comparePoints2 = new List<Vector3>();

			lr2.SetVertexCount (Circe.segments + 1);
			lr2.SetWidth (0.05f, 0.05f);
			lr2.SetColors (Color.blue, Color.blue);
			lr2.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points2 [i] = new Vector3 ((0.006f) * i + Line.Instance.cx, 0f + Line.Instance.cy, 0f);

				comparePoints2.Add (points2 [i]);

				lr2.SetPosition (i, points2 [i]);
			}
		}
}
