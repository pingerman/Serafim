using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowCharacterInfoWhenClicked : MonoBehaviour
{

    [SerializeField] private GameObject characterInfoPanel;

    public void OpenCharacterInfo()
    {
        if (GameState.Instance.GetState() == State.Modal) return;
        characterInfoPanel.SetActive(true);
        GameState.Instance.SetState(State.Modal);
    }
}
