﻿/*
 * Is used to set the state of the WWise State Group
 * @Faulker Bodbyl-Mast '21
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSoft.Audio
{
    public class AudioStateController : MonoBehaviour
    {
        [Tooltip("The name of the WWise Stategroup")]
        public string stateGroup;

        /// <summary>
        /// Changes the state of a WWise State Group. Triggers an error if the event cannot be found
        /// </summary>
        /// <param name="in_state">The string of the new state</param>
        public void Change_State(string in_state)
        {
            AKRESULT result = AkSoundEngine.SetState(stateGroup, in_state);
            if(result == AKRESULT.AK_IDNotFound)
            {
                Debug.LogError("ID " + stateGroup + " cannot be found. Make sure that the banks were generated with the 'include string' option.");
            }
        }
    }
}
