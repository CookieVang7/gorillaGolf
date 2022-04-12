using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverBall : MonoBehaviour
{
    public static bool hittable;
    void OnMouseOver()
    {
        hittable = true;
        //Debug.Log(hittable);
    }

    void OnMouseExit()
    {
        hittable = false;
        //Debug.Log(hittable);
    }
}