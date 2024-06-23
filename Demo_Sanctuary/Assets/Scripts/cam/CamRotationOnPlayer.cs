using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationOnPlayer : MonoBehaviour
{
   public Transform objectToLookAt;
   void Update()
   {
	   transform.LookAt(objectToLookAt);
   }
   

}
