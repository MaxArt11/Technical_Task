
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangleCompare : MonoBehaviour
{

    public int[] collisionPoint;
    public int[] modelCollisionPoint;
    public float[] delta;
    public bool winner = false;
    public static triangleCompare Instance;

    void Start()
    {
        Instance = this;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(345, 3, 100, 100), "Draw this shape:");
    }

    public float sum;

    public float lenght(Vector3 pointA, Vector3 pointB)
    {
        float length = Mathf.Sqrt((pointB.x - pointA.x) * (pointB.x - pointA.x) + (pointB.y - pointA.y) * (pointB.y - pointA.y));
        return length;
    }

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
            collisionPoint = new int[8];

            collisionPoint[0] = pointCollisionInizializate(Line.Instance.pointsList, Check1.Instance.comparePoints);
            collisionPoint[1] = pointCollisionInizializate(Line.Instance.pointsList, Check2.Instance.comparePoints1);
            collisionPoint[2] = pointCollisionInizializate(Line.Instance.pointsList, Check3.Instance.comparePoints2);
            collisionPoint[3] = pointCollisionInizializate(Line.Instance.pointsList, Check4.Instance.comparePoints3);
            collisionPoint[4] = pointCollisionInizializate(Line.Instance.pointsList, Check5.Instance.comparePoints4);
            collisionPoint[5] = pointCollisionInizializate(Line.Instance.pointsList, Check6.Instance.comparePoints5);
            collisionPoint[6] = pointCollisionInizializate(Line.Instance.pointsList, Check7.Instance.comparePoints6);
            collisionPoint[7] = pointCollisionInizializate(Line.Instance.pointsList, Check8.Instance.comparePoints7);

            modelCollisionPoint = new int[8];

            modelCollisionPoint[0] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check1.Instance.comparePoints);
            modelCollisionPoint[1] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check2.Instance.comparePoints1);
            modelCollisionPoint[2] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check3.Instance.comparePoints2);
            modelCollisionPoint[3] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check4.Instance.comparePoints3);
            modelCollisionPoint[4] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check5.Instance.comparePoints4);
            modelCollisionPoint[5] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check6.Instance.comparePoints5);
            modelCollisionPoint[6] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check7.Instance.comparePoints6);
            modelCollisionPoint[7] = pointCollisionInizializate(Triangle.Instance.ModelPointList, Check8.Instance.comparePoints7);

            delta = new float[8];

            Camera.main.transform.position = new Vector3(Line.Instance.cx, Line.Instance.cy, -10.0f);
            Triangle.Instance.Draw();
            Check1.Instance.Check();
            Check2.Instance.Check();
            Check3.Instance.Check();
            Check4.Instance.Check();
            Check5.Instance.Check();
            Check6.Instance.Check();
            Check7.Instance.Check();
            Check8.Instance.Check();

            for (int i = 0; i < 8; i++)
            {
                delta[i] = lenght(Line.Instance.pointsList[collisionPoint[i]], Triangle.Instance.ModelPointList[modelCollisionPoint[i]]);
            }

            sum = delta[0] + delta[1] + delta[2] + delta[3] + delta[4] + delta[5] + delta[6] + delta[7];

            if ((delta[0] <= 0.6f) && (delta[1] <= 0.6f) && (delta[2] <= 0.6f) && (delta[3] <= 0.6f) && (delta[4] <= 0.6f) && (delta[5] <= 0.6f) && (delta[6] <= 0.6f) && (delta[7] <= 0.6f) && (sum <= 4.0f) && (Line.Instance.ex > 0.5f))
            {
                Score.Instance.score++;
                winner = true;
                Application.LoadLevel("Level1");
            }
        }

    }
}
