using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTrapController : MonoBehaviour
{
    private HingeJoint hingeControl;
	
	public float trapTimer = 10f;

	private float trapCounter = 0f;

	// Use this for initialization
	void Awake ()
    {
        hingeControl = GetComponentInChildren<HingeJoint>();
        hingeControl.useMotor = true;

	}
	
	// Update is called once per frame
	void Update ()
	{
		trapCounter += Time.fixedDeltaTime;

		if (trapCounter > trapTimer)
		{
			hingeControl.useMotor = !hingeControl.useMotor;
			trapCounter = 0;
		}


	}
}
