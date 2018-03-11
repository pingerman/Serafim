using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowCharacterInfoWhenClicked : MonoBehaviour {

    [SerializeField] private GameObject characterInfoPanel;

    private void OnMouseDown()
    {
        characterInfoPanel.SetActive(true);
    }
}
