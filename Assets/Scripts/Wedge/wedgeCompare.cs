
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wedgeCompare : MonoBehaviour
{

    public int[] collisionPoint;
    public int[] modelCollisionPoint;
    public float[] delta;

    public float sum;

    void OnGUI()
    {
        GUI.Label(new Rect(345, 3, 100, 100), "Draw this shape:");
    }

    //calculates the distance between two points
    public float lenght(Vector3 pointA, Vector3 pointB)
    {
        float length = Mathf.Sqrt((pointB.x - pointA.x) * (pointB.x - pointA.x) + (pointB.y - pointA.y) * (pointB.y - pointA.y));
        return length;
    }

    //returns the index of list's element, which is intersect by the "check" line
    int pointCollisionInizializate(List<Vector3> list1, List<Vector3> list2)
    {
        int array = 0;

        for (int j = 0; j < list1.Count; j++)
        {
            for (int k = 0; k < list2.Count; k++)
            {
                if (checkPoints(list1[j], list2[k]))
                {
                    array = j;
                }
            }
        }
        return array;
    }

    //returns true if two points is close enough
    public bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        if ((Mathf.Abs(pointA.x - pointB.x) < 0.2f) && (Mathf.Abs(pointA.y - pointB.y) < 0.2f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {

        if (Line.Instance.count == 0)
        {
            collisionPoint = new int[5];

            collisionPoint[0] = pointCollisionInizializate(Line.Instance.pointsList, Check1.Instance.comparePoints);
            collisionPoint[1] = pointCollisionInizializate(Line.Instance.pointsList, Check2.Instance.comparePoints1);
            collisionPoint[2] = pointCollisionInizializate(Line.Instance.pointsList, Check3.Instance.comparePoints2);
            collisionPoint[3] = pointCollisionInizializate(Line.Instance.pointsList, Check7.Instance.comparePoints6);
            collisionPoint[4] = pointCollisionInizializate(Line.Instance.pointsList, Check8.Instance.comparePoints7);

            modelCollisionPoint = new int[5];

            modelCollisionPoint[0] = pointCollisionInizializate(wedge.Instance.ModelPointList, Check1.Instance.comparePoints);
            modelCollisionPoint[1] = pointCollisionInizializate(wedge.Instance.ModelPointList, Check2.Instance.comparePoints1);
            modelCollisionPoint[2] = pointCollisionInizializate(wedge.Instance.ModelPointList, Check3.Instance.comparePoints2);
            modelCollisionPoint[3] = pointCollisionInizializate(wedge.Instance.ModelPointList, Check7.Instance.comparePoints6);
            modelCollisionPoint[4] = pointCollisionInizializate(wedge.Instance.ModelPointList, Check8.Instance.comparePoints7);

            delta = new float[5];

            Camera.main.transform.position = new Vector3(Line.Instance.center_x, Line.Instance.center_y, -10.0f);
            wedge.Instance.Draw();
            Check1.Instance.Check();
            Check2.Instance.Check();
            Check3.Instance.Check();
            Check7.Instance.Check();
            Check8.Instance.Check();

            for (int i = 0; i < 5; i++)
            {
                delta[i] = lenght(Line.Instance.pointsList[collisionPoint[i]], wedge.Instance.ModelPointList[modelCollisionPoint[i]]);
            }

            sum = delta[0] + delta[1] + delta[2] + delta[3] + delta[4];

            //condition of accepting a new level
            if ((delta[0] <= 0.6f) && (delta[1] <= 0.6f) && (delta[2] <= 0.6f) && (delta[3] <= 0.6f) && (delta[4] <= 0.6f) && (sum <= 3.2f) && (Line.Instance.extents_x > 0.4f))
            {
                Application.LoadLevel("Level3");
            }
        }

    }
}
