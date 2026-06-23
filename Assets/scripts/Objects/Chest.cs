using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log("Tocaste este cofre, eso es bueno");
    }
}
