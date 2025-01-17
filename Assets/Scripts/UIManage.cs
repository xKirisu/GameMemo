using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    List<GameObject> childs;
    void Start()
    {
        childs = gameObject.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToList();
        childs.Remove(gameObject);

        foreach (GameObject child in childs)
        {
            child.SetActive(false);
        }
    }

    public void DisplayMenu()
    {
        foreach (GameObject child in childs)
        {
            child.SetActive(true);
        }
    }
    public void ResetClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
}
