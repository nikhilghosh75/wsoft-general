﻿/* 
 * This script allows UnityEvents to statically call the Game Manager's load scene method.
 * @ Max Perraut '20
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WSoft.Core
{
    public class LoadScene : MonoBehaviour
    {
        /// <summary>
        /// Loads a scene by name
        /// </summary>
        /// <param name="sceneName">The scene to be loaded</param>
        public void LoadByName(string sceneName)
        {
            GameManager.LoadScene(sceneName);
        }
    }
}
