/*
 * Allows you to control the volume through UnityEngine.UI.Slider objects and WWise RTPC
 * @ Jacob Shreve '?, @ Nikhil Ghosh '23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSoft.Audio
{
    public struct VolumeData
    {
        [Tooltip("The slider that controls the volume")]
        public UnityEngine.UI.Slider volumeSlider;

        [Tooltip("The name of the RTPC in Wwise. Note that this will be the same name for PlayerPrefs")]
        public string volumeRTPC;

        /// <summary>
        /// Set the RTPC and PlayerPrefs value for the volume when the value on a slider has changed
        /// </summary>
        /// <param name="newValue">The new value for the RTPC</param>
        public void SetVolumeFromValue(float newValue)
        {
            float realVolume = Mathf.Clamp01(newValue);
            Debug.Log(volumeRTPC + " set to " + realVolume);
            volumeSlider.SetValueWithoutNotify(realVolume * volumeSlider.maxValue);
            PlayerPrefs.SetFloat(volumeRTPC, realVolume);
            AkSoundEngine.SetRTPCValue(volumeRTPC, realVolume);
        }
    }

    public class VolumeController : MonoBehaviour
    {
        [Tooltip("A list of volumes that can be controlled")]
        public List<VolumeData> volumesToControl;

        void Start()
        {
            foreach(VolumeData volume in volumesToControl)
            {
                if (PlayerPrefs.HasKey(volume.volumeRTPC))
                {
                    volume.SetVolumeFromValue(PlayerPrefs.GetFloat(volume.volumeRTPC));
                }
                else
                {
                    volume.SetVolumeFromValue(0.5f);
                }
                volume.volumeSlider.onValueChanged.AddListener(volume.SetVolumeFromValue);
            }
        }
    }
}