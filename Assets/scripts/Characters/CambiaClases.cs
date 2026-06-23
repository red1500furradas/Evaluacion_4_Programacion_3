using RPG.Characters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CambiaClases : MonoBehaviour
{
    public TipoClase nuevaClase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().CambiarClase(nuevaClase);
        }
    }
}
