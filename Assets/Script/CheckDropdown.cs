using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown dropdown;
    void Start()
    {
        dropdown.onValueChanged.AddListener((int value) =>
        {
            Debug.Log(value);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
