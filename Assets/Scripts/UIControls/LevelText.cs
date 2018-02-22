using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelText : Text, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (linkToMethod != null) linkToMethod(gameObject.tag);
    }

    public delegate void LoadLevel(string sceneName);
    static public LoadLevel linkToMethod;
}
