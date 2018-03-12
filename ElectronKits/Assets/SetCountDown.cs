using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour {

	private GameManagerScript GMS;
	public GameObject countdown;

	public void SetCountDownNow()
	{
		//Change the boolean status of the countdown timer
		GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		GMS.counterDownDone = true;


	}

	void Update()
	{


		if (GMS.counterDownDone == true)
		{

			countdown.SetActive(false);

		}

	}

}
