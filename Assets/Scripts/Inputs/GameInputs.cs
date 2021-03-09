// GENERATED AUTOMATICALLY FROM 'Assets/Databases/Inputs_Actions/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""1db53977-1f0c-4322-9e90-3f2dff6269b7"",
            ""actions"": [
                {
                    ""name"": ""SelectEntity"",
                    ""type"": ""Button"",
                    ""id"": ""2fec0ec1-fc61-4254-a9c8-f6b32bcd44af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartSelectionRectangle"",
                    ""type"": ""Button"",
                    ""id"": ""c33b29a2-f664-47e6-bcce-5f1c903415ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EndSelectionRectangle"",
                    ""type"": ""Button"",
                    ""id"": ""9821828c-1ad5-4a5a-9467-16768e68bf04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c330169-dd3c-4c2e-81be-d9917817d339"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectEntity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c68f7eb3-bfee-489d-9763-3e8a8701a24f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartSelectionRectangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de9ab0c0-4086-481a-ac2d-42c987af0263"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndSelectionRectangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_SelectEntity = m_Player.FindAction("SelectEntity", throwIfNotFound: true);
        m_Player_StartSelectionRectangle = m_Player.FindAction("StartSelectionRectangle", throwIfNotFound: true);
        m_Player_EndSelectionRectangle = m_Player.FindAction("EndSelectionRectangle", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_SelectEntity;
    private readonly InputAction m_Player_StartSelectionRectangle;
    private readonly InputAction m_Player_EndSelectionRectangle;
    public struct PlayerActions
    {
        private @GameInputs m_Wrapper;
        public PlayerActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectEntity => m_Wrapper.m_Player_SelectEntity;
        public InputAction @StartSelectionRectangle => m_Wrapper.m_Player_StartSelectionRectangle;
        public InputAction @EndSelectionRectangle => m_Wrapper.m_Player_EndSelectionRectangle;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @SelectEntity.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectEntity;
                @SelectEntity.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectEntity;
                @SelectEntity.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectEntity;
                @StartSelectionRectangle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartSelectionRectangle;
                @StartSelectionRectangle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartSelectionRectangle;
                @StartSelectionRectangle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartSelectionRectangle;
                @EndSelectionRectangle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEndSelectionRectangle;
                @EndSelectionRectangle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEndSelectionRectangle;
                @EndSelectionRectangle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEndSelectionRectangle;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectEntity.started += instance.OnSelectEntity;
                @SelectEntity.performed += instance.OnSelectEntity;
                @SelectEntity.canceled += instance.OnSelectEntity;
                @StartSelectionRectangle.started += instance.OnStartSelectionRectangle;
                @StartSelectionRectangle.performed += instance.OnStartSelectionRectangle;
                @StartSelectionRectangle.canceled += instance.OnStartSelectionRectangle;
                @EndSelectionRectangle.started += instance.OnEndSelectionRectangle;
                @EndSelectionRectangle.performed += instance.OnEndSelectionRectangle;
                @EndSelectionRectangle.canceled += instance.OnEndSelectionRectangle;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnSelectEntity(InputAction.CallbackContext context);
        void OnStartSelectionRectangle(InputAction.CallbackContext context);
        void OnEndSelectionRectangle(InputAction.CallbackContext context);
    }
}
