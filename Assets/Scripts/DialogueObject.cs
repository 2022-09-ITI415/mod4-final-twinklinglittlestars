using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{
[Serializable]

public class DialogueOBJ
{
    public string[] Dialogues;
    public string CharacterName;
    public int questNumber;
}
public class DialogueObject : MonoBehaviour
{
    public PlayerData data;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public RigidbodyFirstPersonController rigid;

    //private QuestObj obj;

    private int currentDialogueNum = 0; //dialogue progression
    private DialogueOBJ curDialogue = null; // storing current dialogue

    [Header("Dialogue objects")]
    public DialogueOBJ dialogue1;
    //public DialogueOBJ dialogue1o5;

    //[Header("NPCS")]
    //public Npc1 npc1;

   /* private void Awake()
    {
        obj = FindObjectOfType<QuestObj>();
    }*/
   
    private void onEnable()
    {
        switch (data.DialogueNumber)
        {
            case 1:
                PlayDialogue(dialogue1);
                curDialogue = dialogue1;
                break;
            /*case 1.5f:
                PlayDialogue(dialogue1o5);
                curDialogue = dialogue1o5;
                    break;*/
        }
    }

    void PlayDialogue(DialogueOBJ tempobj)
    {
        nameText.text = tempobj.CharacterName;
        if(currentDialogueNum < tempobj.Dialogues.Length)
        {
            DialogueText.text = tempobj.Dialogues[currentDialogueNum];
        }
        else
        {
            rigid.enabled = false; // to not move when we are reading the dialogue
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            /*switch (data.DialogueNumber) 
            {
                case 1:
                    npc1.hasTalked = true;
                    break;

            }*/
            data.DialogueNumber = 0;
            currentDialogueNum = 0;
            data.questNumber = curDialogue.questNumber;
            curDialogue = null;
            this.gameObject.SetActive(false);
        }
    }

    public void next()
    {
        if (curDialogue != null) 
        {
            currentDialogueNum++;
            PlayDialogue(curDialogue);
        }
    }
}
}