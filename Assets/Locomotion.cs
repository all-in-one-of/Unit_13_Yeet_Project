using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locomotion : MonoBehaviour
{
    //Grabbing component references...
    private NavMeshAgent _nav;
    private Animator _anims;
    
    //Defining an array of waypoint gameobjects
    private GameObject[] _wayPoints;
    
    private Vector3 _navDestination;

    public static float stopRad = .5f;

    
    private float _waitTime = 3f;
    private int _nextPoint = 0;
    private bool isWaiting = false;

	// Use this for initialization
	void Awake ()
    {
        _nav = GetComponent<NavMeshAgent>();
        _anims = GetComponentInChildren<Animator>();
        
        //Search the scene for anything tagged as "Waypoint" and add it to the array
        _wayPoints = GameObject.FindGameObjectsWithTag("Waypoints");
        _nav.stoppingDistance = stopRad;


        _nav.autoBraking = false;

        GoToNextPoint();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Lock the anim parameter "Speed" to the magnitude of the velocity vector
        _anims.SetFloat("Speed", _nav.velocity.sqrMagnitude);

        //If the remaining distance to the current waypoint is less than 1f - GoToNextPoint()
        if (!_nav.pathPending && _nav.remainingDistance <1f)
        {
            //StartCoroutine(Pause());
            GoToNextPoint();
        }
    }


    //This function advances the destination to the next waypoint
    void GoToNextPoint()
    {
        if (_wayPoints.Length == 0)
            return;

        _nextPoint = (_nextPoint + 1) % _wayPoints.Length;
        _nav.destination = _wayPoints[_nextPoint].transform.position;
        

    }
    

    IEnumerator Pause()
    {
        isWaiting = true;
        float t = 0f;
        while (t < _waitTime)
        {
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        GoToNextPoint();
        isWaiting = false;

        
        yield return null;
    }

}
