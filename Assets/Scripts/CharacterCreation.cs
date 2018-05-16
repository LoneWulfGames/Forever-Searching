using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {

    public Mob mob;
    GameObject selectedRace;
    public Text descText;
	// Use this for initialization
	void Start () {
        ShowMob();
	}
	

    public void SwapMob(Mob newMob)
    {
        mob = newMob;
        Destroy(selectedRace);
        ShowMob();
    }
    void ShowMob()
    {
        print("Loading a..." + mob.race);
        selectedRace = Instantiate(mob.body, transform);
        transform.position = Vector3.up * (selectedRace.transform.localScale.y - 1);
        descText.text = mob.description;
    }
}
