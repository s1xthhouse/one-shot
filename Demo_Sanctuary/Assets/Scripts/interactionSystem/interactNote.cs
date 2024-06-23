using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactNote : MonoBehaviour
{
    public GameObject myOverlay;
    public bool note = false;
    public bool playerOn;
    public bool time = true;
    public GameObject Character;
    public player takeAnim;

    public void Start ()
    {
        takeAnim = Character.GetComponent<player>();
    }

    public void Update()
    {
        if(Input.GetButton("Use") && note == false && playerOn == true && time == true)
            {
                note = true;
                
                StartCoroutine(MyFunction());
                IEnumerator MyFunction()
                {
                    player._take = 1;
                    time = false;
                    yield return new WaitForSeconds (2);
                    time = true;
                    myOverlay.SetActive(true); 
                    player._take = 0; 
                }                  
            }
            else
            {
                if(Input.GetButton("Use") && note == true && playerOn == true && time == true)
                {
                    note = false;
                    myOverlay.SetActive(false);
                    StartCoroutine(MyFunction2());
                    IEnumerator MyFunction2()
                    {
                        time = false;
                        yield return new WaitForSeconds (1);
                        time = true;
                    }                     
                }
            }   
    }

        
        
        
    private void OnTriggerStay(Collider other)
    {
		if(other.CompareTag("Player"))
        {
		    playerOn = true;
	    }
    }

    private void OnTriggerExit(Collider other)
    {
		if(other.CompareTag("Player"))
        {
			playerOn = false;
		}
	}
}


    


