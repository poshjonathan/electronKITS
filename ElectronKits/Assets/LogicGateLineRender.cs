using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class LogicGateLineRender : MonoBehaviour
{

	private GameObject goNorOutLine, goAndOutLine, goOrOutLine;

	private LineRenderer norOutLine, andOutLine, orOutLine;

	public GameObject norGateOut, norGateInA, norGateInB;
	public GameObject andGateOut, andGateInA, andGateInB;
	public GameObject orGateOut, orGateInA, orGateInB;

	private float distanceNor_Min, distanceOr_Min, distanceAnd_Min;
	private int distanceNor_Index = 1, distanceOr_Index = 1, distanceAnd_Index = 1;

	//Track possibility of different position
	private bool sNorOut_OrInA, sNorOut_OrInB;
	private bool sNorOut_AndInA, sNorOut_AndInB;

	private bool sOrOut_NorInA, sOrOut_NorInB;
	private bool sOrOut_AndInA, sOrOut_AndInB;

	private bool sAndOut_OrInA, sAndOut_OrInB;
	private bool sAndOut_NorInA, sAndOut_NorInB;

	private bool boolOrInA, boolOrInB;
	private bool boolAndInA, boolAndInB;
	private bool boolNorInA, boolNorInB;

	private static bool orTracker = false, andTracker = false, norTracker = false;

	private GameObject goLighting;
	Light bulbLighting;

	public Button increaseBtn, decreaseBtn, playBtn;
	private float resistorValue_Counter;
	public Text showCounterText;

	public Material bulbParticleMaterial, bulbParticleTrailMaterial;
	private int bulbElements, bulbElementsOld;

	private GameObject human;
	private float vector3test;
	private bool playStatus;
	public Text showCurrentPlayStatus;

	private int targetIndex;
	private Vector3[] markers;

	public Button particleTriggerBtn;
	private bool particleTriggerStatus = false;
	public Text showParticleTriggerStatus;
	public Sprite playSprite;
	public Sprite pauseSprite;

	public Button increaseVoltsBtn, decreaseVoltsBtn;
	private float batteryVoltsValue = 3f;
	public Text showBatteryVolts;
	private int batteryElement = 3;
	private int batteryElementOld;

	private float step = 0f;

	public Text showResistanceValue, showVoltageValue, showCurrentValue;

	private float currentValue;

	//public ParticleSystem explosionEffect;

	//public TextMesh humanCurrentValue;

	//public Text overcurrentText;
	//public GameObject lineObject = new GameObject("Line");

	public GameObject explainPanel;

	public AudioSource overcurrentSpeech;


	private GameObject goOrBulb, goAndBulb, goNorBulb;

	private static int orInputA_State, orInputB_State;
	private static int andInputA_State, andInputB_State;
	private static int norInputA_State, norInputB_State;

	private GameObject btnOrInputA, btnOrInputB;
	private GameObject btnAndInputA, btnAndInputB;
	private GameObject btnNorInputA, btnNorInputB;

	public TextMesh txtOrOutput_current, txtAndOutput_current, txtNorOutput_current;

	public ParticleSystem orFireEffect,andFireEffect,norFireEffect;



	// Use this for initialization
	void Start()
	{

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



		//goLighting = GameObject.Find("orBulbLight");
		//bulbLighting = goLighting.AddComponent<Light>();

		/*
		 * 
		 * 
         *
		BatteryResistorline = GameObject.Find("BatteryResistor");
BattRline = BatteryResistorline.AddComponent<LineRenderer>();
		BattRline.enabled = false;
		
		BattRline.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		BattRline.startColor = Color.cyan;
		BattRline.endColor = Color.blue;
		BattRline.startWidth = 0.25f;
		BattRline.endWidth = 0.25f;

		goLighting = GameObject.Find("goLighting");
		bulbLighting = goLighting.AddComponent<Light>();

		//increaseBtn = GameObject.FindGameObjectWithTag("IncreaseButton").GetComponent<Button>();
		resistorValue_Counter = 10f;
		bulbElements = 3;


		//Human
		human = GameObject.Find("common_people@run");
		//human.transform.position = resistorRightSphere.transform.position;

		//Show play button (initialise)
		particleTriggerBtn.image.sprite = playSprite;

		//Show pause button (initialise)
		playBtn.image.sprite = playSprite;

		explainPanel.SetActive(false);

		if (overcurrentSpeech.isPlaying)
		{
			overcurrentSpeech.Stop();
		}


		//Click listener
		increaseBtn.onClick.AddListener(TaskOnIncreaseClick);
		decreaseBtn.onClick.AddListener(TaskOnDecreaseClick);
		playBtn.onClick.AddListener(TaskOnPlayClick);
		particleTriggerBtn.onClick.AddListener(TaskOnParticleTriggerPlayClick);
		increaseVoltsBtn.onClick.AddListener(TaskOnIncreaseVoltsClick);
		decreaseVoltsBtn.onClick.AddListener(TaskOnDecreaseVoltsClick);
*/

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

					boolOrInA = true;
					boolOrInB = false;
					boolAndInA = false;
					boolAndInB = false;


				}
				if (distanceNor_Index == 2)
				{
					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, orGateInB.transform.position);

					sNorOut_OrInA = false;
					sNorOut_OrInB = true;
					sNorOut_AndInA = false;
					sNorOut_AndInB = false;

					boolOrInA = false;
					boolOrInB = true;
					boolAndInA = false;
					boolAndInB = false;



				}
				if (distanceNor_Index == 3)
				{
					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, andGateInA.transform.position);

					sNorOut_OrInA = false;
					sNorOut_OrInB = false;
					sNorOut_AndInA = true;
					sNorOut_AndInB = false;

					boolOrInA = false;
					boolOrInB = false;
					boolAndInA = true;
					boolAndInB = false;


				}
				if (distanceNor_Index == 4)
				{
					norOutLine.SetPosition(0, norGateOut.transform.position);
					norOutLine.SetPosition(1, andGateInB.transform.position);

					sNorOut_OrInA = false;
					sNorOut_OrInB = false;
					sNorOut_AndInA = false;
					sNorOut_AndInB = true;

					boolOrInA = false;
					boolOrInB = false;
					boolAndInA = false;
					boolAndInB = true;
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

		//}
		/*

		if (resistorTracker == false || batteryTracker == false || bulbTracker == false)
		{

			if (resistorTracker == false || bulbTracker == false)
			{
				BRline.enabled = false;
			}

			if (bulbTracker == false || batteryTracker == false)
			{
				BBattline.enabled = false;
			}

			if (batteryTracker == false || resistorTracker == false)
			{
				BattRline.enabled = false;
			}

			sBulbLeft_ResistorLeft = false;
			sBulbLeft_ResistorRight = false;
			sBulbRight_ResistorRight = false;
			sBulbRight_ResistorLeft = false;

			sBulbLeft_BatteryLeft = false;
			sBulbLeft_BatteryRight = false;
			sBulbRight_BatteryRight = false;
			sBulbRight_BatteryLeft = false;

			sBatteryLeft_ResistorLeft = false;
			sBatteryLeft_ResistorRight = false;
			sBatteryRight_ResistorRight = false;
			sBatteryRight_ResistorLeft = false;

		}


		//Handle siuation when the circuit is complete
		if ((sBulbRight_BatteryLeft == true && sBatteryRight_ResistorRight == true && sBulbLeft_ResistorLeft == true) ||
			(sBulbLeft_BatteryLeft == true && sBatteryRight_ResistorRight == true && sBulbRight_ResistorLeft == true) ||
			(sBulbRight_BatteryRight == true && sBatteryLeft_ResistorRight == true && sBulbLeft_ResistorLeft == true) ||
			(sBulbRight_BatteryLeft == true && sBatteryRight_ResistorLeft == true && sBulbLeft_ResistorRight == true) ||
			(sBulbLeft_BatteryRight == true && sBatteryLeft_ResistorRight == true && sBulbRight_ResistorLeft == true) ||
			(sBulbLeft_BatteryRight == true && sBatteryLeft_ResistorLeft == true && sBulbRight_ResistorRight == true) ||
			(sBulbLeft_BatteryLeft == true && sBatteryRight_ResistorLeft == true && sBulbRight_ResistorRight == true) ||
			(sBulbRight_BatteryRight == true && sBatteryLeft_ResistorLeft == true && sBulbRight_ResistorRight == true) ||
			(sBulbRight_BatteryRight == true && sBatteryLeft_ResistorLeft == true && sBulbLeft_ResistorRight == true))
		{

			var particleMain = bulbParticle.main;
			particleMain.duration = 7;
			particleMain.loop = true;
			particleMain.startLifetime = new ParticleSystem.MinMaxCurve(2f, 7f);
			particleMain.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.5f);
			particleMain.maxParticles = (bulbElements + batteryElement) * 40;
			particleMain.simulationSpeed = (bulbElements + batteryElement);

			if (resistorValue_Counter.Equals(0))
			{
				bulbLighting.enabled = false;

			}
			else
			{
				bulbLighting.enabled = true;
				bulbLighting.type = LightType.Point;
				bulbLighting.intensity = (bulbElements + batteryElement) * 1.2f;
				bulbLighting.range = 200f;
				bulbLighting.shadows = LightShadows.Hard;

			}

			playBtn.interactable = true;

			particleTriggerBtn.interactable = true;

		}

		//Handle situation when the circuit is not complete
		else
		{
			bulbLighting.enabled = false;

			var asdf = bulbParticle.emission;
			asdf.rateOverTime = 0;

			playBtn.interactable = false;
			playStatus = false;
			playBtn.image.sprite = pauseSprite;

			particleTriggerBtn.interactable = false;
			particleTriggerStatus = false;
			particleTriggerBtn.image.sprite = pauseSprite;

		}

		//Human Walking
		markers = new Vector3[6];
		markers[0] = batteryLeftSphere.transform.position;



		//Bulb at left of Battery (Normal)
		if (sBulbRight_BatteryLeft == true)
		{
			markers[1] = bulbRightSphere.transform.position;
			markers[2] = bulbLeftSphere.transform.position;

			if (sBulbLeft_ResistorLeft == true)
			{
				markers[3] = resistorLeftSphere.transform.position;
				markers[4] = resistorRightSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;

			}
			else
			{
				markers[3] = resistorRightSphere.transform.position;
				markers[4] = resistorLeftSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;
			}
		}


		//Bulb at left of Battery (Reverse)
		else if (sBulbLeft_BatteryLeft == true)
		{

			markers[1] = bulbLeftSphere.transform.position;
			markers[2] = bulbRightSphere.transform.position;

			if (sNorOut_NandInB == true)
			{
				markers[3] = resistorLeftSphere.transform.position;
				markers[4] = resistorRightSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;

			}
			else
			{
				markers[3] = resistorRightSphere.transform.position;
				markers[4] = resistorLeftSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;
			}



		}
		//Resistor at right of Battery (Normal)
		else if (sBatteryLeft_ResistorRight == true)
		{
			markers[1] = resistorRightSphere.transform.position;
			markers[2] = resistorLeftSphere.transform.position;

			if (sNorOut_OrInA == true)
			{
				markers[3] = bulbLeftSphere.transform.position;
				markers[4] = bulbRightSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;

			}
			else
			{
				markers[3] = bulbRightSphere.transform.position;
				markers[4] = bulbLeftSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;
			}

		}

		//Resistor at right of Battery (Reverse)
		else if (sBatteryLeft_ResistorLeft == true)
		{
			markers[1] = resistorLeftSphere.transform.position;
			markers[2] = resistorRightSphere.transform.position;

			if (sNorOut_OrInB == true)
			{
				markers[3] = bulbLeftSphere.transform.position;
				markers[4] = bulbRightSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;

			}
			else
			{
				markers[3] = bulbRightSphere.transform.position;
				markers[4] = bulbLeftSphere.transform.position;
				markers[5] = batteryRightSphere.transform.position;
			}

		}
		else
		{
			for (int i = 1; i <= 5; i++)
			{
				markers[i] = batteryLeftSphere.transform.position;
			}
		}


		if (playStatus == false || resistorTracker == false || batteryTracker == false || bulbTracker == false || bulbLighting.enabled == false)
		{
			for (int i = 1; i <= 5; i++)
			{
				markers[i] = batteryLeftSphere.transform.position;
			}

			targetIndex = 0;

			human.transform.position = Vector3.MoveTowards(human.transform.position, markers[0], 0.3f);
			human.GetComponent<Animation>().Stop();

			playBtn.image.sprite = playSprite;
			showCurrentPlayStatus.text = "OFF";


		}
		if (playStatus == true)
		{

			human.GetComponent<Animation>().Play();
			showCurrentPlayStatus.text = "ON";
			/*
			if (batteryElementOld != batteryElement)
			{
				batteryElementOld = batteryElement;
				float speedBattery = batteryElement * 2f;
				step = speedBattery * Time.deltaTime;
			}

			if (bulbElementsOld != bulbElements)
			{
				bulbElementsOld = bulbElements;
				float speedResistor = batteryElement * 2f;
				step = speedResistor * Time.deltaTime;
			}

			float speed = (batteryElement + bulbElements) * 2f;
			step = speed * Time.deltaTime;


			human.transform.position = Vector3.MoveTowards(human.transform.position, markers[targetIndex], step);
			human.transform.LookAt(markers[targetIndex]);
			if (human.transform.position == markers[targetIndex])
			{
				targetIndex++;
			}
			if (targetIndex == markers.Length)
			{
				targetIndex = 0;
			}

			playBtn.image.sprite = pauseSprite;
		}


		//Particle trigger button
		if (particleTriggerStatus == true)
		{

			//Start particle animation

			var asdf = bulbParticle.emission;
			asdf.rateOverTime = bulbElements * 40;
			showParticleTriggerStatus.text = "ON";

			particleTriggerBtn.image.sprite = pauseSprite;

		}

		if (particleTriggerStatus == false)
		{

			var asdf = bulbParticle.emission;
			asdf.rateOverTime = 0;
			showParticleTriggerStatus.text = "OFF";

			particleTriggerBtn.image.sprite = playSprite;
		}
		if (resistorValue_Counter > 0)
		{
			overcurrentText.text = "";

		}

		//updateAllValues();
		//calucalateCurrent();


*/

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

	}

	void RenderLine(LineRenderer line, GameObject point1, GameObject point2)
	{


		line.SetPosition(0, point1.transform.position);
		line.SetPosition(1, point2.transform.position);


	}
	/*

	void TaskOnIncreaseClick()
	{
		explainPanel.SetActive(false);
		resistorValue_Counter = resistorValue_Counter + 5;
		bulbElements--;

		if (resistorValue_Counter >= 20)
		{
			resistorValue_Counter = 20;
			bulbElements = 1;

			//disable increasebutton here
			increaseBtn.interactable = false;
		}


		else
		{
			decreaseBtn.interactable = true;
		}




	}




	void TaskOnDecreaseClick()
	{

		resistorValue_Counter = resistorValue_Counter - 5;
		bulbElements++;

		if (resistorValue_Counter <= 0)
		{
			overcurrentSpeech.Play();

			resistorValue_Counter = 0;
			bulbElements = 5;

			//disable increasebutton here
			decreaseBtn.interactable = false;

			showExplosion();
			StartCoroutine(overcurrentFlash());


		}

		else
		{
			increaseBtn.interactable = true;
		}

	}

	void TaskOnPlayClick()
	{
		playStatus = !playStatus;

	}


	void TaskOnParticleTriggerPlayClick()
	{
		particleTriggerStatus = !particleTriggerStatus;

	}

	void TaskOnIncreaseVoltsClick()
	{
		batteryVoltsValue = batteryVoltsValue + 1.5f;
		batteryElement++;

		if (batteryVoltsValue >= 6)
		{
			batteryElement = 5;
			batteryVoltsValue = 6;
			increaseVoltsBtn.interactable = false;

		}
		else
		{
			decreaseVoltsBtn.interactable = true;
		}

	}

	void TaskOnDecreaseVoltsClick()
	{
		batteryVoltsValue = batteryVoltsValue - 1.5f;
		batteryElement--;

		if (batteryVoltsValue <= 0)
		{
			batteryElement = 0;
			batteryVoltsValue = 0;
			decreaseVoltsBtn.interactable = false;
		}
		else
		{
			increaseVoltsBtn.interactable = true;

		}
	}

	void updateAllValues()
	{

		showVoltageValue.text = batteryVoltsValue.ToString() + "V";
		showResistanceValue.text = resistorValue_Counter.ToString() + "k";
		showCurrentValue.text = currentValue.ToString() + "A";
		showCounterText.text = resistorValue_Counter.ToString() + "k";
		showBatteryVolts.text = batteryVoltsValue.ToString() + "v";
		humanCurrentValue.text = currentValue.ToString() + "A";

	}

	void calucalateCurrent()
	{

		currentValue = batteryVoltsValue / resistorValue_Counter;

	}

	IEnumerator ExecuteAfterTime_explosion(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay

		explosionEffect.Stop();
	}

	void showExplosion()
	{

		explosionEffect.Play();

		//Set Delay
		StartCoroutine(ExecuteAfterTime_explosion(3f));

	}


	public IEnumerator overcurrentFlash()
	{
		if (resistorValue_Counter.Equals(0))
		{
			explainPanel.SetActive(true);
			overcurrentText.text = "O V E R C U R R E N T";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "O V E R C U R R E N T";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "O V E R C U R R E N T";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "O V E R C U R R E N T";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "O V E R C U R R E N T";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "";
			yield return new WaitForSeconds(0.4f);
			overcurrentText.text = "O V E R C U R R E N T";
			yield break;
		}

	}
	*/

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

	void onBulbLight()
	{


		bulbLighting.enabled = true;
				bulbLighting.type = LightType.Point;
				bulbLighting.intensity = 1.2f;
				bulbLighting.range = 200f;
				bulbLighting.shadows = LightShadows.Hard;

	}

	void offBulbLight()
{


		bulbLighting.enabled = false;

	}


}

