using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textlabel;

    private void Start()
    {
        textlabel.text = "Tadaloo! \n motherfuckers !!!";

    }
}
