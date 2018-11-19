using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{

	[TextArea(10, 10)]
	public string DialogToGive;
	private string[] dialogArray;
	public Queue<string> DialogQ;

	public string DialogGiversName = "";

	public bool hasTextToDisplay = true;

	//public DialogManager dialogManager;
	
	// Use this for initialization
	void Awake ()
	{
		
		ReQueue();
	}
	
	
	

	public string DQ()
	{

		if (DialogQ.Count != 0 && hasTextToDisplay)
		{
			string t = DialogQ.Dequeue();
			return t;
			//DialogManager.Instance.DisplayText(qText);

		}

		hasTextToDisplay = false;
		return "...";


	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			DialogManager.Instance.dialogText = this;
			DialogManager.Instance.TriggerAnim();
			ReQueue();
		}
	}

	private void ReQueue()
	{
		hasTextToDisplay = true;
		DialogQ = new Queue<string>();
		dialogArray = (DialogToGive.Split('\n'));
		foreach (var line in dialogArray)
		{
			DialogQ.Enqueue(line);
		}
	}
}
