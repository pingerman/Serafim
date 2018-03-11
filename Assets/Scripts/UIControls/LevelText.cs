using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelText : Text, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (loadLevelDelegate != null) loadLevelDelegate(gameObject.tag);
    }

    public delegate void LoadLevel(string sceneName);
    static public LoadLevel loadLevelDelegate;
}
