using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ExitApplication()
    {
        #if UNITY_ANDROID
        using (AndroidJavaObject activity = new AndroidJavaObject("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject currentActivity = activity.Get<AndroidJavaObject>("currentActivity");
            currentActivity.Call("finish");
        }
        #else
        Application.Quit();
        #endif
    }
}
