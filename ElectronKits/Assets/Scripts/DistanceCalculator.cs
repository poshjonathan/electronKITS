/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour {

	public GameObject batteryRightSphere,batteryLeftSphere;
	public GameObject resistorRightSphere, resistorLeftSphere;
	public GameObject bulbRightSphere,bulbLeftSphere;

	public float lineDrawSpeed = 6f;

	public float distanceBulbResistor_Min, distanceBulbBattery_Min;
	public static int distanceBulbResistor_Index = 1, distanceBulbBattery_Index = 1;

	private float counter;

	string gguiText="";
string gguiText2 = "";


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float distanceBulbResistor1 = Vector3.Distance(bulbLeftSphere.transform.position, resistorLeftSphere.transform.position);
		float distanceBulbResistor2 = Vector3.Distance(bulbLeftSphere.transform.position, resistorRightSphere.transform.position);
		float distanceBulbResistor3 = Vector3.Distance(bulbRightSphere.transform.position, resistorRightSphere.transform.position);
		float distanceBulbResistor4 = Vector3.Distance(bulbRightSphere.transform.position, resistorLeftSphere.transform.position);

		float distanceBulbBattery1 = Vector3.Distance(bulbLeftSphere.transform.position, batteryLeftSphere.transform.position);
		float distanceBulbBattery2 = Vector3.Distance(bulbLeftSphere.transform.position, batteryRightSphere.transform.position);
		float distanceBulbBattery3 = Vector3.Distance(bulbRightSphere.transform.position, batteryRightSphere.transform.position);
		float distanceBulbBattery4 = Vector3.Distance(bulbRightSphere.transform.position, batteryLeftSphere.transform.position);

		float distanceBatteryResistor1 = Vector3.Distance(batteryLeftSphere.transform.position, resistorLeftSphere.transform.position);
		float distanceBatteryResistor2 = Vector3.Distance(batteryLeftSphere.transform.position, resistorRightSphere.transform.position);
		float distanceBatteryResistor3 = Vector3.Distance(batteryRightSphere.transform.position, resistorRightSphere.transform.position);	
		float distanceBatteryResistor4 = Vector3.Distance(batteryRightSphere.transform.position, resistorLeftSphere.transform.position);

		//Bulb and Resistor
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

		//Bulb and Battery
		float[] distanceBulbBattery = new float[] { distanceBulbBattery1, distanceBulbBattery2, distanceBulbBattery3, distanceBulbBattery4 };

		distanceBulbBattery_Min = distanceBulbBattery[0];
		distanceBulbBattery_Index = 1;

		for (int i = 0; i< 4; i++)
		{
			if (distanceBulbBattery[i] < distanceBulbBattery_Min)
			{
				distanceBulbBattery_Min = distanceBulbBattery[i];
				distanceBulbBattery_Index = (i + 1);
			}

		}

		gguiText = (distanceBulbResistor_Min / 10).ToString();
		gguiText2 = (distanceBulbBattery_Min / 10).ToString();

		//gguiText = distance.ToString();

		counter += .1f / lineDrawSpeed;

		//float x = Mathf.Lerp(0, distance, counter); 

		//Vector3 pointA = leftSphere.transform.position;
		//Vector3 pointB = rightSphere.transform.position;

		//Vector3 pointAlongLine = x * Vector3.Normalize(pointA - pointB) + pointA;

		//lineRenderer.SetPosition(0, leftSphere.transform.position); // Zero is the start of the line
		//lineRenderer.SetPosition(1, rightSphere.transform.position); // One is the end of the line

	}

	void OnGUI()
	{
		GUIStyle localStyle = new GUIStyle();
		localStyle.normal.textColor = Color.red;
		localStyle.fontSize = 70;
		//GUI.Label(new Rect(20, 50, Screen.width - 10, 30), gguiText + " CM ", localStyle);

		GUI.Label(new Rect(50,40,40,40), gguiText2 + " CM ", localStyle);
	}
}
*/