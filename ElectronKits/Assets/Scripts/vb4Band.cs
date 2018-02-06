using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb4Band : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject vb4BandChart,Resistor4BandChart;
	private int counter1;
	public TextMesh textext12;
	bool currentstate = false;

	public static bool colorChartTracker = false;

	// Use this for initialization
	void Start () {
		vb4BandChart = GameObject.Find("vbColor_4Band");
		Resistor4BandChart = GameObject.Find("Resistor4BandChart");
		vb4BandChart.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
		
	}

	void Update()
	{
		colorChartTracker = customCardChartTracker.colorChartTracker;
		if (colorChartTracker == true)
		{
			if (currentstate == false)
			{
				Resistor4BandChart.GetComponent<Renderer>().enabled = false;
			}
			else
			{
				Resistor4BandChart.GetComponent<Renderer>().enabled = true;
			}
		}
		else
		{
			Resistor4BandChart.GetComponent<Renderer>().enabled = false;
		}
	}


	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		counter1++;
		textext12.text = counter1.ToString();
		currentstate = !currentstate;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{

	}

}
