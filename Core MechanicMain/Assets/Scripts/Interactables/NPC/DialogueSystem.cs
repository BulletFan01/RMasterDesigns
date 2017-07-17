using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SINGLETON TO ENSURE ONLY ONE INSTANCE OF DIALOGUE SYSTEM EXISTS
public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance{ get; set; }

    private List<string> dialogueLines = new List<string>();
    private string npcName;

    public GameObject dialoguePanel;
    Button continueBtn;
    Text dialogueText, nameText;
    int dialogueIndex;

    public ThirdPersonCamera thisCamera;

    public PlayerController pController;

    void Awake ()
    {
        continueBtn = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        //dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueBtn.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);
		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}
	
	public void AddNewDialogue(string[] lines, string name)
    {
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        npcName = name;
        dialogueIndex = 0;
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
        thisCamera.DisableMouse();
        pController.DisableMove();
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex = dialogueIndex + 1;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            thisCamera.EnableMouse();
            pController.EnableMove();
        }
    }
}
