using RPG.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Player player;

    /*
    void OnEnable() => player.onWalk += ActualizarUiWalk;

    void OnDisable() => player.onWalk -= ActualizarUiWalk;


    private void ActualizarUiWalk(bool isWalk)
    {
        Debug.Log($"UI- Actualizo la barra de vida {isWalk}");
    }
    */

    void OnEnable() => player.OntakeItem += ActualizarIuTakeItem;

    void OnDisable() => player.OntakeItem -= ActualizarIuTakeItem;

    public void ActualizarIuTakeItem(string itemName)
    {
        Debug.Log($"UI- se recogio el item llamado {itemName}");
    }
}
