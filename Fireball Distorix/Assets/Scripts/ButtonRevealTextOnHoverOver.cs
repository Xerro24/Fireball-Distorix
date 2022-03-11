using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRevealTextOnHoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.GetChild(1).gameObject.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        transform.GetChild(1).gameObject.SetActive(false);
        
    }
}
