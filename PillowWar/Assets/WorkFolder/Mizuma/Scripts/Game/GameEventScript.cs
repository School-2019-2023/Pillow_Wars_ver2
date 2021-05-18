using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventScript : SingletonMonoBehaviour<GameEventScript>
{
    [SerializeField] private GameEventData gameEventData;

    private int detailEventsNum;
    private int finishEventsNum;
    private bool isEventStart;
    private EVENT_TYPE nextEventType;

    public float remainEventStopTime;
    public float remainEventActiveTime;

    private void Start()
    {
        detailEventsNum = gameEventData.gameEvents.Length;
    }

    public void Init()
    {
        NextEventStart();
    }

    public void UpdateMethod()
    {
        if (remainEventStopTime < 0)
        {
            if (isEventStart == false) isEventStart = true;
            remainEventActiveTime -= Time.deltaTime;
            if (remainEventActiveTime < 0)
            {
                isEventStart = false;
                NextEventStart();
                EventActive(nextEventType);
            }
        }

        remainEventStopTime -= Time.deltaTime;
    }

    private void NextEventStart()
    {
        if(finishEventsNum < detailEventsNum)
        {
            remainEventStopTime = gameEventData.gameEvents[finishEventsNum].stopEventInterval;
            remainEventActiveTime = gameEventData.gameEvents[finishEventsNum].eventActiveTime;
            nextEventType = gameEventData.gameEvents[finishEventsNum].type;
        }
        else
        {
            remainEventStopTime = gameEventData.finalEventInfo.stopEventInterval;
            remainEventActiveTime = gameEventData.finalEventInfo.eventActiveTime;
            nextEventType = gameEventData.finalEventInfo.type;
        }

        finishEventsNum++;
    }

    private void EventActive(EVENT_TYPE type)
    {
        if (type == EVENT_TYPE.TeacherAttack)
        {
            for(int i = 0; i < GameManager.Instance.joinPlayers; i++)
            {
                PlayerManager.Instance.charaDatas[i].Damage();
            }
        }
    }
}