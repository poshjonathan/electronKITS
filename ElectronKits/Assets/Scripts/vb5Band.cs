using UnityEngine;
using Vuforia;

public class vb5Band : MonoBehaviour, IVirtualButtonEventHandler
{

	private GameObject vb5BandChart, Resistor5BandChart;
	private int counter1;
	public TextMesh textext1;
	bool currentstate_5;

	public static bool colorChartTracker = false;

	// Use this for initialization
	void Start()
	{
		vb5BandChart = GameObject.Find("vbColor_5Band");
		Resistor5BandChart = GameObject.Find("Resistor5BandChart");
		vb5BandChart.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}


	// Update is called once per frame
	void Update()
	{

		colorChartTracker = customCardChartTracker.colorChartTracker;

		if (colorChartTracker == true)
		{
			if (currentstate_5 == false)
			{
				Resistor5BandChart.GetComponent<Renderer>().enabled = false;
			}

			else
			{
				Resistor5BandChart.GetComponent<Renderer>().enabled = true;
			}
		}
		else
		{
			Resistor5BandChart.GetComponent<Renderer>().enabled = false;

		}



	}

		public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
		{
			counter1++;
			currentstate_5 = !currentstate_5;//toggle state
			textext1.text = counter1.ToString();

	
		}

		public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
		{
		
		}


}
