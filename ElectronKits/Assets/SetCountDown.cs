using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour
{

	private GameManagerScript GMS;
	public GameObject countdown;
	public GameObject round1;

	public void SetCountDownNow()
	{
		//Change the boolean status of the countdown timer
		GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		GMS.counterDownDone = true;


		GMS.round1 = true;
		countdown.SetActive(false);
		GMS.stopWatch.Start();
	}


}
