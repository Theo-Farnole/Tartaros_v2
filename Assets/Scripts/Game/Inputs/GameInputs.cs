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
            ""name"": ""Selection"",
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
                },
                {
                    ""name"": ""EnableAdditiveSelection"",
                    ""type"": ""Button"",
                    ""id"": ""c1cce685-3c57-4d03-9117-3e402595bb40"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""30b5de86-63e6-4694-b84d-4463ac4f6ea0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnableAdditiveSelection"",
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
                    ""id"": ""798588e1-7fab-4852-a70f-123132bb43e1"",
                    ""path"": ""<Keyboard>/upArrow"",
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
                    ""id"": ""ef49fc8b-b405-4013-a441-90744b601940"",
                    ""path"": ""<Keyboard>/downArrow"",
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
                    ""id"": ""6d910198-8db6-4bcb-9925-6a6428f853c1"",
                    ""path"": ""<Keyboard>/rightArrow"",
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
                    ""id"": ""1c355850-cfac-4cc0-96be-bc2bcbc38a1e"",
                    ""path"": ""<Keyboard>/leftArrow"",
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
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""3068a7cc-b1ba-4ef4-8bfb-959a0a06163c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c4b495c5-129b-49d7-b22a-12053be1ade9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveToOrAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af856233-7b49-40bc-b3f6-7cdcfce7c5ca"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Construction"",
            ""id"": ""d917b864-b3e9-44aa-b098-f9df615e47e2"",
            ""actions"": [
                {
                    ""name"": ""EnterConstruction"",
                    ""type"": ""Button"",
                    ""id"": ""100c7992-e6c2-4d11-a02b-a5d20c7daa41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ValidateConstruction"",
                    ""type"": ""Button"",
                    ""id"": ""75c8d75a-18f1-4fa1-b65d-bc7d5b9a2a67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitConstruction"",
                    ""type"": ""Button"",
                    ""id"": ""256fde4f-7cec-4d3a-87c3-8b1f478a4d26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddNewWallSections"",
                    ""type"": ""Button"",
                    ""id"": ""c0a3bd7a-fb93-4164-8c75-e207f4200cf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""33a757ec-b2ae-4e24-b408-19f6a0b5b78a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterConstruction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91cb0233-9f0d-4fc4-aa79-7bcf664a7d3f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ValidateConstruction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32b92bdb-1423-4a54-9f67-e8aae1e8436a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitConstruction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""612db67f-f688-4bf9-8c96-8f71e1cb9140"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddNewWallSections"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""c0c73167-9c46-44da-83d7-b09e34d72ac9"",
            ""actions"": [
                {
                    ""name"": ""NextSpeech"",
                    ""type"": ""Button"",
                    ""id"": ""9243637b-622f-46ad-92f6-1c212020768d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66c983a7-a269-4188-b25f-df88f4eaae10"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextSpeech"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c43abdc8-873b-4f72-8de3-fe71db10fd6e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextSpeech"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97128086-6a36-4162-bb33-fcbd57740356"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextSpeech"",
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
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_SelectEntity = m_Selection.FindAction("SelectEntity", throwIfNotFound: true);
        m_Selection_StartSelectionRectangle = m_Selection.FindAction("StartSelectionRectangle", throwIfNotFound: true);
        m_Selection_EndSelectionRectangle = m_Selection.FindAction("EndSelectionRectangle", throwIfNotFound: true);
        m_Selection_EnableAdditiveSelection = m_Selection.FindAction("EnableAdditiveSelection", throwIfNotFound: true);
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
        m_Orders_RightClick = m_Orders.FindAction("RightClick", throwIfNotFound: true);
        // Construction
        m_Construction = asset.FindActionMap("Construction", throwIfNotFound: true);
        m_Construction_EnterConstruction = m_Construction.FindAction("EnterConstruction", throwIfNotFound: true);
        m_Construction_ValidateConstruction = m_Construction.FindAction("ValidateConstruction", throwIfNotFound: true);
        m_Construction_ExitConstruction = m_Construction.FindAction("ExitConstruction", throwIfNotFound: true);
        m_Construction_AddNewWallSections = m_Construction.FindAction("AddNewWallSections", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_NextSpeech = m_Dialogue.FindAction("NextSpeech", throwIfNotFound: true);
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

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_SelectEntity;
    private readonly InputAction m_Selection_StartSelectionRectangle;
    private readonly InputAction m_Selection_EndSelectionRectangle;
    private readonly InputAction m_Selection_EnableAdditiveSelection;
    public struct SelectionActions
    {
        private @GameInputs m_Wrapper;
        public SelectionActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectEntity => m_Wrapper.m_Selection_SelectEntity;
        public InputAction @StartSelectionRectangle => m_Wrapper.m_Selection_StartSelectionRectangle;
        public InputAction @EndSelectionRectangle => m_Wrapper.m_Selection_EndSelectionRectangle;
        public InputAction @EnableAdditiveSelection => m_Wrapper.m_Selection_EnableAdditiveSelection;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterface != null)
            {
                @SelectEntity.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnSelectEntity;
                @SelectEntity.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnSelectEntity;
                @SelectEntity.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnSelectEntity;
                @StartSelectionRectangle.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnStartSelectionRectangle;
                @StartSelectionRectangle.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnStartSelectionRectangle;
                @StartSelectionRectangle.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnStartSelectionRectangle;
                @EndSelectionRectangle.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEndSelectionRectangle;
                @EndSelectionRectangle.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEndSelectionRectangle;
                @EndSelectionRectangle.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEndSelectionRectangle;
                @EnableAdditiveSelection.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEnableAdditiveSelection;
                @EnableAdditiveSelection.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEnableAdditiveSelection;
                @EnableAdditiveSelection.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEnableAdditiveSelection;
            }
            m_Wrapper.m_SelectionActionsCallbackInterface = instance;
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
                @EnableAdditiveSelection.started += instance.OnEnableAdditiveSelection;
                @EnableAdditiveSelection.performed += instance.OnEnableAdditiveSelection;
                @EnableAdditiveSelection.canceled += instance.OnEnableAdditiveSelection;
            }
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);

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
    private readonly InputAction m_Orders_RightClick;
    public struct OrdersActions
    {
        private @GameInputs m_Wrapper;
        public OrdersActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveToOrAttack => m_Wrapper.m_Orders_MoveToOrAttack;
        public InputAction @RightClick => m_Wrapper.m_Orders_RightClick;
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
                @RightClick.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_OrdersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveToOrAttack.started += instance.OnMoveToOrAttack;
                @MoveToOrAttack.performed += instance.OnMoveToOrAttack;
                @MoveToOrAttack.canceled += instance.OnMoveToOrAttack;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public OrdersActions @Orders => new OrdersActions(this);

    // Construction
    private readonly InputActionMap m_Construction;
    private IConstructionActions m_ConstructionActionsCallbackInterface;
    private readonly InputAction m_Construction_EnterConstruction;
    private readonly InputAction m_Construction_ValidateConstruction;
    private readonly InputAction m_Construction_ExitConstruction;
    private readonly InputAction m_Construction_AddNewWallSections;
    public struct ConstructionActions
    {
        private @GameInputs m_Wrapper;
        public ConstructionActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnterConstruction => m_Wrapper.m_Construction_EnterConstruction;
        public InputAction @ValidateConstruction => m_Wrapper.m_Construction_ValidateConstruction;
        public InputAction @ExitConstruction => m_Wrapper.m_Construction_ExitConstruction;
        public InputAction @AddNewWallSections => m_Wrapper.m_Construction_AddNewWallSections;
        public InputActionMap Get() { return m_Wrapper.m_Construction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConstructionActions set) { return set.Get(); }
        public void SetCallbacks(IConstructionActions instance)
        {
            if (m_Wrapper.m_ConstructionActionsCallbackInterface != null)
            {
                @EnterConstruction.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnEnterConstruction;
                @EnterConstruction.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnEnterConstruction;
                @EnterConstruction.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnEnterConstruction;
                @ValidateConstruction.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnValidateConstruction;
                @ValidateConstruction.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnValidateConstruction;
                @ValidateConstruction.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnValidateConstruction;
                @ExitConstruction.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnExitConstruction;
                @ExitConstruction.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnExitConstruction;
                @ExitConstruction.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnExitConstruction;
                @AddNewWallSections.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnAddNewWallSections;
                @AddNewWallSections.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnAddNewWallSections;
                @AddNewWallSections.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnAddNewWallSections;
            }
            m_Wrapper.m_ConstructionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EnterConstruction.started += instance.OnEnterConstruction;
                @EnterConstruction.performed += instance.OnEnterConstruction;
                @EnterConstruction.canceled += instance.OnEnterConstruction;
                @ValidateConstruction.started += instance.OnValidateConstruction;
                @ValidateConstruction.performed += instance.OnValidateConstruction;
                @ValidateConstruction.canceled += instance.OnValidateConstruction;
                @ExitConstruction.started += instance.OnExitConstruction;
                @ExitConstruction.performed += instance.OnExitConstruction;
                @ExitConstruction.canceled += instance.OnExitConstruction;
                @AddNewWallSections.started += instance.OnAddNewWallSections;
                @AddNewWallSections.performed += instance.OnAddNewWallSections;
                @AddNewWallSections.canceled += instance.OnAddNewWallSections;
            }
        }
    }
    public ConstructionActions @Construction => new ConstructionActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private IDialogueActions m_DialogueActionsCallbackInterface;
    private readonly InputAction m_Dialogue_NextSpeech;
    public struct DialogueActions
    {
        private @GameInputs m_Wrapper;
        public DialogueActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextSpeech => m_Wrapper.m_Dialogue_NextSpeech;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
            {
                @NextSpeech.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNextSpeech;
                @NextSpeech.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNextSpeech;
                @NextSpeech.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNextSpeech;
            }
            m_Wrapper.m_DialogueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextSpeech.started += instance.OnNextSpeech;
                @NextSpeech.performed += instance.OnNextSpeech;
                @NextSpeech.canceled += instance.OnNextSpeech;
            }
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
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
    public interface ISelectionActions
    {
        void OnSelectEntity(InputAction.CallbackContext context);
        void OnStartSelectionRectangle(InputAction.CallbackContext context);
        void OnEndSelectionRectangle(InputAction.CallbackContext context);
        void OnEnableAdditiveSelection(InputAction.CallbackContext context);
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
        void OnRightClick(InputAction.CallbackContext context);
    }
    public interface IConstructionActions
    {
        void OnEnterConstruction(InputAction.CallbackContext context);
        void OnValidateConstruction(InputAction.CallbackContext context);
        void OnExitConstruction(InputAction.CallbackContext context);
        void OnAddNewWallSections(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnNextSpeech(InputAction.CallbackContext context);
    }
}
