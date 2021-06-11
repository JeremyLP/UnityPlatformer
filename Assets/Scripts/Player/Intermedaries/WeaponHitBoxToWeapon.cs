using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBoxToWeapon : MonoBehaviour
{
    private AgressiveWeapon weapon;

    private void Awake() 
    {
        weapon = GetComponentInParent<AgressiveWeapon>();    
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        weapon.AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        weapon.RemoveFromDetected(collision);    
    }
}
