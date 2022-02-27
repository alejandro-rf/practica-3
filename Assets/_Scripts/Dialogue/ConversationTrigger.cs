using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    [SerializeField]
    Conversation Conversation;

    private void StartConversation()
    {
        DialogueManager.StartConversation(Conversation, gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartConversation();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
