using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Animator animator;
    private int _state;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
		if(other.CompareTag("Player"))
        {
			if(Input.GetKey(KeyCode.E))
            {
                _state = 1;
            }
		}
        animator.SetInteger("state", _state);
        
	}

}
