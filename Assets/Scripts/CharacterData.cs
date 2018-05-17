using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CharacterData : MonoBehaviour {

    public static CharacterData character;
    //player stats and info


    private void Awake()
    {
        if(character == null)
        {
            DontDestroyOnLoad(gameObject);
            character = this;
        }
        else if(character != this)
        {
            Destroy(gameObject);
        } 
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 30), "Character data...");
        GUI.Label(new Rect(100, 130, 100, 30), "To be loaded...");
    }

    public void Save()
    {
        //saves Data out to a file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/FSCharacter.dat", FileMode.Open);

        Mob data = new Mob();
        data.health = PlayerController.player.health;
        data.strength = PlayerController.player.strength;
        data.intelligence = PlayerController.player.intelligence;
        data.dexterity = PlayerController.player.dexterity;

        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/FSCharacter.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/FSCharacter.dat", FileMode.Open);
            Mob data = (Mob)bf.Deserialize(file);
            file.Close();
            PlayerController.player.health = data.health;
            PlayerController.player.strength= data.strength;
            PlayerController.player.intelligence= data.intelligence;
            PlayerController.player.dexterity= data.dexterity;
        }
    }
}
