using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class AudioOptionsController
    {
        private static AudioOptionsController instance = null;
        private static readonly object threadlock = new object();
        public static AudioOptionsController Instance
        {
            get
            {
                lock (threadlock)
                {
                    if (instance == null)
                        instance = new AudioOptionsController();
                    return instance;
                }
            }
        }

        internal AudioOptions _audioOptions = AudioOptions.Instance;
    }
}

