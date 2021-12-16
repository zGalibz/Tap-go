
using UnityEngine;
namespace UnityCore{
    namespace Audio{
        public class TestAudio : MonoBehaviour
        {
            public AudioController audioController;

            #region Unity Functions
#if UNITY_EDITOR
            private void Update()
            {
                if (Input.GetKeyUp(KeyCode.Alpha7))
                {
                    audioController.PlayAudio(AudioType.ST_01,true,1.0f);
                }
                if (Input.GetKeyUp(KeyCode.Alpha4))
                {
                    audioController.StopAudio(AudioType.ST_01,true);
                }
                if (Input.GetKeyUp(KeyCode.Alpha1))
                {
                    audioController.RestartAudio(AudioType.ST_01, true);
                }
                if (Input.GetKeyUp(KeyCode.Alpha8))
                {
                    audioController.PlayAudio(AudioType.SFX_01);
                }
                if (Input.GetKeyUp(KeyCode.Alpha5))
                {
                    audioController.StopAudio(AudioType.SFX_01);
                }
                if (Input.GetKeyUp(KeyCode.Alpha2))
                {
                    audioController.RestartAudio(AudioType.SFX_01);
                }


            }

#endif
            #endregion
        }
    }
}
