using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSelectorScript : MonoBehaviour
{


	public GameObject goRound1, goRound2, goRound3, goRound4,goRoundComplete;
	public GameObject round1Script, round2Script;

	private GameManagerScript chkRound;

	// Use this for initialization
	void Awake()
	{
		goRound1.SetActive(false);
		goRound2.SetActive(false);
		goRound3.SetActive(false);
		goRound4.SetActive(false);
		goRoundComplete.SetActive(false);

		chkRound = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

		round1Script.GetComponent<LogicGateRound1>().enabled = false;
		//Only round 2 is required
		round2Script.GetComponent<LogicGateRound2>().enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (chkRound.round1 == true)
		{
			
				
			round1Script.GetComponent<LogicGateRound1>().enabled = true;
			goRound1.SetActive(true);

		}

		if (chkRound.round2 == true)
		{

			round2Script.GetComponent<LogicGateRound2>().enabled = true;
			chkRound.round1 = false;
			StartCoroutine(startRound2());


		}

		if (chkRound.round3 == true)
		{

			chkRound.round2 = false;

			StartCoroutine(startRound3());
		}

		if (chkRound.round4 == true)
		{
			chkRound.round3 = false;
			StartCoroutine(startRound4());
		}

		if (chkRound.roundComplete == true)
		{

			chkRound.round4 = false;
            StartCoroutine(startRoundComplete());


		}



	}

	public IEnumerator startRound2()
	{
		goRound1.SetActive(false);
		yield return new WaitForSeconds(2f);
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

	public IEnumerator startRound4()
	{
		goRound3.SetActive(false);
		yield return new WaitForSeconds(2f);
		goRound4.SetActive(true);
		yield break;
	}

public IEnumerator startRoundComplete()
{
	goRound4.SetActive(false);
	yield return new WaitForSeconds(2f);
	goRoundComplete.SetActive(true);
	yield break;	}

}
