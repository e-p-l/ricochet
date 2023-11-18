using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{   
    public GameObject rules;

    public Animator transition;

    public float transitionTime = 1f;

    public void LoadGame(){
        StartCoroutine(LoadLevel());
    }

    public void ShowRules(){
        rules.SetActive(true);
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("GameScene");
    }


}
