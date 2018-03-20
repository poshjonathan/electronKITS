using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOpenPanel : MonoBehaviour
{

	public GameObject openPanel;
	// Use this for initialization
	void Start()
	{
		//openPanel.SetActive(false);
	}


	void OnMouseDown()
	{

		openPanel.SetActive(true);

	}
}
