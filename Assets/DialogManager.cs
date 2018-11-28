using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	// Singleton pattern implementation
	public static DialogManager Instance;
	
	
	public Text uiText;
	public Text namePlate;
	public DialogText dialogText;

	//public bool hasTextToDisplay = true;

	private Animator _anims;
	
	
	// Use this for initialization
	void Awake () 
	{
		//Init our Singleton Pattern to ensure we can only ever have 1 copy of DialogManager in our scene.
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
			// Run the DQ Function on the given dialogText object and display the returned string
			// in the UI text box
			DisplayText(dialogText.DQ());
		}

		
		// If there is nothing left in the dialogText object (null) stow the dialog box
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
