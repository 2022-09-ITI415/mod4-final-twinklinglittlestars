using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{

public class Npc1 : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialogueObject;
    public RigidbodyFirstPersonController rigid;
    //public bool hasTalked = false;
   
    private void OnTriggerStay(Collider other) // teaching player to interact with npc to find more information about game play
    {
        if(other.gameObject.tag == "Player")
        {
            triggerText.SetActive(true); // when player collides with the npc object they will see this option below:
            if(Input.GetKeyDown(KeyCode.U)) // when player enters the key U they can access the dialogue screen
            {
               // dialogue will appear
                other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                DialogueObject.SetActive(true);
                //rigid.enabled = false; // to not move when we are reading the dialogue
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //triggerText.SetActive(false)
            }
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        triggerText.SetActive(false); // when player leaves collision area with npc object, text screen will disappear
    }
}
}
