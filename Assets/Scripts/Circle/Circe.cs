using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circe : MonoBehaviour {

	public static int segments = 1000;
	public float xradius;
	public float yradius;
	LineRenderer line;
	public List<Vector3> ModelPointList;
	public static Circe Instance;

	void Start() {
		Instance = this;
        Score.Instance.score++;
	}

	public void Draw ()
	{
		line = gameObject.GetComponent<LineRenderer>();

		line.SetVertexCount (segments + 1);
		line.useWorldSpace = true;
		line.SetWidth (0.05f, 0.05f);
		line.SetColors (Color.blue, Color.blue);
		xradius = Line.Instance.ex;
		yradius = Line.Instance.ex;

		CreatePoints ();

	}

	public void CreatePoints ()
	{
		float x;
		float y;
		float z = 0f;

		float angle = 20f;
		Vector3[] ModelPoints = new Vector3[segments + 1];
		ModelPointList = new List<Vector3> ();
		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius + Line.Instance.cx;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius + Line.Instance.cy;

			ModelPoints[i] = new Vector3 (x, y, z);

			ModelPointList.Add(ModelPoints[i]);

			line.SetPosition(i, ModelPoints[i]);

			angle += (360f / segments);
		}

	}
}
