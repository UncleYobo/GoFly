using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrashMessage : MonoBehaviour
{
    public TMP_Text crashText;
    public List<string> crashMessage;

    void Start()
    {
        int randomChoice = Random.Range(0, crashMessage.Count);
        crashText.text = crashMessage[randomChoice];
    }
}
