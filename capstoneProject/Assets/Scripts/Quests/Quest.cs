using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[System.Serializable]
public class Quest
{
    //DONE refers to after completion to go back to whom gave the quest
    public enum QuestProgress{NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETE, DONE}

    public string title;                    //title for the quest
    public int id;                          //ID number for the quest
    public QuestProgress progress;          //state of the currenr quest (referring to the enum)
    public string description;              //the quest description, given from the quest giver/receiver
    public string hint;                     //if stuck, giver/receiver of quest gives hint
    public string congratulation;           //from quest giver/receiver once finished quest
    public string summary;                  //from quest giver/receiver, information that you may need
    public int nextQuest;                   //next quest, if any (chain quests for example)

    public string questObjective;           //name of the quest objective
    public int questObjectiveCount;         //current number of questObjective count
    public int questObjectiveRequirement;   //required amount of questObjective

    //Rewards from completing quests
    public int expReward;
    public int mapReward;
    public int itemReward;
    public int plantReward;
}
