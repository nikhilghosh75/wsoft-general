/* 
 * Scriptable objects specialized for audio events. allows audio team work to be
 * completely decoupled from all other work, minimizing risk of merge conflicts during the workflow
 * @ Nicolas Williams '20
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSoft.Audio
{
    [CreateAssetMenu]
    public class AudioEvent : ScriptableObject
    {
        public AK.Wwise.Event wwiseEvent;

        /// <summary>
        /// Calls the Wwise event
        /// </summary>
        /// <param name="caller">The game object calling the event</param>
        public void PostWwiseEvent(GameObject caller)
        {
            // post wwise event
            if (wwiseEvent.IsValid())
            {
                Debug.Log(wwiseEvent);
                wwiseEvent.Post(caller);
            }
            // audio not yet created
            else
            {
                Debug.LogWarning("Warning: missing audio for audio event: " + name);
            }
        }
    }
}