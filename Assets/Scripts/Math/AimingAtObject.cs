/*
 * receive the gameobject from OnAggro and set it as the target of the enemies
 * in the scene. The enemies will rotate toward the target when it is in the scene,
 * and won't rotate toward it when it is out of the scene or if the target is cleared.
 * @Ziang Wang (ziang wang #7692)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSoft.Math
{
    public class AimingAtObject : MonoBehaviour
    {
        private GameObject target;

        [Tooltip("The speed at which to be aiming at")]
        public float speed = 5;

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                Vector2 direction = (target.transform.position - transform.position);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            }
        }

        /// <summary>
        /// Set the target to the specified gameobject
        /// </summary>
        /// <param name="p">The gameobject to set</param>
        public void SetTarget(GameObject p)
        {
            target = p;
        }

        /// <summary>
        /// Set the target to null
        /// </summary>
        public void ClearTarget()
        {
            target = null;
        }
    }
}
