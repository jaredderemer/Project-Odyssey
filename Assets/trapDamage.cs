﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDamage : MonoBehaviour {

    public float damageAmount;

    // Hurts player on contact
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<playerHealth>().addDamage(damageAmount);
        }
    }
}
