using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Speech;
    public TextMeshProUGUI[] OptionTexts;

    private Animator _animator;

    private DialogueNode _currentNode;

    private GameObject _talker;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _animator = GetComponent<Animator>();
    }

    internal static void StartConversation(Conversation conversation, GameObject npc)
    {
        Instance._StartConversation(conversation, npc);
    }
    private void _StartConversation(Conversation conversation, GameObject npc)
    {
        Show();
        SetTexts(conversation);

        _currentNode = conversation.StartNode;
        _talker = npc;
        SetNodeTexts(_currentNode);
    }

    private void SetTexts(Conversation conversation)
    {
        Name.text = conversation.Name;
    }

    private void SetNodeTexts(DialogueNode node)
    {
        Speech.text = node.Text;

        for (int i = 0; i < OptionTexts.Length; i++)
        {
            if (i < node.Options.Count)
            {
                OptionTexts[i].text = node.Options[i].Text;
                OptionTexts[i].transform.parent.gameObject.SetActive(true);
            }
            else
            {
                OptionTexts[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void NextNode(int optionListNumber)
    {
        DialogueNode nextNode = _currentNode.Options[optionListNumber].TargetNode;

        if (nextNode is EndNode)
        {
            DoEndNode(nextNode as EndNode);
            return;
        }

        _currentNode = nextNode;
        SetNodeTexts(_currentNode);
    }

    private void DoEndNode(EndNode nextNode)
    {
        nextNode.OnChosen(_talker);
        Hide();
    }

    public void Show()
    {
        _animator.SetBool("Show", true);
    }

    public void Hide()
    {
        _animator.SetBool("Show", false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
