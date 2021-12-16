using System.Collections;

using UnityEngine;

namespace UnityCore
{
    namespace Menu
    {



        public class Page : MonoBehaviour
        {
            public static readonly string FLAG_ON = "On";
            public static readonly string FLAG_OFF = "Off";
            public static readonly string FLAG_None = "None";
            public bool debug;

            public PageType Type;
            public bool UseAnimaton;
            public string targetState { get; private set; }

            private Animator m_Animator;
            private bool m_IsOn;

            public bool isOn
            {
                get { return m_IsOn; }

                private set { m_IsOn = value; }
            }


            #region Unity Functions
            private void OnEnable()
            {
                CheckAnimatorIntegrity();
                OnPageEnabled();
            }
            #endregion

            #region Public Functions
            public void Animate(bool _On)
            {
                if (UseAnimaton)
                {
                    m_Animator.SetBool("On", _On);
                    StopCoroutine("AwaitAnimation");
                    StartCoroutine("AwaitAnimation", _On);
                }
                else
                {
                    if (!_On)
                    {
                        gameObject.SetActive(false);
                        isOn = false;
                    }
                    else
                    {
                        isOn = true;
                    }
                }


            }
            #endregion

            #region Private Functions
            private IEnumerator AwaitAnimation(bool _On)
            {
                targetState = _On ? FLAG_ON : FLAG_OFF;

                while (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName(targetState))
                {
                    yield return null;

                }
                while (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                {
                    yield return null;

                }
                targetState = FLAG_None;

                Log("Page [" + Type + "] finished transitioning to " + (_On ? "on" : "off"));
                if (!_On)
                {
                    isOn = false;
                    gameObject.SetActive(false);
                }
                else
                {
                    isOn = true;
                }
            }

            private void CheckAnimatorIntegrity()
            {
                if (UseAnimaton)
                {
                    m_Animator = GetComponent<Animator>();
                    if (!m_Animator)
                    {
                        LogWarning("You opted to animate page [" + Type + "], but no Animator component exists on  the object ");
                    }
                }

            }
            private void Log(string _msg)
            {
                if (!debug) return;
                Debug.Log("[Page]:" + _msg);

            }
            private void LogWarning(string _msg)
            {
                if (!debug) return;
                Debug.LogWarning("[Page]:" + _msg);

            }
            #endregion
            #region Override function
            protected virtual void OnPageEnabled()
            {

            }
            #endregion
        }
    }
}