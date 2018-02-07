using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortestLineScript : MonoBehaviour {

	public GameObject BulbResistorline1;
	public GameObject BulbResistorline2;
	public GameObject BulbResistorline3;
	public GameObject BulbResistorline4;

	public GameObject BulbBatteryline1;
	public GameObject BulbBatteryline2;
	public GameObject BulbBatteryline3;
	public GameObject BulbBatteryline4;

	public static int BulbResistorIndex;
	public static int BulbBatteryIndex;

	// Use this for initialization
	void Start () {
		
		BulbResistorline1.GetComponent<Renderer>().enabled = false;
		BulbResistorline2.GetComponent<Renderer>().enabled = false;
		BulbResistorline3.GetComponent<Renderer>().enabled = false;
		BulbResistorline4.GetComponent<Renderer>().enabled = false;

		BulbBatteryline1.GetComponent<Renderer>().enabled = false;
		BulbBatteryline2.GetComponent<Renderer>().enabled = false;
		BulbBatteryline3.GetComponent<Renderer>().enabled = false;
		BulbBatteryline4.GetComponent<Renderer>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		BulbResistorIndex = DistanceCalculator.distanceBulbResistor_Index;

		if(BulbResistorIndex==1)
		{
			BulbResistorline1.GetComponent<Renderer>().enabled = true;

			BulbResistorline2.GetComponent<Renderer>().enabled = false;
			BulbResistorline3.GetComponent<Renderer>().enabled = false;
			BulbResistorline4.GetComponent<Renderer>().enabled = false;
		}
			if(BulbResistorIndex==2)
		{
			BulbResistorline2.GetComponent<Renderer>().enabled = true;

			BulbResistorline1.GetComponent<Renderer>().enabled = false;
			BulbResistorline3.GetComponent<Renderer>().enabled = false;
			BulbResistorline4.GetComponent<Renderer>().enabled = false;
		}
			if(BulbResistorIndex==3)
		{
			BulbResistorline3.GetComponent<Renderer>().enabled = true;

			BulbResistorline1.GetComponent<Renderer>().enabled = false;
			BulbResistorline2.GetComponent<Renderer>().enabled = false;
			BulbResistorline4.GetComponent<Renderer>().enabled = false;
		}
			if(BulbResistorIndex==4)
		{
			BulbResistorline4.GetComponent<Renderer>().enabled = true;

			BulbResistorline1.GetComponent<Renderer>().enabled = false;
			BulbResistorline2.GetComponent<Renderer>().enabled = false;
			BulbResistorline3.GetComponent<Renderer>().enabled = false;
		}


		BulbBatteryIndex = DistanceCalculator.distanceBulbResistor_Index;

		if(BulbBatteryIndex==1)
		{
			BulbBatteryline1.GetComponent<Renderer>().enabled = true;

			BulbBatteryline2.GetComponent<Renderer>().enabled = false;
			BulbBatteryline3.GetComponent<Renderer>().enabled = false;
			BulbBatteryline4.GetComponent<Renderer>().enabled = false;
		}
			if(BulbBatteryIndex==2)
		{
			BulbBatteryline2.GetComponent<Renderer>().enabled = true;

			BulbBatteryline1.GetComponent<Renderer>().enabled = false;
			BulbBatteryline3.GetComponent<Renderer>().enabled = false;
			BulbBatteryline4.GetComponent<Renderer>().enabled = false;
		}
			if(BulbBatteryIndex==3)
		{
			BulbBatteryline3.GetComponent<Renderer>().enabled = true;

			BulbBatteryline1.GetComponent<Renderer>().enabled = false;
			BulbBatteryline2.GetComponent<Renderer>().enabled = false;
			BulbBatteryline4.GetComponent<Renderer>().enabled = false;
		}
			if(BulbBatteryIndex==4)
		{
			BulbBatteryline4.GetComponent<Renderer>().enabled = true;

			BulbBatteryline1.GetComponent<Renderer>().enabled = false;
			BulbBatteryline2.GetComponent<Renderer>().enabled = false;
			BulbBatteryline3.GetComponent<Renderer>().enabled = false;
		}

	}

	
}
