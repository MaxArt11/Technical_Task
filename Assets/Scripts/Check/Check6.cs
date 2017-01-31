using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check6 : MonoBehaviour {

	public List<Vector3> comparePoints5;
	public static Check6 Instance;
	LineRenderer lr5;

	void Start () {
		Instance = this;
}
    public void Check()
    {
			lr5 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points5 = new Vector3[Circe.segments + 1];
            comparePoints5 = new List<Vector3>();

			lr5.SetVertexCount (Circe.segments + 1);
			lr5.SetWidth (0.05f, 0.05f);
			lr5.SetColors (Color.blue, Color.blue);
			lr5.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points5 [i] = new Vector3 ((-0.006f) * i + Line.Instance.cx, (-0.006f) * i + Line.Instance.cy, 0f);

				comparePoints5.Add (points5 [i]);

				lr5.SetPosition (i, points5 [i]);
			}
		}
}
