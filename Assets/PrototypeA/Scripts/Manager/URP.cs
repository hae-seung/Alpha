using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class URP : MonoBehaviour
{
    public RenderPipelineAsset urpAsset1;
    public RenderPipelineAsset urpAsset2;
    
    
    public void OnClick()
    {
        GraphicsSettings.renderPipelineAsset = urpAsset1; 
        
        SceneManager.LoadScene("SampleScene");
    }
    
   
}