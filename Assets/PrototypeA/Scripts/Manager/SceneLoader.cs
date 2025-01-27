using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public RenderPipelineAsset urpBalanced;
    public RenderPipelineAsset urp2DLight;
    
    
    public void EnterScene(string SceneName)
    {
        GraphicsSettings.renderPipelineAsset = urpBalanced; 
        
        SceneManager.LoadScene(SceneName);
    }
    
   
}