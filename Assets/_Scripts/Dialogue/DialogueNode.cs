using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    public string Text;
    public List<DialogueOption> Options;
}

[System.Serializable]
public class DialogueOption
{
    public string Text;
    public DialogueNode TargetNode;
}

[CreateAssetMenu(fileName = "NewEndNode", menuName = "Dialogue/EndNode")]
public class EndNode : DialogueNode
{
    public virtual void OnChosen(GameObject talker)
    {
        Debug.Log(talker.name + " EndNode has been chosen");
    }
}

[CreateAssetMenu(fileName = "ShopkeeperAttackEndNode", menuName = "Dialogue/EndNode/NPCAttack")]
public class ShopkeeperAttackEndNode : EndNode
{
    public override void OnChosen(GameObject talker)
    {
        talker.GetComponent<CharacterActions>().Attack();
    }
}
