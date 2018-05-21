using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartButtonsCheck : MonoBehaviour {
    public Button startButton;
    public Button createButton;
    public Button deleteButton;
    // Use this for initialization
    void Start () {
        if (CharacterData.character.SaveCheck())
        {
            startButton.interactable = true;
            createButton.interactable = false;
            deleteButton.interactable = true;

        }
        //if file doesn't exists...
        else
        {
            startButton.interactable = false;
            createButton.interactable = true;
            deleteButton.interactable = false;
        }
    }
	

}
