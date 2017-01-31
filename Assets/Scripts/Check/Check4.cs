using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check4 : MonoBehaviour {

	public List<Vector3> comparePoints3;
	public static Check4 Instance;
	LineRenderer lr3;

	void Start () {
		Instance = this;
}
    public void Check()
    {
			lr3 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points3 = new Vector3[Circe.segments + 1];
            comparePoints3 = new List<Vector3>();

			lr3.SetVertexCount (Circe.segments + 1);
			lr3.SetWidth (0.05f, 0.05f);
			lr3.SetColors (Color.blue, Color.blue);
			lr3.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points3 [i] = new Vector3 ((0.006f) * i + Line.Instance.center_x, (-0.006f) * i + Line.Instance.center_y, 0f);

				comparePoints3.Add (points3 [i]);

				lr3.SetPosition (i, points3 [i]);
			}
		}
}
