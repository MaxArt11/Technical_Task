using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check5 : MonoBehaviour {

	public List<Vector3> comparePoints4;
	public static Check5 Instance;
	LineRenderer lr4;

	void Start () {
		Instance = this;
}
    public void Check()
    {
			lr4 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points4 = new Vector3[Circe.segments + 1];
            comparePoints4 = new List<Vector3>();

			lr4.SetVertexCount (Circe.segments + 1);
			lr4.SetWidth (0.05f, 0.05f);
			lr4.SetColors (Color.blue, Color.blue);
			lr4.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points4 [i] = new Vector3 (0f + Line.Instance.cx, (-0.006f) * i + Line.Instance.cy, 0f);

				comparePoints4.Add (points4 [i]);

				lr4.SetPosition (i, points4 [i]);
			}
		}
}
