using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool dialogue_Charlotte;
    public bool dialogue_Fantome;

    public bool focus;
    private bool Triggerfocus;
    private Vector3 refvel;
    public GameObject FocusGameobject;

    private void Update()
    {
        if (Triggerfocus)
        {
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, FocusGameobject.transform.position, ref refvel, 3, 3);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,-10);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TriggerDialogue();
            if (focus)
            {
                Triggerfocus = true;
            }
        }
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogue_Charlotte, dialogue_Fantome);
    }
}
