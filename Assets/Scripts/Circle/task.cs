using UnityEngine;
using System.Collections;

public class task : MonoBehaviour {


	void Update () {
        gameObject.transform.position = new Vector3(Line.Instance.cx, 2.15f + Line.Instance.cy, 0.0f);
	}
}
