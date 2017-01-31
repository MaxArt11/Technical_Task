using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check7 : MonoBehaviour {

	public List<Vector3> comparePoints6;
	public static Check7 Instance;
	LineRenderer lr6;

	void Start () {
		Instance = this;
}
    public void Check()
    {
			lr6 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points6 = new Vector3[Circe.segments + 1];
            comparePoints6 = new List<Vector3>();

			lr6.SetVertexCount (Circe.segments + 1);
			lr6.SetWidth (0.05f, 0.05f);
			lr6.SetColors (Color.blue, Color.blue);
			lr6.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points6 [i] = new Vector3 ((-0.006f) * i + Line.Instance.cx, 0f + Line.Instance.cy, 0f);

				comparePoints6.Add (points6 [i]);

				lr6.SetPosition (i, points6 [i]);
			}
		}
}
