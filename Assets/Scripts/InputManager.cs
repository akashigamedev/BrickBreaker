using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event EventHandler OnPauseResumePerformed;
    GameInput gameInput;
    void Awake()
    {
        gameInput = new GameInput();
        gameInput.Paddle.Enable();
        gameInput.GameInputs.Enable();
        // gameInput.GameInputs.PauseResume.performed += HandlePauseResumeInput();
        gameInput.GameInputs.PauseResume.performed += OnPauseResumeRecieved;
    }

    private void OnPauseResumeRecieved(InputAction.CallbackContext obj)
    {
        OnPauseResumePerformed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementInput()
    {
        Vector2 input = new Vector2(gameInput.Paddle.Move.ReadValue<float>(), 0f);
        input = input.normalized;
        return input;
    }
}
