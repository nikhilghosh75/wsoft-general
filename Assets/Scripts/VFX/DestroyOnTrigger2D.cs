﻿/* 
 * Destroys gameobject on trigger enter. Works only for 2D
 * Optionally instantiates hit particle prefab when destroyed.
 * @ Max Perraut '20
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSoft.VFX
{
    public class DestroyOnTrigger2D : MonoBehaviour
    {
        [Tooltip("The game object to be spawned on trigger. Set to null for nothing to spawn")]
        public GameObject hitParticle;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hitParticle)
            {
                Instantiate(hitParticle, this.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

