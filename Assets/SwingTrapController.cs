using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTrapController : MonoBehaviour
{
    private HingeJoint hingeControl;

	// Use this for initialization
	void Awake ()
    {
        hingeControl = GetComponentInChildren<HingeJoint>();
        hingeControl.useMotor = true;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            hingeControl.useMotor = !hingeControl.useMotor;
        }
	}
}
