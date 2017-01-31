using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Line : MonoBehaviour {

    private LineRenderer line;
	public bool isMousePressed;
    public List<Vector3> pointsList;
    private Vector3 mousePos;
	public int pointsCount = 0;
	public static Line Instance;
	public float center_x, extents_x, max, mix;
	public float center_y, extents_y, may, miy;
	public int count;

    void Start()
    {
		Instance = this;
		 
        line = transform.GetComponent<LineRenderer>();

        line.SetVertexCount(0);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(Color.black, Color.black);
        line.useWorldSpace = true;
        isMousePressed = false;
        pointsList = new List<Vector3>();
		count = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
			count = 1;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
			pointsCount = pointsList.Count;
			center_x = line.bounds.center.x;
			center_y = line.bounds.center.y;
			extents_x = line.bounds.extents.x;
			extents_y = line.bounds.extents.y;
			count = 0;
        }
        if (isMousePressed)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
            }
        }
    }
}

