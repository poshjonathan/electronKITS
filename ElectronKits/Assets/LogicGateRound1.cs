using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class LogicGateRound1 : MonoBehaviour
{


	private static int orInputA_State, orInputB_State;
	private static int andInputA_State, andInputB_State;
	private static int norInputA_State, norInputB_State;

	private GameObject btnOrInputA, btnOrInputB;
	private GameObject btnAndInputA, btnAndInputB;
	private GameObject btnNorInputA, btnNorInputB;

	private static bool orTracker = false, andTracker = false, norTracker = false;

	public TextMesh txtOrOutput_current, txtAndOutput_current, txtNorOutput_current;


	private GameManagerScript GMS;

	public AudioSource correct_sound, wrong_sound;

	private soundPlay soundPlay;
	//private GameObject round1;

	//Get information from GameManger Script
	private GameManagerScript gmRound2;

	// Use this for initialization
	void Start()
	{
		//Get information from GameManger Script
		GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
soundPlay = GameObject.Find("Rounds").GetComponent<soundPlay>();




	}

	// Update is called once per frame
	void Update()
	{





		orTracker = customOrGateTracker.orGateTracker;
		norTracker = customNorGateTracker.norGateTracker;
		andTracker = customAndGateTracker.andGateTracker;

		//Listener for buttons
		orInputA_State = onClickOrInputAScript.iInput_current;
		orInputB_State = OnClickOrInputBScript.iInput_current;

		andInputA_State = OnClickAndInputAScript.iInput_current;
		andInputB_State = OnClickAndInputBScript.iInput_current;

		norInputA_State = OnClickNorInputAScript.iInput_current;
		norInputB_State = OnClickNorInputBScript.iInput_current;





		txtOrOutput_current.text = orGateFunction().ToString();

		txtAndOutput_current.text = andGateFunction().ToString();



		txtNorOutput_current.text = norGateFunction().ToString();

		if (GMS.checkBtnClick == true)
		{
			checkAnswer();

		}

	}


	int orGateFunction()
	{
		if (orInputA_State == 1 || orInputB_State == 1)
		{

			return 1;
		}
		else
		{

			return 0;


		}


	}
	int andGateFunction()
	{
		if (andInputA_State == 1 && andInputB_State == 1)
		{

			return 1;
		}
		else
		{

			return 0;


		}

	}

	int norGateFunction()
	{
		if (norInputA_State == 0 && norInputB_State == 0)
		{

			return 1;
		}
		else
		{

			return 0;


		}
	}


	void checkAnswer()
	{

		//Correct Answer
		if (andGateFunction() == 1)
		{	soundPlay.soundCorrectNow();
			StartCoroutine(correctAnswer());

				

	
		}
		else
		{
			soundPlay.soundWrongNow();
			StartCoroutine(wrongAnswer());

		

		}
			GMS.checkBtnClick = false;// This one cannot put inside coroutine!

	}

	public IEnumerator correctAnswer()
	{




		soundPlay.showCorrectText();
			yield return new WaitForSeconds(1.5f);
		soundPlay.hideCorrectText();
		GMS.round2 = true;
		yield break;



	}

	public IEnumerator wrongAnswer()
	{



		soundPlay.showWrongText();
		yield return new WaitForSeconds(1.5f);
			soundPlay.hideWrongText();
	
		yield break;
	}


}
