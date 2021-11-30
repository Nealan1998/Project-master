using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterSwap : MonoBehaviour
{
    public Image characterImage;
    Dropdown dropDown;

    private void Awake()
    {
        dropDown = GetComponent<Dropdown>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropDownSelection()//int selectionIndex)
    {
        int selectionIndex = dropDown.value;
        Debug.Log("player selected " + dropDown.options[selectionIndex].text);
        characterImage.sprite = dropDown.options[selectionIndex].image;
    }
}
