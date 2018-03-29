using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

// Пока этот класс не работает, не стоит обращать внимание
public class CharacterStatusWhenSelect : MonoBehaviour
{
    Animator anim;
    bool appearingFlag;
    List<RaycastResult> result;
    GraphicRaycaster graphicRaycaster;
    PointerEventData pointerEveneData;

    void Start()
    {
        anim = GetComponent<Animator>();
        result = new List<RaycastResult>();
        pointerEveneData = new PointerEventData(null);
        graphicRaycaster = GetComponentInParent<GraphicRaycaster>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0) && appearingFlag)
        //{
        //    pointerEveneData.position = Input.mousePosition;
        //    graphicRaycaster.Raycast(pointerEveneData, result);
        //}
    }

    public void SwitchAppearingFlag()
    {
        appearingFlag = !appearingFlag;
    }

    public void TriggerDissapearing()
    {
        anim.SetTrigger("Off");
    }
}
