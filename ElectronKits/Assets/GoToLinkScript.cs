using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLinkScript : MonoBehaviour {
	public GameObject urlLinkBtn;

	// Use this for initialization
	void Start () {
		
	}
	


	void OnMouseDown()
	{

		    Application.OpenURL("https://bit.ly/2GDckUd");

	}
}
