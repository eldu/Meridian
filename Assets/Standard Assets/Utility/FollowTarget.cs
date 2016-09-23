using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {

		public GameObject player;
		Transform target; //the enemy's target
		float moveSpeed = 1.2f; //move speed
		float rotationSpeed = 1.2f; //speed of turning
		float range = 100f;
		float range2 = 100f;
		float stop = 0;
		Transform myTransform; //current transform data of this enemy


		void Awake()
		{
			myTransform = transform; //cache transform data for easy access/preformance
		}

		void Start()
		{
			target = player.transform; //target the player

		}

		void Update () {
			//rotate to look at the player
			float distance = Vector3.Distance(myTransform.position, target.position);
			if (distance<=range2 &&  distance>=range){
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
					Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			}


			else if(distance<=range && distance>stop){

				//move towards the player
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
					Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			}
			else if (distance<=stop) {
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
					Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			}


		}
    }
}
