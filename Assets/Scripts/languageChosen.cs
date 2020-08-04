using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class languageChosen : MonoBehaviour
{
    public Text palindromeLanguage;
    public Text pDALanguage_textField;
    string palLan = "XS1";
    string pDALan = "(XS1)";
    public void palindromeLanguag()
    {
        palindromeLanguage.text = palLan.ToString();
    }

    public void PDALanguag()
    {
        pDALanguage_textField.text = pDALan.ToString();
    }
}
