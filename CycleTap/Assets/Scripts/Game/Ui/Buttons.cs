using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Menu;
using UnityEngine.SceneManagement;

public class Buttons : Page
{
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
      // Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(1);
        PageController.instance.TurnPageOn(PageType.Loading);

    }
    public void Openshop()
    {
        PageController.instance.TurnPageOn(PageType.Shop);
        PageController.instance.TurnPageOff(PageType.Task);
        PageController.instance.TurnPageOff(PageType.Setting);
        PageController.instance.TurnPageOff(PageType.Social);
    }
    public void Closeshop()
    {
        PageController.instance.TurnPageOff(PageType.Shop);
    }
    public void OpenTask()
    {
        PageController.instance.TurnPageOn(PageType.Task);
        PageController.instance.TurnPageOff(PageType.Shop);
        PageController.instance.TurnPageOff(PageType.Setting);
        PageController.instance.TurnPageOff(PageType.Social);
    }
    public void CloseTask()
    {
        PageController.instance.TurnPageOff(PageType.Task);
    }
    public void OpenSetting()
    {
        PageController.instance.TurnPageOn(PageType.Setting);
        PageController.instance.TurnPageOff(PageType.Shop);
        PageController.instance.TurnPageOff(PageType.Task);
        PageController.instance.TurnPageOff(PageType.Social);
    }
    public void CloseSetting()
    {
        PageController.instance.TurnPageOff(PageType.Setting);
    }
    public void CloseSocial()
    {
        Animator.SetBool("Socials", false);
      //  PageController.instance.TurnPageOff(PageType.Social);


    }
    public void CloseSocialEvent()
    {
       // Animator.SetBool("Socials", false);
        PageController.instance.TurnPageOff(PageType.Social);


    }
    public void OpenSocial()
    {

        PageController.instance.TurnPageOn(PageType.Social);
        Animator.SetBool("Socials", true);
        PageController.instance.TurnPageOff(PageType.Shop);
        PageController.instance.TurnPageOff(PageType.Task);
        PageController.instance.TurnPageOff(PageType.Setting);
        


    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
