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
        },
        {
            ""name"": ""Camera"",
            ""id"": ""ea1fba98-64cb-458c-9a1e-b14597cc54cb"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""beb9a42e-fe42-4371-bd10-197b9b46f0ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""4c7777af-5280-453e-9790-1609176bbfed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""581693b4-3725-4184-ad7f-5b188171285d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""4ba5f2c9-32f6-4685-8304-df391cb71219"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""ea97d59b-e792-4e90-9caa-739d25a511fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""36396e02-197e-44ed-95e5-cd86fe521f22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f55ee483-1bb3-42a2-88a7-10cbba2be183"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83ed9969-d854-4857-a4d8-01837c6f218a"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23903082-af35-4474-8414-ffa4bf8ddfac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""604f69c0-7aac-4f06-a99a-acaed0b27328"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eff7bd46-28a9-480c-b166-2d3782196f33"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c355ac11-e9f0-4d88-8db9-83b21867038a"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Orders"",
            ""id"": ""08912f36-c1dc-40c0-a5df-a8f205026f9a"",
            ""actions"": [
                {
                    ""name"": ""MoveToOrAttack"",
                    ""type"": ""Button"",
                    ""id"": ""3c11cbff-133e-43fc-ad4f-f98b35e67126"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c4b495c5-129b-49d7-b22a-12053be1ade9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveToOrAttack"",
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
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_MousePosition = m_Camera.FindAction("MousePosition", throwIfNotFound: true);
        m_Camera_Forward = m_Camera.FindAction("Forward", throwIfNotFound: true);
        m_Camera_Backward = m_Camera.FindAction("Backward", throwIfNotFound: true);
        m_Camera_Right = m_Camera.FindAction("Right", throwIfNotFound: true);
        m_Camera_Left = m_Camera.FindAction("Left", throwIfNotFound: true);
        m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
        // Orders
        m_Orders = asset.FindActionMap("Orders", throwIfNotFound: true);
        m_Orders_MoveToOrAttack = m_Orders.FindAction("MoveToOrAttack", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_MousePosition;
    private readonly InputAction m_Camera_Forward;
    private readonly InputAction m_Camera_Backward;
    private readonly InputAction m_Camera_Right;
    private readonly InputAction m_Camera_Left;
    private readonly InputAction m_Camera_Zoom;
    public struct CameraActions
    {
        private @GameInputs m_Wrapper;
        public CameraActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Camera_MousePosition;
        public InputAction @Forward => m_Wrapper.m_Camera_Forward;
        public InputAction @Backward => m_Wrapper.m_Camera_Backward;
        public InputAction @Right => m_Wrapper.m_Camera_Right;
        public InputAction @Left => m_Wrapper.m_Camera_Left;
        public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMousePosition;
                @Forward.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnBackward;
                @Right.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLeft;
                @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // Orders
    private readonly InputActionMap m_Orders;
    private IOrdersActions m_OrdersActionsCallbackInterface;
    private readonly InputAction m_Orders_MoveToOrAttack;
    public struct OrdersActions
    {
        private @GameInputs m_Wrapper;
        public OrdersActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveToOrAttack => m_Wrapper.m_Orders_MoveToOrAttack;
        public InputActionMap Get() { return m_Wrapper.m_Orders; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OrdersActions set) { return set.Get(); }
        public void SetCallbacks(IOrdersActions instance)
        {
            if (m_Wrapper.m_OrdersActionsCallbackInterface != null)
            {
                @MoveToOrAttack.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnMoveToOrAttack;
                @MoveToOrAttack.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnMoveToOrAttack;
                @MoveToOrAttack.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnMoveToOrAttack;
            }
            m_Wrapper.m_OrdersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveToOrAttack.started += instance.OnMoveToOrAttack;
                @MoveToOrAttack.performed += instance.OnMoveToOrAttack;
                @MoveToOrAttack.canceled += instance.OnMoveToOrAttack;
            }
        }
    }
    public OrdersActions @Orders => new OrdersActions(this);
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
    public interface ICameraActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface IOrdersActions
    {
        void OnMoveToOrAttack(InputAction.CallbackContext context);
    }
}
