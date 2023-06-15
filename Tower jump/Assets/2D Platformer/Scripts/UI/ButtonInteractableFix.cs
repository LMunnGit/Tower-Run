using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractableFix : MonoBehaviour
{
[SerializeField] Button button;

void Update()
{
    button.interactable = true;
}
}
