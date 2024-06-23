using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	CharacterController Controller;
	public Animator animator;
	public float speed = 5;
	public static int _take;
	public static GameObject Camera; 
	public float RunSpeed = 2;
	public float WalkSpeed = 1;
	float animationSpeed;
	float gravity = 100.0f;

	
    void Start()
    {
        Controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		movement = Camera.transform.TransformDirection(movement);

		var rotation = Quaternion.AngleAxis(-Camera.transform.eulerAngles.x, Camera.transform.right);
		movement = rotation * movement;
		
		if(movement.x != 0 || movement.z != 0)
		{
			if(Input.GetButton("Run"))
			{
				animationSpeed = 1f;
				speed = RunSpeed;
			}
			else
			{
				animationSpeed = 0.4f;
				speed = WalkSpeed;
			}
		}
		else
		{
			animationSpeed = 0;
		}

		Vector3 Cancelled = new Vector3(movement.x, 0, movement.z);

		if(Cancelled != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cancelled), 0.15f);
		}
		movement.y -= gravity * speed * Time.deltaTime;

		Controller.Move(movement * speed * Time.deltaTime);
		animator.SetFloat("Speed", animationSpeed);



		if(_take == 1)
		{
			    StartCoroutine(MyFunction());
                IEnumerator MyFunction()
                {
					animator.SetInteger("take", _take);
                    yield return new WaitForSeconds (2);
                    _take = 0; 
					animator.SetInteger("take", _take);
                }  
		}
	}
}
