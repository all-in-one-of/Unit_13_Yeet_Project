using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //public Locomotion loco;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Locomotion.stopRad);
    }
}
