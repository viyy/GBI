using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class VideoOptionsController
    {
        private static VideoOptionsController instance = null;
        private static readonly object threadlock = new object();
        public static VideoOptionsController Instance
        {
            get
            {
                lock (threadlock)
                {
                    if (instance == null)
                        instance = new VideoOptionsController();
                    return instance;
                }
            }
        }

        internal VideoOptionsModel _videoOptions = VideoOptionsModel.Instance;
    }
}
