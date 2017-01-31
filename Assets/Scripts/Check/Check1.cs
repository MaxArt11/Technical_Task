using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check1 : MonoBehaviour {

	public List<Vector3> comparePoints;
	public static Check1 Instance;
	LineRenderer lr0;

	void Start () {
		Instance = this;
	}
	public void Check() {

			lr0 = gameObject.GetComponent<LineRenderer> ();

			Vector3[] points0 = new Vector3[Circe.segments + 1];
            comparePoints = new List<Vector3>();

			lr0.SetVertexCount (Circe.segments + 1);
			lr0.SetWidth (0.05f, 0.05f);
			lr0.SetColors (Color.blue, Color.blue);
			lr0.useWorldSpace = true;

			for (int i = 0; i < Circe.segments + 1; i++) {
				points0 [i] = new Vector3 (0f + Line.Instance.center_x, (0.006f) * i + Line.Instance.center_y, 0f);

				comparePoints.Add (points0 [i]);

				lr0.SetPosition (i, points0 [i]);
			
		}
	}
}
