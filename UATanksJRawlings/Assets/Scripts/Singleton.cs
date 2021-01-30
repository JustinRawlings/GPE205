using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inhererits from monobehaviour while using T inhereting from singleton
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    //Creates T instance
    private static T instance;
    public static T Instance
    {
        //Accessor
        get
        {
            return instance;
        }

    }

    //Initializes instance
    public bool IsInitialized
    {
        get
        {
            return instance != null;
        }
    }

    protected virtual void Awake()
    {
        //Checks if instance exists if it does, then it deletes the new instance. Otherwise
        // it doesn't destroy the instance created here.
        if (IsInitialized)
        {
            Debug.LogError("[Singleton] Tried to create a second instance of a Singleton Class");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            instance = (T)this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //Removes self from reference
    protected virtual void OnDestroy()
    {
        instance = null;
    }

}