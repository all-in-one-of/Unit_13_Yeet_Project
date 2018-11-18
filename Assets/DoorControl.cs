using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private Animator _anims;
    public Collider _doorCollider;

    private void Awake()
    {
        _anims = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            _anims.SetTrigger("Open");
            _doorCollider.enabled = false;
        }
    }
}
