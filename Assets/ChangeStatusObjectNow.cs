using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatusObjectNow : MonoBehaviour
{
    public void ChangeEnableStatus()
    {
        GameState.Instance.SetState(State.Play);
        gameObject.SetActive(false);
    }
}
