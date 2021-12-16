
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace UnityCore
{
    namespace Menu
    {

        public class PageController : MonoBehaviour
        {
            public static PageController instance;

            public bool debug;
            public PageType entryPage;
            public Page[] Pages;

            private Hashtable m_Pages;

            #region Unity Functions
            private void Awake()
            {
                if (!instance)
                {
                    instance = this;
                    m_Pages = new Hashtable();
                    RegisterAllPAges();
                    if (entryPage != PageType.None)
                    {
                        TurnPageOn(entryPage);
                    }
                  //  DontDestroyOnLoad(gameObject);
                    
                }
                else { Destroy(gameObject); }
            }

            #endregion

            #region Public Functions
            public void TurnPageOn(PageType _type)
            {
                if (_type == PageType.None) return;

                if (!PageExist(_type))
                {
                    LogWarning("You are trying to turn a page on [" + _type + "] that has never been registered");
                    return;

                }
                Page _Page = GetPage(_type);
                _Page.gameObject.SetActive(true);
                _Page.Animate(true);
            }
            public void TurnPageOff(PageType _Off, PageType _On = PageType.None, bool _WaitForExit = false)
            {
                if (_Off == PageType.None) return;

                if (!PageExist(_Off))
                {
                    LogWarning("You are trying to turn a page off [" + _Off + "] that has never been registered");
                    return;

                }

                Page _offPage = GetPage(_Off);
                if (_offPage.gameObject.activeSelf)
                {
                    _offPage.Animate(false);
                }

                if (_On != PageType.None)
                {
                    Page _onPage = GetPage(_On);
                    if (_WaitForExit)
                    {

                        StartCoroutine(WaitForPagesExit(_onPage, _offPage));
                    }
                    else
                    {
                        TurnPageOn(_On);
                    }
                }
            }
            public bool PageIsOn(PageType _type)
            {
                if (!PageExist(_type))
                {
                    LogWarning("you are trying to detect if a page is on ["+_type+"], but it has not been registered");

                    return false;
                }
                return GetPage(_type).isOn;
            }
            #endregion

            #region Private Functions
            private IEnumerator WaitForPagesExit(Page _On,Page _Off)
            {
                while (_Off.targetState != Page.FLAG_None)
                {
                    yield return null;
                }
                TurnPageOn(_On.Type);
            }
            private void RegisterAllPAges()
            {
                foreach (Page _Page in Pages)
                {
                    RegisterPage(_Page);
                }
            }

            private void RegisterPage(Page _Page)
            {
                if (PageExist(_Page.Type))
                {
                    LogWarning("You're trying to register a pag [" + _Page.Type + "] that is already reagistered :" + _Page.gameObject.name);
                    return;
                }
                m_Pages.Add(_Page.Type, _Page);
                Log("Registered page [" + _Page.Type + "]");
            }
            private Page GetPage(PageType _type)
            {
                if (!PageExist(_type))
                {
                    LogWarning("You are trying to turn a page on [" + _type + "] that has never been registered");
                    return null ;
                }
                return (Page)m_Pages[_type];
              
            }
            private bool PageExist(PageType _type)
            {
                return m_Pages.Contains(_type);

            }
            private void Log(string _msg)
            {
                if (!debug) return;
                Debug.Log("[PageController]:" + _msg);

            }
            private void LogWarning(string _msg)
            {
                if (!debug) return;
                Debug.LogWarning("[PageController]:" + _msg);

            }
            #endregion

        }
    }
}
