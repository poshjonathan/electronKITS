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

	public Text txtRoundHeader;

	private GameObject correctText, wrongText;

	private GameManagerScript chkClick;

	public AudioSource correct_sound, wrong_sound;

	// Use this for initialization
	void Start()
	{

		txtRoundHeader.text = "Round 1";

		correctText = GameObject.Find("CorrectText");
		correctText.SetActive(false);

wrongText = GameObject.Find("WrongText");
wrongText.SetActive(false);

		chkClick = GameObject.Find("GameManager").GetComponent<GameManagerScript>();


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

		if (chkClick.checkBtnClick == true)
		{
			checkAnswer();
			chkClick.checkBtnClick = false;
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
		{

			correctText.SetActive(true);
			wrongText.SetActive(false);
			correct_sound.Play();

		}
		else
		{


			wrongText.SetActive(true);
			wrong_sound.Play();


		}


	}
}
