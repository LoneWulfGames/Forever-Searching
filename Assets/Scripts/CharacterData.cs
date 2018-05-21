using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour {
    
    public static CharacterData character;


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
        SaveCheck();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 30), "Character data...");
        GUI.Label(new Rect(100, 130, 100, 30), "To be loaded...");
    }
    public bool SaveCheck()
    {
        bool exists; 
        //if file exists...
        if (File.Exists(Application.persistentDataPath + "/FSCharacter.dat"))
        {
           exists = true;
        }
        //if file doesn't exists...
        else
        {
            exists = false;
        }
        return exists;

    }
    public void Save()
    {
        //saves Data out to a file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/FSCharacter.dat", FileMode.Open);

        Mob data = new Mob();
        data.health = PlayerInputControl.player.health;
        data.strength = PlayerInputControl.player.strength;
        data.intelligence = PlayerInputControl.player.intelligence;
        data.dexterity = PlayerInputControl.player.dexterity;

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
            PlayerInputControl.player.health = data.health;
            PlayerInputControl.player.strength= data.strength;
            PlayerInputControl.player.intelligence= data.intelligence;
            PlayerInputControl.player.dexterity= data.dexterity;
        }
    }
}
