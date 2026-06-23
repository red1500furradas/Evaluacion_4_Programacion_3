using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void interact()
    {
        Debug.Log("interactuando con un objeto...");
    }
}
