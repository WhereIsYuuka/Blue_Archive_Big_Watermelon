using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSetting : MonoBehaviour
{
    public Dropdown dropdown;
    public Button button;
    
    private void Awake() {
        button.onClick.AddListener(DropChange);
        Screen.SetResolution(720, 1080, false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropChange()
    {
        switch(dropdown.value)
        {
            case 0:
                Screen.SetResolution(720, 1080, false);
                break;
            case 1:
                Screen.SetResolution(900, 1350, false);
                break;
            case 2:
                Screen.SetResolution(600, 900, false);
                break;
        }
    }
}
