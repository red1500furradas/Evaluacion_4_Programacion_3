using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour , IDamageable
{
    public float vida = 50;

    public void RecibirDanio(float cantidad)
    {
        vida -= cantidad;

        Debug.Log("la caja sufrio daño, ¡ay!, fueron " + cantidad + " de daño");

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    //ingaturroña lo hice al reves XDDDDDD ok debo colocar esto en el cactus
    /*
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.RecibirDanio(10);
        }
    }
    */
}
