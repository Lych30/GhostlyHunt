using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText_Fantome;
    public Text dialogueText_Charlotte;

    public GameObject Gdialogue_Fantome;
    public GameObject Gdialogue_Charlotte;

    private Queue<string> sentences;

    public float temp_écriture;

    void Start()
    {
        sentences = new Queue<string>();

        Gdialogue_Fantome.SetActive(false);
        Gdialogue_Charlotte.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue, bool dialogue_Charlotte, bool dialogue_Fantome)
    {
        GameObject.Find("Hero").GetComponent<AIPath>().canMove = false;

        if (dialogue_Charlotte == true)
        {
            Gdialogue_Charlotte.SetActive(true);
        }
        if(dialogue_Fantome == true)
        {
            Gdialogue_Fantome.SetActive(true);
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();

        if(Gdialogue_Charlotte.activeSelf)
        {
            StartCoroutine(TypeSentence(sentence, dialogueText_Charlotte));
        }
        if(Gdialogue_Fantome.activeSelf)
        {
            StartCoroutine(TypeSentence(sentence, dialogueText_Fantome));
        }
        
        //dialogueText_Fantome.text = sentence;
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence, Text dialogueText)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(temp_écriture);
        }
    }

    void EndDialogue()
    {
        GameObject.Find("Hero").GetComponent<AIPath>().canMove = true;

        Gdialogue_Fantome.SetActive(false);
        Gdialogue_Charlotte.SetActive(false);
    }
}
