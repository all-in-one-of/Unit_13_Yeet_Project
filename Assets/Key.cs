using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyID;
    public string keyName;
    public KeyChain keyChain;

	private void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.CompareTag("Player"))
        {


            // Add this Key to our KeyChain
            // Play a pick-up SFX
            keyChain.AddKey(this);

            this.gameObject.SetActive(false);
        }
	}
}
