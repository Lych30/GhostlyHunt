using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool dialogue_Charlotte;
    public bool dialogue_Fantome;

    private bool Triggerfocus;
    private Vector3 refvel;
    public GameObject FocusGameobject;

    private void Update()
    {
        if (Triggerfocus)
        {
            Camera.main.GetComponent<zoomPinch>().enabled = false;
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, FocusGameobject.transform.position, ref refvel, 3, 10);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,-10);
        }
        if(Triggerfocus && Vector2.Distance(Camera.main.transform.position, FocusGameobject.transform.position) < 4)
        {
            Camera.main.GetComponent<zoomPinch>().enabled = true;
            this.enabled = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TriggerDialogue();
            if (FocusGameobject != null)
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
