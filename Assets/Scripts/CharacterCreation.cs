using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {

    [SerializeField]
    private float STRFillAmount;
    [SerializeField]
    private float INTFillAmount;
    [SerializeField]
    private float DEXFillAmount;
    [SerializeField]
    private Image STRContent;
    [SerializeField]
    private Image INTContent;
    [SerializeField]
    private Image DEXContent;

    public Mob mob;
    GameObject selectedRace;
    public Text descText;
    // Use this for initialization
    void Start() {
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
        //print("Loading a..." + mob.race);
        selectedRace = Instantiate(mob.body, transform);
        transform.position = Vector3.up * (selectedRace.transform.localScale.y - 1);
        descText.text = mob.description;
        HandleStatBars();
    }

    void HandleStatBars()
    {
        STRContent.fillAmount = Map(mob.strength, 0,20, 0, 1);

        INTContent.fillAmount = Map(mob.intelligence, 0, 20, 0, 1);

        DEXContent.fillAmount = Map(mob.dexterity, 0, 20, 0, 1);

    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
