using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour
{
    public GameObject camold;
	public GameObject camnew;
	public GameObject Character;
    public player C;
	public void Start ()
    {
        C = Character.GetComponent<player>();
		player.Camera = camold;
    }

	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			camold.SetActive(false);
			camnew.SetActive(true);
			StartCoroutine(MyFunction());
                IEnumerator MyFunction()
                {
					yield return new WaitForSeconds (1);
                    player.Camera = camnew;
                }      
		}
	}
}
