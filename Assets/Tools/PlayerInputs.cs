//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Tools/PlayerInputs.inputactions
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

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""acf59eec-d75e-4e2b-bd05-d28dca1a145a"",
            ""actions"": [
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""c4c79f5a-50eb-4d27-9403-484cd1c15052"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DOWN"",
                    ""type"": ""Button"",
                    ""id"": ""f189ed42-00c2-4279-945e-3bf029d3640a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""fd1da6ab-1fb0-49de-bfa0-2e983acf828e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4a73d643-f4d6-46a8-903e-d3f0744ca3f3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac36cd47-919a-4f5f-9476-efcb96bc420c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab30eb4e-2c17-4fbd-a444-b3a354310a48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91127568-1335-4c4f-82a8-1c3554f89e69"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""814ab8c8-54a8-45bd-999f-40e398694cca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a46b1c69-a5bb-4aea-94fe-aec807d4a332"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
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
        m_Player_UP = m_Player.FindAction("UP", throwIfNotFound: true);
        m_Player_DOWN = m_Player.FindAction("DOWN", throwIfNotFound: true);
        m_Player_RIGHT = m_Player.FindAction("RIGHT", throwIfNotFound: true);
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
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_UP;
    private readonly InputAction m_Player_DOWN;
    private readonly InputAction m_Player_RIGHT;
    public struct PlayerActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @UP => m_Wrapper.m_Player_UP;
        public InputAction @DOWN => m_Wrapper.m_Player_DOWN;
        public InputAction @RIGHT => m_Wrapper.m_Player_RIGHT;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @UP.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUP;
                @UP.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUP;
                @UP.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUP;
                @DOWN.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDOWN;
                @DOWN.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDOWN;
                @DOWN.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDOWN;
                @RIGHT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRIGHT;
                @RIGHT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRIGHT;
                @RIGHT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRIGHT;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UP.started += instance.OnUP;
                @UP.performed += instance.OnUP;
                @UP.canceled += instance.OnUP;
                @DOWN.started += instance.OnDOWN;
                @DOWN.performed += instance.OnDOWN;
                @DOWN.canceled += instance.OnDOWN;
                @RIGHT.started += instance.OnRIGHT;
                @RIGHT.performed += instance.OnRIGHT;
                @RIGHT.canceled += instance.OnRIGHT;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnUP(InputAction.CallbackContext context);
        void OnDOWN(InputAction.CallbackContext context);
        void OnRIGHT(InputAction.CallbackContext context);
    }
}
