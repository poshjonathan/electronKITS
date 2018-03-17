using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class LogicGateRound2 : MonoBehaviour
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
	private int questionNumber = 2;

	//Get information from GameManger Script

	//private GameObject round1;

	//Added for round 2
	private GameObject goNorOutLine, goAndOutLine, goOrOutLine;

	private LineRenderer norOutLine, andOutLine, orOutLine;

	private GameObject goOrBulb, goAndBulb, goNorBulb;

	//Track possibility of different position
	private bool sNorOut_OrInA, sNorOut_OrInB;
	private bool sNorOut_AndInA, sNorOut_AndInB;

	private bool sOrOut_NorInA, sOrOut_NorInB;
	private bool sOrOut_AndInA, sOrOut_AndInB;

	private bool sAndOut_OrInA, sAndOut_OrInB;
	private bool sAndOut_NorInA, sAndOut_NorInB;

	public GameObject norGateOut, norGateInA, norGateInB;
	public GameObject andGateOut, andGateInA, andGateInB;
	public GameObject orGateOut, orGateInA, orGateInB;

	private float distanceNor_Min, distanceOr_Min, distanceAnd_Min;
	private int distanceNor_Index = 1, distanceOr_Index = 1, distanceAnd_Index = 1;

	public ParticleSystem orFireEffect, andFireEffect, norFireEffect;

	private soundPlay soundPlay;

	public Text showTime;

	public Button retryBtn;
	//public GameObject countDownRetry;


	// Use this for initialization
	void Start()
	{
		//Get information from GameManger Script
		GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		soundPlay = GameObject.Find("Rounds").GetComponent<soundPlay>();

		//Added for round 2
		goNorOutLine = GameObject.Find("goNorLine");
		norOutLine = goNorOutLine.AddComponent<LineRenderer>();
		norOutLine.enabled = false;

		goAndOutLine = GameObject.Find("goAndLine");
		andOutLine = goAndOutLine.AddComponent<LineRenderer>();
		andOutLine.enabled = false;

		goOrOutLine = GameObject.Find("goOrLine");
		orOutLine = goOrOutLine.AddComponent<LineRenderer>();
		orOutLine.enabled = false;

		goOrBulb = GameObject.Find("orBulb");
		goAndBulb = GameObject.Find("andBulb");
		goNorBulb = GameObject.Find("norBulb");

		goOrBulb.SetActive(false);
		goAndBulb.SetActive(false);
		goNorBulb.SetActive(false);

		norOutLine.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		norOutLine.startColor = Color.cyan;
		norOutLine.endColor = Color.blue;
		norOutLine.startWidth = 0.25f;
		norOutLine.endWidth = 0.25f;

		andOutLine.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		andOutLine.startColor = Color.cyan;
		andOutLine.endColor = Color.blue;
		andOutLine.startWidth = 0.25f;
		andOutLine.endWidth = 0.25f;


		orOutLine.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		orOutLine.startColor = Color.cyan;
		orOutLine.endColor = Color.blue;
		orOutLine.startWidth = 0.25f;
		orOutLine.endWidth = 0.25f;

		btnOrInputA = GameObject.Find("orInputA");
		btnOrInputB = GameObject.Find("orInputB");

		btnAndInputA = GameObject.Find("andInputA");
		btnAndInputB = GameObject.Find("andInputB");

		btnNorInputA = GameObject.Find("norInputA");
		btnNorInputB = GameObject.Find("norInputB");


		retryBtn.onClick.AddListener(TaskOnRetryClick);


		//retryBtn.gameObject.SetActive(false);

//countDownRetry.SetActive(false);
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



		if (norTracker == true && orTracker == true && andTracker == true)
		{
			if (checkInputNorConnection().Equals(true))
			{


				norOutLine.enabled = true;

				//Bulb and Resistor-----------------------------------------------------
				float distanceNor1 = Vector3.Distance(norGateOut.transform.position, orGateInA.transform.position);
				float distanceNor2 = Vector3.Distance(norGateOut.transform.position, orGateInB.transform.position);
				float distanceNor3 = Vector3.Distance(norGateOut.transform.position, andGateInA.transform.position);
				float distanceNor4 = Vector3.Distance(norGateOut.transform.position, andGateInB.transform.position);


				float[] distanceNor = new float[] { distanceNor1, distanceNor2, distanceNor3, distanceNor4 };

				distanceNor_Min = distanceNor[0];
				distanceNor_Index = 1;

				for (int i = 0; i <= 3; i++)
				{
					if (distanceNor[i] < distanceNor_Min)
					{
						distanceNor_Min = distanceNor[i];
						distanceNor_Index = (i + 1);
					}

				}

				if (distanceNor_Index == 1)
				{

					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, orGateInA.transform.position);


					sNorOut_OrInA = true;
					sNorOut_OrInB = false;
					sNorOut_AndInA = false;
					sNorOut_AndInB = false;




				}
				if (distanceNor_Index == 2)
				{
					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, orGateInB.transform.position);

					sNorOut_OrInA = false;
					sNorOut_OrInB = true;
					sNorOut_AndInA = false;
					sNorOut_AndInB = false;




				}
				if (distanceNor_Index == 3)
				{
					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, andGateInA.transform.position);

					sNorOut_OrInA = false;
					sNorOut_OrInB = false;
					sNorOut_AndInA = true;
					sNorOut_AndInB = false;



				}
				if (distanceNor_Index == 4)
				{
					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, andGateInB.transform.position);

					sNorOut_OrInA = false;
					sNorOut_OrInB = false;
					sNorOut_AndInA = false;
					sNorOut_AndInB = true;


				}

			}


			if (checkInputOrConnection().Equals(true))
			{

				//if (bulbTracker == true && batteryTracker == true)
				//{
				orOutLine.enabled = true;

				//Bulb and Battery-----------------------------------------------------
				float distanceOr1 = Vector3.Distance(orGateOut.transform.position, norGateInA.transform.position);
				float distanceOr2 = Vector3.Distance(orGateOut.transform.position, norGateInB.transform.position);
				float distanceOr3 = Vector3.Distance(orGateOut.transform.position, andGateInA.transform.position);
				float distanceOr4 = Vector3.Distance(orGateOut.transform.position, andGateInB.transform.position);


				float[] distanceOr = new float[] { distanceOr1, distanceOr2, distanceOr3, distanceOr4 };

				distanceOr_Min = distanceOr[0];
				distanceOr_Index = 1;

				for (int i = 0; i < 4; i++)
				{
					if (distanceOr[i] < distanceOr_Min)
					{
						distanceOr_Min = distanceOr[i];
						distanceOr_Index = (i + 1);
					}

				}

				if (distanceOr_Index == 1)
				{
					RenderLine(orOutLine, orGateOut, norGateInA);
					//orOutLine.SetPosition(0, orGateOut.transform.position);
					//orOutLine.SetPosition(1, norGateInA.transform.position);

					sOrOut_NorInA = true;
					sOrOut_NorInB = false;
					sOrOut_AndInA = false;
					sOrOut_AndInB = false;


				}
				if (distanceOr_Index == 2)
				{
					RenderLine(orOutLine, orGateOut, norGateInB);
					//orOutLine.SetPosition(0, orGateOut.transform.position);
					//orOutLine.SetPosition(1, norGateInB.transform.position);

					sOrOut_NorInA = false;
					sOrOut_NorInB = true;
					sOrOut_AndInA = false;
					sOrOut_AndInB = false;

				}
				if (distanceOr_Index == 3)
				{
					RenderLine(orOutLine, orGateOut, andGateInA);
					//orOutLine.SetPosition(0, orGateOut.transform.position);
					//orOutLine.SetPosition(1, andGateInA.transform.position);

					sOrOut_NorInA = false;
					sOrOut_NorInB = false;
					sOrOut_AndInA = true;
					sOrOut_AndInB = false;
				}
				if (distanceOr_Index == 4)
				{
					RenderLine(orOutLine, orGateOut, andGateInB);
					//orOutLine.SetPosition(0, orGateOut.transform.position);
					//orOutLine.SetPosition(1, andGateInB.transform.position);

					sOrOut_NorInA = false;
					sOrOut_NorInB = false;
					sOrOut_AndInA = false;
					sOrOut_AndInB = true;

				}
			}
			//}


			if (checkInputAndConnection().Equals(true))
			{
				//if (batteryTracker == true && resistorTracker == true)
				//{
				andOutLine.enabled = true;

				//Battery and Resistor-----------------------------------------------------
				float distanceAnd1 = Vector3.Distance(andGateOut.transform.position, orGateInA.transform.position);
				float distanceAnd2 = Vector3.Distance(andGateOut.transform.position, orGateInB.transform.position);
				float distanceAnd3 = Vector3.Distance(andGateOut.transform.position, norGateInA.transform.position);
				float distanceAnd4 = Vector3.Distance(andGateOut.transform.position, norGateInB.transform.position);

				float[] distanceAnd = new float[] { distanceAnd1, distanceAnd2, distanceAnd3, distanceAnd4 };

				distanceAnd_Min = distanceAnd[0];
				distanceAnd_Index = 1;

				for (int i = 0; i < 4; i++)
				{
					if (distanceAnd[i] < distanceAnd_Min)
					{
						distanceAnd_Min = distanceAnd[i];
						distanceAnd_Index = (i + 1);
					}

				}

				if (distanceAnd_Index == 1)
				{
					andOutLine.SetPosition(0, andGateOut.transform.position);
					andOutLine.SetPosition(1, orGateInA.transform.position);


					sAndOut_OrInA = true;
					sAndOut_OrInB = false;
					sAndOut_NorInA = false;
					sAndOut_NorInB = false;
				}
				if (distanceAnd_Index == 2)
				{
					andOutLine.SetPosition(0, andGateOut.transform.position);
					andOutLine.SetPosition(1, orGateInB.transform.position);

					sAndOut_OrInA = false;
					sAndOut_OrInB = true;
					sAndOut_NorInA = false;
					sAndOut_NorInB = false;
				}
				if (distanceAnd_Index == 3)
				{
					andOutLine.SetPosition(0, andGateOut.transform.position);
					andOutLine.SetPosition(1, norGateInA.transform.position);

					sAndOut_OrInA = false;
					sAndOut_OrInB = false;
					sAndOut_NorInA = true;
					sAndOut_NorInB = false;

				}
				if (distanceAnd_Index == 4)
				{
					andOutLine.SetPosition(0, andGateOut.transform.position);
					andOutLine.SetPosition(1, norGateInB.transform.position);

					sAndOut_OrInA = false;
					sAndOut_OrInB = false;
					sAndOut_NorInA = false;
					sAndOut_NorInB = true;


				}

			}
		}

		else
		{

			orOutLine.enabled = false;
			norOutLine.enabled = false;
			andOutLine.enabled = false;

			goOrBulb.SetActive(false);
			goAndBulb.SetActive(false);
			goNorBulb.SetActive(false);





		}


		if (checkInputOrConnection().Equals(true))
		{
			txtOrOutput_current.text = orGateFunction().ToString();
		}
		if (checkInputAndConnection().Equals(true))
		{
			txtAndOutput_current.text = andGateFunction().ToString();
		}
		if (checkInputNorConnection().Equals(true))
		{
			txtNorOutput_current.text = norGateFunction().ToString();
		}

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
		if ((norGateCombineFunction() == 1 && GMS.questionNumber == 2) || (orGateCombineFunction() == 1 && GMS.questionNumber == 3)
			|| (andGateCombineFunction() == 1 && GMS.questionNumber == 4))
		{


			soundPlay.soundCorrectNow();
			StartCoroutine(correctAnswer());
			StartCoroutine(nextQuest());



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

		if (GMS.questionNumber == 1)
		{

			GMS.round2 = true;

		}

		if (GMS.questionNumber == 2)
		{
			GMS.round3 = true;

		}
		if (GMS.questionNumber == 3)
		{

			GMS.round4 = true;
		}
		if (GMS.questionNumber == 4)
		{

			GMS.roundComplete = true;
			TimeSpan ts = GMS.stopWatch.Elapsed;
			GMS.stopWatch.Stop();
			showTime.text = "Your Time:\n" + ts.ToString();


		}
		//questionNumber++;
		GMS.questionNumber++;
		yield break;
	}

	public IEnumerator nextQuest()
	{

		yield return new WaitForSeconds(1.5f);
		questionNumber++;
		yield break;
	}

	public IEnumerator wrongAnswer()
	{


		soundPlay.showWrongText();
		yield return new WaitForSeconds(1.5f);
		soundPlay.hideWrongText();
		yield break;
	}

	void RenderLine(LineRenderer line, GameObject point1, GameObject point2)
	{


		line.SetPosition(0, point1.transform.position);
		line.SetPosition(1, point2.transform.position);

	}

	bool checkInputOrConnection()
	{


		if ((sAndOut_OrInA == true && sNorOut_OrInB == true) || (sAndOut_OrInB == true && sNorOut_OrInA == true))
		{

			orOutLine.enabled = false;
			btnOrInputA.SetActive(false);
			btnOrInputB.SetActive(false);

			goOrBulb.SetActive(true);

			txtOrOutput_current.text = orGateCombineFunction().ToString();


			return false;
		}
		else
		{
			btnOrInputA.SetActive(true);
			btnOrInputB.SetActive(true);

			goOrBulb.SetActive(false);
			return true;
		}



	}

	bool checkInputAndConnection()
	{

		if ((sNorOut_AndInA == true && sOrOut_AndInB == true) || (sNorOut_AndInB == true && sOrOut_AndInA == true))
		{
			andOutLine.enabled = false;

			btnAndInputA.SetActive(false);
			btnAndInputB.SetActive(false);

			goAndBulb.SetActive(true);

			txtAndOutput_current.text = andGateCombineFunction().ToString();
			return false;

		}
		else
		{
			btnAndInputA.SetActive(true);
			btnAndInputB.SetActive(true);

			goAndBulb.SetActive(false);
			return true;
		}
	}


	bool checkInputNorConnection()
	{

		if ((sOrOut_NorInA == true && sAndOut_NorInB == true) || (sOrOut_NorInB == true && sAndOut_NorInA == true))
		{
			norOutLine.enabled = false;

			btnNorInputA.SetActive(false);
			btnNorInputB.SetActive(false);

			goNorBulb.SetActive(true);

			txtNorOutput_current.text = norGateCombineFunction().ToString();



			return false;

		}

		else
		{

			btnNorInputA.SetActive(true);
			btnNorInputB.SetActive(true);
			goNorBulb.SetActive(false);
			return true;
		}
	}


	int orGateCombineFunction()
	{

		if (andGateFunction() == 1 || norGateFunction() == 1)
		{
			orFireEffect.Play();
			//onBulbLight();
			return 1;
		}
		else
		{
			orFireEffect.Stop();
			//offBulbLight();
			return 0;
		}



	}

	int andGateCombineFunction()
	{

		if (orGateFunction() == 1 && norGateFunction() == 1)
		{
			andFireEffect.Play();
			return 1;
		}
		else
		{
			andFireEffect.Stop();
			return 0;
		}


	}

	int norGateCombineFunction()
	{

		if (orGateFunction() == 0 && andGateFunction() == 0)
		{
			norFireEffect.Play();
			return 1;
		}
		else
		{
			norFireEffect.Stop();
			return 0;
		}
	}


	void TaskOnRetryClick()

	{

		//GMS.round1 = true;
		//GMS.questionNumber = 2;
	}


}

