using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class helpScript : MonoBehaviour {

public Button helpBtn, closHelpBtn;
public GameObject goIntructions;

	// Use this for initialization
	void Start () {

		goIntructions.SetActive(false);

		helpBtn.onClick.AddListener(TaskOnHelpClick);
		closHelpBtn.onClick.AddListener(TaskOnCloseHelpClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

void TaskOnCloseHelpClick()
{

	goIntructions.SetActive(false);
}

void TaskOnHelpClick()
{

	goIntructions.SetActive(true);
}

}
