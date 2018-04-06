using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class displayAboutText : MonoBehaviour
{
	public Button nextBtn, backBtn;
	public int paraIndex;
	public Text aboutText,pageCount;

	// Use this for initialization
	void Start()
	{

		paraIndex = 1;
		nextBtn.onClick.AddListener(TaskOnNextClick);
		backBtn.onClick.AddListener(TaskOnBackClick);

		paragraphStorage();
		backBtn.interactable = false;

	}

	// Update is called once per frame
	void Update()
	{
		paragraphStorage();

		pageCount.text = paraIndex + " /4";
			
	}

	public void paragraphStorage()
	{
		if (paraIndex == 1)
		{
			aboutText.text = "<i><b>electronKits</b></i> is a free edutainment (educational + entertainment) application which covers electrical and electronic engineering topics.";
		
		}

		if (paraIndex == 2)
		{
			aboutText.text = "<i><b>electronKits</b></i> uses interactive and intuitive methods to educate primary and secondary school students about topics such as the functionality of a resistor, connecting an electrical circuit, digital electronics, etc.";
				
		}

		if (paraIndex == 3)
		{

			aboutText.text = "<i><b>electronKits</b></i> is developed by Jonathan Poh, presented to Nanyang Technological University (NTU), School of Electrical Electronic " +
				"Engineering (EEE).";

		}
			if (paraIndex == 4)
		{

			aboutText.text = "For feedback and suggestions, please contact Jonathan Poh at e150119@e.ntu.edu.sg";

		}

	}




	void TaskOnNextClick()
	{

		paraIndex++;
		backBtn.interactable = true;
		if (paraIndex == 4)
		{
			nextBtn.interactable = false;

		}

	}

	void TaskOnBackClick()
	{

		paraIndex--;
		nextBtn.interactable = true;
		if (paraIndex == 1)
		{
			backBtn.interactable = false;

		}
	}

}
