using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterStatusWhenSelect : MonoBehaviour
{
    Animator anim;
    bool appearingFlag;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
                if (hit.transform.tag != "Character Status Panel" && appearingFlag) anim.SetTrigger("Off");
            else anim.SetTrigger("Off");      
        }
    }

    private void LateUpdate()
    {
        appearingFlag = true;
    }

    private void OnDisable()
    {
        appearingFlag = false;
    }
}
