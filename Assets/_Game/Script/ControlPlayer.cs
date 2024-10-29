using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controlling
public class ControlPlayer : MonoBehaviour
{

   public static ControlPlayer instance;
   public Vector2 beginPoint;
   public Vector2 endPoint;
    void Awake()
    {
        instance = this;
    }

    public void SetDirection( ref Direct dir)
    {
        if(Input.GetMouseButtonDown(0))
        {
            beginPoint= Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition;
            Vector2 tmpVector = endPoint - beginPoint;
            float xVec = Mathf.Abs(tmpVector.x);
            float yVec = Mathf.Abs(tmpVector.y);
            if (xVec > yVec)
            {
                if (tmpVector.x > 0)
                {
                    dir = Direct.Right;
                }

                else
                {
                    dir = Direct.Left;
                }
            }


            else
            {
            if(tmpVector.y > 0)
                {
                    dir = Direct.Forward;
                }
                else
                {
                    dir= Direct.Back;
                }
            }
        }
    }
    
   
}
public enum Direct
{
    None = 0,
    Left = 1,
    Right = 2,
    Forward = 3,
    Back = 4,
}
