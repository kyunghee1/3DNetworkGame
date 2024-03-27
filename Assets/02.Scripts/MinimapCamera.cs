using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public static MinimapCamera Instance;

   
    public Character Target;


    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target ==null)
        {
            return;
        }

        Vector3 position = Target.transform.position;
        position.y = 10;

        transform.position = position;


        Vector3 angle = Target.transform.eulerAngles;
        angle.x = 90;
        angle.z = 0;

        transform.eulerAngles = angle;
    }
}
