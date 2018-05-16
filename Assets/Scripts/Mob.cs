using UnityEngine;
public enum Races {
    HUMAN, DWARF, HALFLING, GNOME,
    OGRE, TROLL, GOBLIN, GREMLIN,
    LIGHTELF, WOODELF, SHADOWELF, PIXIE,
    KOTTORIC, VARANUS, URSINAE, MINOTAUR,
    REDDRACONIAN, BLUEDRACONIAN, GREENDRACONIAN, GOLDDRACONIAN };
        
[CreateAssetMenu(fileName = "New Mob", menuName = "Mob")]
public class Mob: ScriptableObject  {

    public new string name;

    public Races race;
    public string description;

    public int health;

    public GameObject body;

    public int strength;
    public int intelligence;
    public int dexterity;


}
