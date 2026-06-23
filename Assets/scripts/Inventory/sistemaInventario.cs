using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Inventory
{
    public class sistemaInventario : MonoBehaviour
    {
        public List<string> items = new List<string>();

        //eventito dwb
        public static Action<string> OnItemAdded;

        public void AgregarItem(string item)
        {
            items.Add(item);

            Debug.Log(item + " agregado a este inventario,si a este");

            //el evento deberia funcionar aqui no? roguemos porque si funcione
            OnItemAdded?.Invoke(item);
        }
    }
}


