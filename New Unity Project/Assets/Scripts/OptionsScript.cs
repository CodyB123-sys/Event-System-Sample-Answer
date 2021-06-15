using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public Animator animator;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OptionsMenuEnter() 
    {
        animator.Play("OptionsMenuEnter");
    }

    public void OptionsMenuExit()
    {
        animator.Play("OptionsMenuExit");
    }

    public void BackClick()
    {
        animator.Play("OptionsMenuExit");
        menu.SetActive(true);
        menu.SendMessage("MainMenuEnter");
    }

    public void MainMenuEnter()
    {
        menu.SendMessage("MainMenuEnter");
    }
}
