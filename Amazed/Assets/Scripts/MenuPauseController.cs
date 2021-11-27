using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseController : MonoBehaviour
{
    void Start()
    {

    }
    void resume()
    {
        gameObject.SetActive(false);
    }
    
}
