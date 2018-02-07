using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingExperiment : MonoBehaviour {

	public GameObject leftSphere;
	public GameObject rightSphere;
	public GameObject oColorSphere;

	public float lineDrawSpeed = 6f;

	private LineRenderer lineRenderer,lineRenderer2;

	private float counter;

	string gguiText="";


	// Use this for initialization
	void Start () {


		lineRenderer = GetComponent<LineRenderer>();

		lineRenderer.startWidth = .45f;
		lineRenderer.endWidth = .45f;






	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(leftSphere.transform.position, rightSphere.transform.position);
		float walid = distance / 10;
		gguiText = walid.ToString();
		//gguiText = distance.ToString();

		counter += .1f / lineDrawSpeed;

		float x = Mathf.Lerp(0, distance, counter); 

		Vector3 pointA = leftSphere.transform.position;
		Vector3 pointB = rightSphere.transform.position;

		Vector3 pointAlongLine = x * Vector3.Normalize(pointA - pointB) + pointA;

		lineRenderer.SetPosition(0, leftSphere.transform.position); // Zero is the start of the line
		lineRenderer.SetPosition(1, rightSphere.transform.position); // One is the end of the line

	}
	/*
	void OnGUI()
	{
		GUIStyle localStyle = new GUIStyle();
		localStyle.normal.textColor = Color.red;
		localStyle.fontSize = 70;
		GUI.Label(new Rect(20, 50, Screen.width - 20, 30), gguiText + " CM ", localStyle);
	}
*/
	
}
