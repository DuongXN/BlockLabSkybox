using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class demo : MonoBehaviour
{
    private void OnEnable()
    {
        string input = "Hello!@$%World&()";
        string pattern = @"a";

        bool containsSpecialChars = Regex.IsMatch(input, pattern);

        if (containsSpecialChars)
        {
           Debug.Log("Chuỗi chứa ít nhất một ký tự đặc biệt");
        }

    }
}
