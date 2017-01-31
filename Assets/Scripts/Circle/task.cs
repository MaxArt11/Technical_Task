using UnityEngine;
using System.Collections;

public class task : MonoBehaviour {


	void Update () {
        gameObject.transform.position = new Vector3(Line.Instance.center_x, 2.15f + Line.Instance.center_y, 0.0f);
	}
}
