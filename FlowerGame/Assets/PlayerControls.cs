//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f2f82495-5291-4f34-80ad-59ffa1bb9111"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0d3ab950-b60c-48af-ac4b-b82cada40130"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""71232a99-b828-4931-88f5-dd067680e60d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""61392599-e88c-4bd6-89b5-af80eda0f730"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""e53e9ef8-a004-448a-9aec-b97a699023f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PutDown"",
                    ""type"": ""Button"",
                    ""id"": ""79a36a6c-36c3-400b-85cc-7fb9209a4076"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Harvest"",
                    ""type"": ""Button"",
                    ""id"": ""cd349799-7894-488a-81af-e5f07a4cb5ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3473efe2-9ea8-4401-998f-7472e1bb2060"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cf422953-d86d-4200-b978-a8503cc57e5f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9aaffaed-cd55-4b01-b0c8-c73245a2cc63"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d40817d6-0977-4545-ba3a-aa074b283133"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""05bf126a-cd35-4910-97b6-539cb9a68b39"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""96944d24-dc10-48da-a29b-49cb87de1866"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ca2a00-13b8-4da0-ac83-df9d796a063b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5db6dd4-f2ef-4771-a763-79c14842bd78"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e562a0eb-d2ba-4f41-a927-e7ddbcd05ce3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PutDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9bbf2d7-41a5-4505-bfd1-daf4ad8e2986"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Harvest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerArrangement"",
            ""id"": ""f288a5c3-8e41-407c-956a-60540edf1497"",
            ""actions"": [
                {
                    ""name"": ""Mouse Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2f714684-7f73-4e3e-b5fc-b189bb8701fb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""5c085a7e-ef89-488c-b5e3-99761d354d2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.01)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateSelected"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2c28856f-5cc8-42f1-bb3f-8af5adfd6ec5"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ResetSelectedRotation"",
                    ""type"": ""Button"",
                    ""id"": ""c5071363-ebbe-4f4a-9b15-fcf533e663c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""50698a05-8ed1-49bc-9fda-d38e73b541c2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac0d904d-0551-41d0-ac74-d158a7977214"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""6bdfca73-eafd-405b-aa34-e1942d6b8d82"",
                    ""path"": ""3DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8b845288-54a8-4235-8c16-5d6baeeaabac"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""771bf183-973a-4974-817f-30e5d5935e51"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ff3c2217-abd4-45a4-b7f1-a744fed9b809"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""520231b1-64a4-4818-8c12-133cc8cf87cc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""fe80627b-af8c-42f8-b5f2-f6c8963e03f6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""2f0adeaf-020e-4fb6-b31e-b3c861c2b6aa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bf791630-a78d-4d72-92d0-ec38b249dc8f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetSelectedRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21e95fda-26a2-476a-b96f-73e9ffe797fd"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetSelectedRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_PickUp = m_Player.FindAction("PickUp", throwIfNotFound: true);
        m_Player_PutDown = m_Player.FindAction("PutDown", throwIfNotFound: true);
        m_Player_Harvest = m_Player.FindAction("Harvest", throwIfNotFound: true);
        // PlayerArrangement
        m_PlayerArrangement = asset.FindActionMap("PlayerArrangement", throwIfNotFound: true);
        m_PlayerArrangement_MouseMovement = m_PlayerArrangement.FindAction("Mouse Movement", throwIfNotFound: true);
        m_PlayerArrangement_Select = m_PlayerArrangement.FindAction("Select", throwIfNotFound: true);
        m_PlayerArrangement_RotateSelected = m_PlayerArrangement.FindAction("RotateSelected", throwIfNotFound: true);
        m_PlayerArrangement_ResetSelectedRotation = m_PlayerArrangement.FindAction("ResetSelectedRotation", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_PickUp;
    private readonly InputAction m_Player_PutDown;
    private readonly InputAction m_Player_Harvest;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @PickUp => m_Wrapper.m_Player_PickUp;
        public InputAction @PutDown => m_Wrapper.m_Player_PutDown;
        public InputAction @Harvest => m_Wrapper.m_Player_Harvest;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @PickUp.started += instance.OnPickUp;
            @PickUp.performed += instance.OnPickUp;
            @PickUp.canceled += instance.OnPickUp;
            @PutDown.started += instance.OnPutDown;
            @PutDown.performed += instance.OnPutDown;
            @PutDown.canceled += instance.OnPutDown;
            @Harvest.started += instance.OnHarvest;
            @Harvest.performed += instance.OnHarvest;
            @Harvest.canceled += instance.OnHarvest;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @PickUp.started -= instance.OnPickUp;
            @PickUp.performed -= instance.OnPickUp;
            @PickUp.canceled -= instance.OnPickUp;
            @PutDown.started -= instance.OnPutDown;
            @PutDown.performed -= instance.OnPutDown;
            @PutDown.canceled -= instance.OnPutDown;
            @Harvest.started -= instance.OnHarvest;
            @Harvest.performed -= instance.OnHarvest;
            @Harvest.canceled -= instance.OnHarvest;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // PlayerArrangement
    private readonly InputActionMap m_PlayerArrangement;
    private List<IPlayerArrangementActions> m_PlayerArrangementActionsCallbackInterfaces = new List<IPlayerArrangementActions>();
    private readonly InputAction m_PlayerArrangement_MouseMovement;
    private readonly InputAction m_PlayerArrangement_Select;
    private readonly InputAction m_PlayerArrangement_RotateSelected;
    private readonly InputAction m_PlayerArrangement_ResetSelectedRotation;
    public struct PlayerArrangementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerArrangementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseMovement => m_Wrapper.m_PlayerArrangement_MouseMovement;
        public InputAction @Select => m_Wrapper.m_PlayerArrangement_Select;
        public InputAction @RotateSelected => m_Wrapper.m_PlayerArrangement_RotateSelected;
        public InputAction @ResetSelectedRotation => m_Wrapper.m_PlayerArrangement_ResetSelectedRotation;
        public InputActionMap Get() { return m_Wrapper.m_PlayerArrangement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerArrangementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerArrangementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerArrangementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerArrangementActionsCallbackInterfaces.Add(instance);
            @MouseMovement.started += instance.OnMouseMovement;
            @MouseMovement.performed += instance.OnMouseMovement;
            @MouseMovement.canceled += instance.OnMouseMovement;
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @RotateSelected.started += instance.OnRotateSelected;
            @RotateSelected.performed += instance.OnRotateSelected;
            @RotateSelected.canceled += instance.OnRotateSelected;
            @ResetSelectedRotation.started += instance.OnResetSelectedRotation;
            @ResetSelectedRotation.performed += instance.OnResetSelectedRotation;
            @ResetSelectedRotation.canceled += instance.OnResetSelectedRotation;
        }

        private void UnregisterCallbacks(IPlayerArrangementActions instance)
        {
            @MouseMovement.started -= instance.OnMouseMovement;
            @MouseMovement.performed -= instance.OnMouseMovement;
            @MouseMovement.canceled -= instance.OnMouseMovement;
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @RotateSelected.started -= instance.OnRotateSelected;
            @RotateSelected.performed -= instance.OnRotateSelected;
            @RotateSelected.canceled -= instance.OnRotateSelected;
            @ResetSelectedRotation.started -= instance.OnResetSelectedRotation;
            @ResetSelectedRotation.performed -= instance.OnResetSelectedRotation;
            @ResetSelectedRotation.canceled -= instance.OnResetSelectedRotation;
        }

        public void RemoveCallbacks(IPlayerArrangementActions instance)
        {
            if (m_Wrapper.m_PlayerArrangementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerArrangementActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerArrangementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerArrangementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerArrangementActions @PlayerArrangement => new PlayerArrangementActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnPutDown(InputAction.CallbackContext context);
        void OnHarvest(InputAction.CallbackContext context);
    }
    public interface IPlayerArrangementActions
    {
        void OnMouseMovement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnRotateSelected(InputAction.CallbackContext context);
        void OnResetSelectedRotation(InputAction.CallbackContext context);
    }
}
