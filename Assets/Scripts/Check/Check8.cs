using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check8 : MonoBehaviour {

	public List<Vector3> comparePoints7;
	public static Check8 Instance;
	LineRenderer lr7;

	void Start () {
		Instance = this;
	}

	public void Check() {
			lr7 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points7 = new Vector3[Circe.segments + 1];
            comparePoints7 = new List<Vector3>();

			lr7.SetVertexCount (Circe.segments + 1);
			lr7.SetWidth (0.05f, 0.05f);
			lr7.SetColors (Color.blue, Color.blue);
			lr7.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points7 [i] = new Vector3 ((-0.006f) * i + Line.Instance.center_x, (0.006f) * i + Line.Instance.center_y, 0f);

				comparePoints7.Add (points7 [i]);

				lr7.SetPosition (i, points7 [i]);
			}
		}
}
