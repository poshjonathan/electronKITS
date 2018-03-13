using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSelectorScript : MonoBehaviour
{


	public GameObject goRound1, goRound2, goRound3,goRound4,round234Script;

	private GameManagerScript chkRound;

	// Use this for initialization
	void Start()
	{
		round234Script.SetActive(false);
		goRound1.SetActive(false);
		goRound2.SetActive(false);
		goRound3.SetActive(false);
		//goRound4.SetActive(false);


		chkRound = GameObject.Find("GameManager").GetComponent<GameManagerScript>();


	}

	// Update is called once per frame
	void Update()
	{



		if (chkRound.round1 == true)
		{

			goRound1.SetActive(true);

		}

		if (chkRound.round2 == true)
		{
			chkRound.round1 = false;
			StartCoroutine(startRound2());


		}

		if (chkRound.round3 == true)
		{
			chkRound.round2 = false;
			StartCoroutine(startRound3());


		}



	}

	public IEnumerator startRound2()
	{


		goRound1.SetActive(false);
		yield return new WaitForSeconds(2f);

		round234Script.SetActive(true);
		goRound2.SetActive(true);
		yield break;
	}


	public IEnumerator startRound3()
	{
			

		goRound2.SetActive(false);
	
		yield return new WaitForSeconds(2f);

		goRound3.SetActive(true);
			
		yield break;
	}

}
