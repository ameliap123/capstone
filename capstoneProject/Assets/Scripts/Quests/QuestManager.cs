using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>();   //Master Quest List
    public List<Quest> currentQuestList = new List<Quest>();    //Current Quest List

    //private variables for QuestObject

    void Awake()
    {
        //makes sure there is no duplicates and keeps it persistent
        if (questManager == null)
        {
            questManager = this;
        }
        else if(questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void QuestRequest(QuestObject thisQuestObject)
    {
        //Check for Available Quests
        if (thisQuestObject.availableQuestIDs.Count > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                for (int j = 0; j < thisQuestObject.availableQuestIDs.Count; j++)
                {
                    if (questList[i].id == thisQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE)
                    {
                        Debug.Log("Quest ID: " + thisQuestObject.availableQuestIDs[j] + " " + questList[i].progress);
                        //Testing
                        AcceptQuest(thisQuestObject.availableQuestIDs[j]);
                        //quest ui manager
                    }
                }
            }

        }
        //Check for Active Quests
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            for (int j = 0; j < thisQuestObject.receivableQuestIDs.Count; j++)
            {
                if (currentQuestList[i].id == thisQuestObject.receivableQuestIDs[j] && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED || currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    Debug.Log("Quest ID: " + thisQuestObject.receivableQuestIDs[j] + " is " + currentQuestList[i].progress);

                    CompleteQuest(thisQuestObject.receivableQuestIDs[j]);
                    //quest ui manager
                }
            }
        }
    }

    //Accept a quest
    public void AcceptQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;
            }
        }
    }

    //Give up a quest
    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quest.QuestProgress.AVAILABLE;
                currentQuestList[i].questObjectiveCount = 0;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

    //Complete a quest
    public void CompleteQuest(int questID)
    {
        for(int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);

                //reward
            }
        }
        //check for chain quests (definitely could do tutorial like this)
        CheckChainQuest(questID);
    }

    //Check Chain Quests
    //not pubic, but can be made private outside the simple void function
    void CheckChainQuest(int questID)
    {
        int num = 0;
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].nextQuest > 0)
            {
                num = questList[i].nextQuest;
            }
        }

        if (num > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == num && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE)
                {
                    questList[i].progress = Quest.QuestProgress.AVAILABLE;
                }
            }
        }
    }


    //Add Items
    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quest.QuestProgress.COMPLETE;
            }
        }
    }

    //Remove Items (inventory system)


    //BOOLS - to check if we have quests (available, accepted, completed)

    public bool RequestAvailableQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }


    //BOOLS 2 - passing over complete quest object, not ID like before 

    public bool CheckAvailableQuests(QuestObject thisQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < thisQuestObject.availableQuestIDs.Count; j++)
            {
                if (questList[i].id == thisQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuests(QuestObject thisQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < thisQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == thisQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompletedQuests(QuestObject thisQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < thisQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == thisQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    return true;
                }
            }
        }
        return false;
    }

}