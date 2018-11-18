using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locomotion : MonoBehaviour
{
    private NavMeshAgent _nav;
    private Animator _anims;
    private GameObject[] _wayPoints;
    private Vector3 _navDestination;

    public static float stopRad = .5f;

    private float _waitTime = 3f;
    private int _nextPoint = 0;

	// Use this for initialization
	void Awake ()
    {
        _nav = GetComponent<NavMeshAgent>();
        _anims = GetComponentInChildren<Animator>();
        _wayPoints = GameObject.FindGameObjectsWithTag("Waypoints");
        _nav.stoppingDistance = stopRad;


        _navDestination = InitNav();
        _nav.isStopped = false;
	}
	
	// Update is called once per frame
	void Update ()
    {


        _nav.SetDestination(_navDestination);
        Debug.Log("Distance to destination: " + _nav.remainingDistance);

        _anims.SetFloat("Speed", _nav.velocity.sqrMagnitude);

        if (_nav.remainingDistance < stopRad && !_nav.isStopped)
        {
            _nav.isStopped = !_nav.isStopped;
            _navDestination = NextWayPoint();
            //StartCoroutine(Pause());
        }

        Debug.Log(_nav.isStopped);
    }

    private Vector3 InitNav()
    {
        //_nav.isStopped = false;
        int initPos = 1;
        //int initPos = Random.Range(0, _wayPoints.Length);
        return _wayPoints[initPos].transform.position;

        
        
    }

    private Vector3 NextWayPoint()
    {
        
        _nextPoint++;
        return _wayPoints[_nextPoint % _wayPoints.Length].transform.position;
     
    }

    IEnumerator Pause()
    {
        float t = 0f;
        while (t < _waitTime)
        {
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        _navDestination = NextWayPoint();
        //_nav.isStopped = !_nav.isStopped;
        Debug.Log("Destination is: " + _navDestination);
        yield return null;
    }

}
