using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SIMPLE : MonoBehaviour
{
    public void OnClickContinue()
    {
        SceneManager.LoadScene("FieldScene");
    }
}
