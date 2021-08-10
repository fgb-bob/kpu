using UnityEngine;
using System.Collections;

enum EVENT__TYPE {
    GAME_INIT, 
    GAME_END, 
    SCORE_INCREASE, 
    PLAYER_ATTACK, 
    PLAYER_DEAD, 
    ENERMY_DEAD
};

public interface IMyListener
{
    void OnEvent(EVENT_TYPE Event_Type, GameObject Sender, object Param = null);
}
