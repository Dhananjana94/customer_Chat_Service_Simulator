﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject AnswerPanel;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Type());
    }

    void Update()
    {
       if(textDisplay.text == sentences[index])
        {
            AnswerPanel.SetActive(true);
        } 
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentence()
    {
        source.Play();
        AnswerPanel.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            AnswerPanel.SetActive(false); 
        }
    }
}
