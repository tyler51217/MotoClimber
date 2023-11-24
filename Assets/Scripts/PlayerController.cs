using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public WheelJoint2D wheel;

    

    void Update()
    {
        if (!UIController.alive)
        {
            wheel.useMotor = false;
            return;
        }
        if (Input.GetMouseButton(0))
        {
            wheel.useMotor = true;
        }
        else
        {
            wheel.useMotor = false;
        }

        




    }

    


}
