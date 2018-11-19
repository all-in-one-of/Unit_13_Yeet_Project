using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

	public static DialogManager Instance;
	public Text uiText;
	public Text namePlate;
	public DialogText dialogText;

	//public bool hasTextToDisplay = true;

	private Animator _anims;
	
	
	// Use this for initialization
	void Awake () 
	{
		if (Instance == null)
		{
			Instance = this;
		}

		else
		{
			Destroy(this.gameObject);
		}

		_anims = GetComponent<Animator>();



	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown && dialogText != null)
		{
			DisplayText(dialogText.DQ());
		}

		if (dialogText != null)
		{
			_anims.SetBool("PopBool", dialogText.hasTextToDisplay);
			namePlate.text = dialogText.DialogGiversName;
		}

		
		
	
		
	}

	public void DisplayText(string textToDisplay)
	{
		uiText.text = textToDisplay;
	}

	public void TriggerAnim()
	{
		_anims.SetTrigger("Pop");
	}



}
