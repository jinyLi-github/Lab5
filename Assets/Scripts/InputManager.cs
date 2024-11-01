using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public InputActionAsset controls;
    public InputAction moveAction;
    public InputAction fireAction;

    private void Awake()
    {
        //Singleton pattern setup
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        moveAction = controls.FindAction("Move");
        fireAction = controls.FindAction("Fire");
    }


}
