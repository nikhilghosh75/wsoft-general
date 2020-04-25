/*
 * Handles settign RTPC values in Wwise based on a slider
 * @ Nicolas Williams '20
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WSoft.Audio
{
    public class VolumeSlider : MonoBehaviour
    {
        [Tooltip("The text that shows the current level of volume")]
        [SerializeField]
        private Text volumeText;

        [Tooltip("The name of the RTPC in WWise that controls the volume")]
        public string RTPCName;

        Slider volumeSlider;

        void Start()
        {
            volumeSlider = GetComponent<Slider>();
        }

        /// <summary>
        /// Set the volume based on the current value of the slider
        /// </summary>
        public void SetVolume()
        {
            float newVolume = volumeSlider.value;
            volumeText.text = newVolume.ToString();
            AkSoundEngine.SetRTPCValue(RTPCName, newVolume);
        }
    }
}
