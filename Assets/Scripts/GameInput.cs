// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Paddle"",
            ""id"": ""a2c9f0aa-b2b1-4ec6-9d7b-04e273269811"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""dffa7fd4-995b-4680-a005-69b41a903201"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""e6d555af-b155-4681-95c3-1633ddfa09a3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8c0cb928-05eb-40f1-bb0f-5bed895ed74a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e294c3bd-c3b5-426b-a97c-3b400c76c10e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrowkeys"",
                    ""id"": ""39f3cdfb-22e5-4366-9b93-ec9b4c400537"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""11f02d39-9aff-485c-a3ab-12e191252c77"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""20ae82a5-05b1-4350-907c-920e6a43e221"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""498063a8-4e13-4ebc-b8d6-f3bcb7630e8c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5e28104e-d633-4c32-bb6a-29e8d7677af2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""80df6dae-ef29-4bd9-b01a-6ee6a65219ef"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Touch"",
                    ""id"": ""020721ed-dfaf-4e00-b830-91038942cb00"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8c95c564-df04-423a-bbc9-170e785ef615"",
                    ""path"": ""<Touchscreen>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3dc7b50a-af80-4aa4-84cf-0281f8286e0d"",
                    ""path"": ""<Touchscreen>/primaryTouch/tapCount"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameInputs"",
            ""id"": ""23989994-fb3f-4f9d-b710-dac32b42122a"",
            ""actions"": [
                {
                    ""name"": ""PauseResume"",
                    ""type"": ""Button"",
                    ""id"": ""0138bd91-3013-47c2-b273-d73f530ab1e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0922c024-457b-4f1a-bcaa-bbf985e45c81"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ff8924e-2a9d-40f8-9e65-576a9baf3c5f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaf03f07-21d4-42cc-b5b5-3ae1e600eaf3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Paddle
        m_Paddle = asset.FindActionMap("Paddle", throwIfNotFound: true);
        m_Paddle_Move = m_Paddle.FindAction("Move", throwIfNotFound: true);
        // GameInputs
        m_GameInputs = asset.FindActionMap("GameInputs", throwIfNotFound: true);
        m_GameInputs_PauseResume = m_GameInputs.FindAction("PauseResume", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Paddle
    private readonly InputActionMap m_Paddle;
    private IPaddleActions m_PaddleActionsCallbackInterface;
    private readonly InputAction m_Paddle_Move;
    public struct PaddleActions
    {
        private @GameInput m_Wrapper;
        public PaddleActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Paddle_Move;
        public InputActionMap Get() { return m_Wrapper.m_Paddle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PaddleActions set) { return set.Get(); }
        public void SetCallbacks(IPaddleActions instance)
        {
            if (m_Wrapper.m_PaddleActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PaddleActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PaddleActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PaddleActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PaddleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PaddleActions @Paddle => new PaddleActions(this);

    // GameInputs
    private readonly InputActionMap m_GameInputs;
    private IGameInputsActions m_GameInputsActionsCallbackInterface;
    private readonly InputAction m_GameInputs_PauseResume;
    public struct GameInputsActions
    {
        private @GameInput m_Wrapper;
        public GameInputsActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseResume => m_Wrapper.m_GameInputs_PauseResume;
        public InputActionMap Get() { return m_Wrapper.m_GameInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameInputsActions set) { return set.Get(); }
        public void SetCallbacks(IGameInputsActions instance)
        {
            if (m_Wrapper.m_GameInputsActionsCallbackInterface != null)
            {
                @PauseResume.started -= m_Wrapper.m_GameInputsActionsCallbackInterface.OnPauseResume;
                @PauseResume.performed -= m_Wrapper.m_GameInputsActionsCallbackInterface.OnPauseResume;
                @PauseResume.canceled -= m_Wrapper.m_GameInputsActionsCallbackInterface.OnPauseResume;
            }
            m_Wrapper.m_GameInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseResume.started += instance.OnPauseResume;
                @PauseResume.performed += instance.OnPauseResume;
                @PauseResume.canceled += instance.OnPauseResume;
            }
        }
    }
    public GameInputsActions @GameInputs => new GameInputsActions(this);
    public interface IPaddleActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IGameInputsActions
    {
        void OnPauseResume(InputAction.CallbackContext context);
    }
}
