using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    private Animator anim;

	public float trapTimer = 10f;

    private bool _spikeTrapActive;
    public bool SpikeTrapActive
    {
        get { return _spikeTrapActive; }
        set { _spikeTrapActive = value; }
    }

	// Use this for initialization
	void Awake ()
    {
        anim = GetComponent<Animator>();
	    //StartCoroutine(AutoTrap());

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

            anim.SetTrigger("Trap");
        }
	}

	IEnumerator AutoTrap()
	{
		float t = 0;

		while (t < trapTimer)
		{
			t += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
		
		anim.SetTrigger("Trap");
		StartCoroutine(AutoTrap());
	}
}
