using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSetting : MonoBehaviour
{
    public Dropdown dropdown;
    
    private void Awake() {
        dropdown = GetComponent<Dropdown>();
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
                Screen.SetResolution(720, 1280, false);
                break;
            case 1:
                Screen.SetResolution(900, 1440, false);
                break;
            case 2:
                Screen.SetResolution(640, 1136, false);
                break;
        }
    }
}
