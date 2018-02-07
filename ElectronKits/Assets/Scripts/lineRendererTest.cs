using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class lineRendererTest : MonoBehaviour {

	private GameObject BulbResistorline,BulbBatteryline,BatteryResistorline;

	private LineRenderer BRline,BBattline,BattRline;

	public GameObject batteryRightSphere, batteryLeftSphere;
	public GameObject resistorRightSphere, resistorLeftSphere;
	public GameObject bulbRightSphere, bulbLeftSphere;

	private float distanceBulbResistor_Min, distanceBulbBattery_Min, distanceBatteryResistor_Min;
	private int distanceBulbResistor_Index = 1, distanceBulbBattery_Index = 1, distanceBatteryResistor_Index = 1;

	//Track possibility of different position
	private bool sBulbLeft_ResistorLeft, sBulbLeft_ResistorRight;
	private bool sBulbRight_ResistorRight, sBulbRight_ResistorLeft;

	private bool sBulbLeft_BatteryLeft, sBulbLeft_BatteryRight;
	private bool sBulbRight_BatteryRight, sBulbRight_BatteryLeft;

	private bool sBatteryLeft_ResistorLeft, sBatteryLeft_ResistorRight;
	private bool sBatteryRight_ResistorRight, sBatteryRight_ResistorLeft;

	public static bool resistorTracker = false, batteryTracker = false, bulbTracker = false;

	private GameObject goLighting;
	Light bulbLighting;

	public Button increaseBtn, decreaseBtn,playBtn;
	public int resistorValue_Counter;
	public Text showCounterText;

	public GameObject goParticle;
	public ParticleSystem bulbParticle;
	public Material bulbParticleMaterial,bulbParticleTrailMaterial;
	public int bulbElements;

	private GameObject human;
	private float vector3test;
	private bool playStatus;

	private int targetIndex;
	private Vector3[] markers;

	//public GameObject lineObject = new GameObject("Line");

	// Use this for initialization
	void Start()
	{

		BulbResistorline = GameObject.Find("BulbResistor");
		BRline = BulbResistorline.AddComponent<LineRenderer>();
		BRline.enabled = false;

		BulbBatteryline = GameObject.Find("BulbBattery");
		BBattline = BulbBatteryline.AddComponent<LineRenderer>();
		BBattline.enabled = false;

		BatteryResistorline = GameObject.Find("BatteryResistor");
		BattRline = BatteryResistorline.AddComponent<LineRenderer>();
		BattRline.enabled = false;

		BRline.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		BRline.startColor = Color.cyan;
		BRline.endColor = Color.blue;
		BRline.startWidth = 0.25f;
		BRline.endWidth = 0.25f;

		BBattline.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		BBattline.startColor = Color.cyan;
		BBattline.endColor = Color.blue;
		BBattline.startWidth = 0.25f;
		BBattline.endWidth = 0.25f;

		BattRline.material = new Material(Shader.Find("Particles/Additive")); //Need this to set color
		BattRline.startColor = Color.cyan;
		BattRline.endColor = Color.blue;
		BattRline.startWidth = 0.25f;
		BattRline.endWidth = 0.25f;

		goLighting = GameObject.Find("goLighting");
		bulbLighting = goLighting.AddComponent<Light>();

		//increaseBtn = GameObject.FindGameObjectWithTag("IncreaseButton").GetComponent<Button>();
		resistorValue_Counter = 10;
		bulbElements = 3;

		increaseBtn.onClick.AddListener(TaskOnIncreaseClick);
		decreaseBtn.onClick.AddListener(TaskOnDecreaseClick);
		playBtn.onClick.AddListener(TaskOnPlayClick);


		//Particle System
		goParticle = GameObject.Find("ParticleSystemObj");
		bulbParticle = goParticle.AddComponent<ParticleSystem>();

		var main = bulbParticle.main;
		main.playOnAwake = false;
		main.startColor = Color.yellow;
		main.maxParticles = 1000;

		var particleTransform = bulbParticle.transform;
		particleTransform.Rotate(-90, 0, 0);

		var particleShape = bulbParticle.shape;
		particleShape.shapeType = ParticleSystemShapeType.Sphere;

		var particleColorLifetime = bulbParticle.colorOverLifetime;
		particleColorLifetime.enabled = true;
		Gradient grad = new Gradient();
		grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.yellow, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.5f), new GradientAlphaKey(0.0f, 1.0f) });
		particleColorLifetime.color = grad;

		bulbParticle.GetComponent<ParticleSystemRenderer>().material = bulbParticleMaterial;

		/*
		var particleTrail = bulbParticle.trails;
		particleTrail.ratio = 1;
		particleTrail.lifetime = 1;
		particleTrail.minVertexDistance = 0.6f;
		particleTrail.textureMode = ParticleSystemTrailTextureMode.Stretch;
		particleTrail.dieWithParticles = true;
		particleTrail.sizeAffectsWidth = true;
		particleTrail.widthOverTrail = 0.12f;
		//particleTrail.colorOverTrail = grad;
		bulbParticle.GetComponent<ParticleSystemRenderer>().trailMaterial= bulbParticleTrailMaterial;
		particleTrail.enabled = true;
		*/

		var asdf = bulbParticle.emission;
		asdf.rateOverTime = 100;

		//Human
		human = GameObject.Find("common_people@run");
		//human.transform.position = resistorRightSphere.transform.position;

	}

	// Update is called once per frame
	void Update()
	{

		resistorTracker = customSmallResistorTrackerScript.smallResistor;
		bulbTracker = customSmallBulbTrackerScript.smallBulb;
		batteryTracker = customSmallBatteryTrackerScript.smallBattery;

		if (bulbTracker == true && resistorTracker == true)
		{
			BRline.enabled = true;

			//Bulb and Resistor-----------------------------------------------------
			float distanceBulbResistor1 = Vector3.Distance(bulbLeftSphere.transform.position, resistorLeftSphere.transform.position);
			float distanceBulbResistor2 = Vector3.Distance(bulbLeftSphere.transform.position, resistorRightSphere.transform.position);
			float distanceBulbResistor3 = Vector3.Distance(bulbRightSphere.transform.position, resistorRightSphere.transform.position);
			float distanceBulbResistor4 = Vector3.Distance(bulbRightSphere.transform.position, resistorLeftSphere.transform.position);


			float[] distanceBulbResistor = new float[] { distanceBulbResistor1, distanceBulbResistor2, distanceBulbResistor3, distanceBulbResistor4 };

			distanceBulbResistor_Min = distanceBulbResistor[0];
			distanceBulbResistor_Index = 1;

			for (int i = 0; i <= 3; i++)
			{
				if (distanceBulbResistor[i] < distanceBulbResistor_Min)
				{
					distanceBulbResistor_Min = distanceBulbResistor[i];
					distanceBulbResistor_Index = (i + 1);
				}

			}

			if (distanceBulbResistor_Index == 1)
			{

				BRline.SetPosition(0, bulbLeftSphere.transform.position);
				BRline.SetPosition(1, resistorLeftSphere.transform.position);

				sBulbLeft_ResistorLeft = true;
				sBulbLeft_ResistorRight = false;
				sBulbRight_ResistorRight = false;
				sBulbRight_ResistorLeft = false;

			}
			if (distanceBulbResistor_Index == 2)
			{
				BRline.SetPosition(0, bulbLeftSphere.transform.position);
				BRline.SetPosition(1, resistorRightSphere.transform.position);

				sBulbLeft_ResistorLeft = false;
				sBulbLeft_ResistorRight = true;
				sBulbRight_ResistorRight = false;
				sBulbRight_ResistorLeft = false;



			}
			if (distanceBulbResistor_Index == 3)
			{
				BRline.SetPosition(0, bulbRightSphere.transform.position);
				BRline.SetPosition(1, resistorRightSphere.transform.position);

				sBulbLeft_ResistorLeft = false;
				sBulbLeft_ResistorRight = false;
				sBulbRight_ResistorRight = true;
				sBulbRight_ResistorLeft = false;


			}
			if (distanceBulbResistor_Index == 4)
			{
				BRline.SetPosition(0, bulbRightSphere.transform.position);
				BRline.SetPosition(1, resistorLeftSphere.transform.position);

				sBulbLeft_ResistorLeft = false;
				sBulbLeft_ResistorRight = false;
				sBulbRight_ResistorRight = false;
				sBulbRight_ResistorLeft = true;


			}

		}


		if (bulbTracker == true && batteryTracker == true)
		{
			BBattline.enabled = true;

			//Bulb and Battery-----------------------------------------------------
			float distanceBulbBattery1 = Vector3.Distance(bulbLeftSphere.transform.position, batteryLeftSphere.transform.position);
			float distanceBulbBattery2 = Vector3.Distance(bulbLeftSphere.transform.position, batteryRightSphere.transform.position);
			float distanceBulbBattery3 = Vector3.Distance(bulbRightSphere.transform.position, batteryRightSphere.transform.position);
			float distanceBulbBattery4 = Vector3.Distance(bulbRightSphere.transform.position, batteryLeftSphere.transform.position);


			float[] distanceBulbBattery = new float[] { distanceBulbBattery1, distanceBulbBattery2, distanceBulbBattery3, distanceBulbBattery4 };

			distanceBulbBattery_Min = distanceBulbBattery[0];
			distanceBulbBattery_Index = 1;

			for (int i = 0; i < 4; i++)
			{
				if (distanceBulbBattery[i] < distanceBulbBattery_Min)
				{
					distanceBulbBattery_Min = distanceBulbBattery[i];
					distanceBulbBattery_Index = (i + 1);
				}

			}

			if (distanceBulbBattery_Index == 1)
			{
				BBattline.SetPosition(0, bulbLeftSphere.transform.position);
				BBattline.SetPosition(1, batteryLeftSphere.transform.position);

				sBulbLeft_BatteryLeft = true;
				sBulbLeft_BatteryRight = false;
				sBulbRight_BatteryRight = false;
				sBulbRight_BatteryLeft = false;


			}
			if (distanceBulbBattery_Index == 2)
			{
				BBattline.SetPosition(0, bulbLeftSphere.transform.position);
				BBattline.SetPosition(1, batteryRightSphere.transform.position);

				sBulbLeft_BatteryLeft = false;
				sBulbLeft_BatteryRight = true;
				sBulbRight_BatteryRight = false;
				sBulbRight_BatteryLeft = false;

			}
			if (distanceBulbBattery_Index == 3)
			{
				BBattline.SetPosition(0, bulbRightSphere.transform.position);
				BBattline.SetPosition(1, batteryRightSphere.transform.position);

				sBulbLeft_BatteryLeft = false;
				sBulbLeft_BatteryRight = false;
				sBulbRight_BatteryRight = true;
				sBulbRight_BatteryLeft = false;
			}
			if (distanceBulbBattery_Index == 4)
			{
				BBattline.SetPosition(0, bulbRightSphere.transform.position);
				BBattline.SetPosition(1, batteryLeftSphere.transform.position);

				sBulbLeft_BatteryLeft = false;
				sBulbLeft_BatteryRight = false;
				sBulbRight_BatteryRight = false;
				sBulbRight_BatteryLeft = true;

			}

		}

		if (batteryTracker == true && resistorTracker == true)
		{
			BattRline.enabled = true;

			//Battery and Resistor-----------------------------------------------------
			float distanceBatteryResistor1 = Vector3.Distance(batteryLeftSphere.transform.position, resistorLeftSphere.transform.position);
			float distanceBatteryResistor2 = Vector3.Distance(batteryLeftSphere.transform.position, resistorRightSphere.transform.position);
			float distanceBatteryResistor3 = Vector3.Distance(batteryRightSphere.transform.position, resistorRightSphere.transform.position);
			float distanceBatteryResistor4 = Vector3.Distance(batteryRightSphere.transform.position, resistorLeftSphere.transform.position);

			float[] distanceBatteryResistor = new float[] { distanceBatteryResistor1, distanceBatteryResistor2, distanceBatteryResistor3, distanceBatteryResistor4 };

			distanceBatteryResistor_Min = distanceBatteryResistor[0];
			distanceBatteryResistor_Index = 1;

			for (int i = 0; i < 4; i++)
			{
				if (distanceBatteryResistor[i] < distanceBatteryResistor_Min)
				{
					distanceBatteryResistor_Min = distanceBatteryResistor[i];
					distanceBatteryResistor_Index = (i + 1);
				}

			}

			if (distanceBatteryResistor_Index == 1)
			{
				BattRline.SetPosition(0, batteryLeftSphere.transform.position);
				BattRline.SetPosition(1, resistorLeftSphere.transform.position);

				sBatteryLeft_ResistorLeft = true;
				sBatteryLeft_ResistorRight = false;
				sBatteryRight_ResistorRight = false;
				sBatteryRight_ResistorLeft = false;
			}
			if (distanceBatteryResistor_Index == 2)
			{
				BattRline.SetPosition(0, batteryLeftSphere.transform.position);
				BattRline.SetPosition(1, resistorRightSphere.transform.position);

				sBatteryLeft_ResistorLeft = false;
				sBatteryLeft_ResistorRight = true;
				sBatteryRight_ResistorRight = false;
				sBatteryRight_ResistorLeft = false;
			}
			if (distanceBatteryResistor_Index == 3)
			{
				BattRline.SetPosition(0, batteryRightSphere.transform.position);
				BattRline.SetPosition(1, resistorRightSphere.transform.position);

				sBatteryLeft_ResistorLeft = false;
				sBatteryLeft_ResistorRight = false;
				sBatteryRight_ResistorRight = true;
				sBatteryRight_ResistorLeft = false;

			}
			if (distanceBatteryResistor_Index == 4)
			{
				BattRline.SetPosition(0, batteryRightSphere.transform.position);
				BattRline.SetPosition(1, resistorLeftSphere.transform.position);

				sBatteryLeft_ResistorLeft = false;
				sBatteryLeft_ResistorRight = false;
				sBatteryRight_ResistorRight = false;
				sBatteryRight_ResistorLeft = true;
			}


		}

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
			bulbLighting.enabled = true;
			bulbLighting.type = LightType.Point;
			bulbLighting.intensity = bulbElements * 3;
			bulbLighting.range = 200f;
			bulbLighting.shadows = LightShadows.Hard;

			var particleMain = bulbParticle.main;
			particleMain.duration = 7;
			particleMain.loop = true;
			particleMain.startLifetime = new ParticleSystem.MinMaxCurve(2f, 7f);
			particleMain.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.5f);
			particleMain.maxParticles = bulbElements * 40;
			particleMain.simulationSpeed = bulbElements;

			var asdf = bulbParticle.emission;
			asdf.rateOverTime = bulbElements * 40;

			playBtn.interactable = true;


		}

		else
		{
			bulbLighting.enabled = false;

			var asdf = bulbParticle.emission;
			asdf.rateOverTime = 0;

			playBtn.interactable = false;
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

			if (sBulbRight_ResistorLeft == true)
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

			if (sBulbLeft_ResistorLeft == true)
			{
				markers[3] =bulbLeftSphere.transform.position;
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

			if (sBulbLeft_ResistorRight == true)
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
		}
		if (playStatus == true )
		{
			human.GetComponent<Animation>().Play();

			human.transform.position = Vector3.MoveTowards(human.transform.position, markers[targetIndex], 0.3f);
			human.transform.LookAt(markers[targetIndex]);
			if (human.transform.position == markers[targetIndex])
			{
				targetIndex++;
			}
			if (targetIndex == markers.Length)
			{
				targetIndex = 0;
			}
		}

	}


	void TaskOnIncreaseClick()
	{
		resistorValue_Counter=resistorValue_Counter+5;
		bulbElements--;

		if (bulbElements < 1|| resistorValue_Counter > 20)
		{
			resistorValue_Counter = 20;
			bulbElements = 1;

			//disable increasebutton here
			increaseBtn.interactable = false;
		}
		

		else
		{
			decreaseBtn.interactable = true;
			showCounterText.text = resistorValue_Counter.ToString()+"k"; 
		}


	

	}




	void TaskOnDecreaseClick()
	{

		resistorValue_Counter=resistorValue_Counter-5;
		bulbElements++;

			

		if (resistorValue_Counter <0 || bulbElements >5)
		{ 
			resistorValue_Counter = 0;
			bulbElements = 5;

			//disable increasebutton here
			decreaseBtn.interactable = false;
		}

		else {
			
			increaseBtn.interactable = true;
			showCounterText.text = resistorValue_Counter.ToString()+"k"; 
		}




	}

	void TaskOnPlayClick()
	{
		playStatus = !playStatus;

	}

}
