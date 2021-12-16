
using UnityEngine;
namespace UnityCore {
    namespace Menu
    {

        public class TestMenu : MonoBehaviour
        {
            public PageController PageController;
#if UNITY_EDITOR
            private void Update()
            {
                if (Input.GetKey(KeyCode.F))
                {
                    PageController.TurnPageOn(PageType.Loading);

                }
                if (Input.GetKey(KeyCode.G))
                {
                    PageController.TurnPageOff(PageType.Loading);

                }
                if (Input.GetKey(KeyCode.H))
                {
                    PageController.TurnPageOff(PageType.Loading, PageType.Menu);

                }
                if (Input.GetKey(KeyCode.J))
                {
                    PageController.TurnPageOff(PageType.Loading, PageType.Menu,true);

                }


            }

#endif
        }
    }
}