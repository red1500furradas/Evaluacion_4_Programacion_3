using RPG.Characters;
using RPG.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recogibleItem : MonoBehaviour
{
    public string nombreItem = "Espada";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            sistemaInventario inventario = other.GetComponent<sistemaInventario>();


            if (inventario != null)
            {
                inventario.AgregarItem(nombreItem);
            }

            Destroy(gameObject);
        }
    }
}
