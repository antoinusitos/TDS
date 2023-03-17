//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Data/GameInput.inputactions
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

public partial class @GameInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""d6467d90-fe1e-485b-8c65-5fde679a92f0"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""35d92008-b6e5-4a6b-aedc-944892bcf912"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""8ba1d6a4-638f-4ddb-8d81-02727825d1b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7193b534-0e3c-44a2-9279-f70f2e8e9593"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3ea18e82-3b03-4f72-ba1a-5175a6200833"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BigAttack"",
                    ""type"": ""Button"",
                    ""id"": ""790d7d03-62a4-4982-8153-a588d1d25b37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""f9d1f095-b3cc-4261-a5e0-d5c7d38d0633"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item0"",
                    ""type"": ""Button"",
                    ""id"": ""1438f125-7acf-4cda-838f-505e3100bd01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item1"",
                    ""type"": ""Button"",
                    ""id"": ""57592137-48a1-48f9-9f87-2eacd2c65e87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Button"",
                    ""id"": ""813762a2-d678-4cf8-9abf-f7f9e3b6ff4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item3"",
                    ""type"": ""Button"",
                    ""id"": ""6f0b0e8f-0ca8-4301-aec6-c4b3d674c692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""8eb4a3e1-d997-4a1a-b042-7c61d774288e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""2d50cdfe-c24a-4c11-be2a-89ad3bf8a9bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""3b74c25e-5299-4672-bc05-244accded9de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Parry"",
                    ""type"": ""Button"",
                    ""id"": ""4f22ca63-a044-4107-a700-097df1ea99a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""685d6bd7-0eef-4de6-9f0b-a172fb6e2dec"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""60442532-0346-4029-9aa9-197d9c08968a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a3c9e6b0-d7d4-4df9-8b40-4e9eff977e41"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9282bdf0-00ae-409b-a198-181b00eb89f9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b1371c64-0b6e-43ae-908d-2f8aa6b6f760"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2e4322ce-65d5-4db4-a3e1-50dcf46d9e14"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4328663d-cf0f-4155-9f5f-21e4f1730b20"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cdf76ced-882d-4fac-b28d-e05b116d1ab4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c43bcdfb-f37e-4180-8b6d-f713e9d44700"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c8baa552-aadf-4262-9035-8844de1c4c36"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""22adaf8c-8a07-433d-8544-ccefea56abfc"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""76be35b8-5f51-4305-a7f9-2bb4e263ba12"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""42f88101-b2d9-46f1-892c-83f773d45b36"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2b70253-9e19-4f9d-b07c-6678d5762070"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b9e248a-9a1c-462c-abd9-93d92caf2643"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e82fde73-f057-4848-a9a4-0c3c5b5d79ad"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2538b876-7977-4030-85cc-5bf8a47eb24c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7d76476-2e3c-42ea-bb9d-b3cb3e30c7c6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f6102ea-7428-4ff4-8e1b-521acde0c0e6"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99f809ce-e126-4d43-86d1-a54bc54b88de"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""841479df-d446-44b7-8139-54b6a9659222"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0cbbd65-cb9f-436a-bbc3-0a91b28f359e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3307bfb3-6708-43e3-aeef-babf3b579705"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c92bbf-ed3d-4413-8280-b794523607d5"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b37877cc-c62a-43ea-97a3-31368bcf3f79"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a78cf74-d6e3-4b06-855e-77dc8031b022"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04e70132-a61e-4a67-8838-ed16861e831c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e18f4e51-ab89-49f3-bd07-2ed383b0af4b"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3092b759-c3dc-4346-b688-ab4284e77e87"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BigAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad71e2d5-357d-458d-ac39-a9ecc3e3459c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BigAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cb5bfc3-a9bc-4979-a157-0df63228efd2"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57c15f70-3989-4382-a6e6-d782b9429267"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd9873a6-ad98-48c3-b355-8865905108ba"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7ed67c8-9224-4c53-ab72-b253bfffad53"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bec832b9-b287-4c19-a40e-c178693c8ffd"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c4d2fa6-9d8e-423c-be30-e03a44892817"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Forward = m_PlayerInput.FindAction("Forward", throwIfNotFound: true);
        m_PlayerInput_Right = m_PlayerInput.FindAction("Right", throwIfNotFound: true);
        m_PlayerInput_Interact = m_PlayerInput.FindAction("Interact", throwIfNotFound: true);
        m_PlayerInput_Attack = m_PlayerInput.FindAction("Attack", throwIfNotFound: true);
        m_PlayerInput_BigAttack = m_PlayerInput.FindAction("BigAttack", throwIfNotFound: true);
        m_PlayerInput_Cancel = m_PlayerInput.FindAction("Cancel", throwIfNotFound: true);
        m_PlayerInput_Item0 = m_PlayerInput.FindAction("Item0", throwIfNotFound: true);
        m_PlayerInput_Item1 = m_PlayerInput.FindAction("Item1", throwIfNotFound: true);
        m_PlayerInput_Item2 = m_PlayerInput.FindAction("Item2", throwIfNotFound: true);
        m_PlayerInput_Item3 = m_PlayerInput.FindAction("Item3", throwIfNotFound: true);
        m_PlayerInput_Target = m_PlayerInput.FindAction("Target", throwIfNotFound: true);
        m_PlayerInput_Menu = m_PlayerInput.FindAction("Menu", throwIfNotFound: true);
        m_PlayerInput_Dash = m_PlayerInput.FindAction("Dash", throwIfNotFound: true);
        m_PlayerInput_Parry = m_PlayerInput.FindAction("Parry", throwIfNotFound: true);
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

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_Forward;
    private readonly InputAction m_PlayerInput_Right;
    private readonly InputAction m_PlayerInput_Interact;
    private readonly InputAction m_PlayerInput_Attack;
    private readonly InputAction m_PlayerInput_BigAttack;
    private readonly InputAction m_PlayerInput_Cancel;
    private readonly InputAction m_PlayerInput_Item0;
    private readonly InputAction m_PlayerInput_Item1;
    private readonly InputAction m_PlayerInput_Item2;
    private readonly InputAction m_PlayerInput_Item3;
    private readonly InputAction m_PlayerInput_Target;
    private readonly InputAction m_PlayerInput_Menu;
    private readonly InputAction m_PlayerInput_Dash;
    private readonly InputAction m_PlayerInput_Parry;
    public struct PlayerInputActions
    {
        private @GameInput m_Wrapper;
        public PlayerInputActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_PlayerInput_Forward;
        public InputAction @Right => m_Wrapper.m_PlayerInput_Right;
        public InputAction @Interact => m_Wrapper.m_PlayerInput_Interact;
        public InputAction @Attack => m_Wrapper.m_PlayerInput_Attack;
        public InputAction @BigAttack => m_Wrapper.m_PlayerInput_BigAttack;
        public InputAction @Cancel => m_Wrapper.m_PlayerInput_Cancel;
        public InputAction @Item0 => m_Wrapper.m_PlayerInput_Item0;
        public InputAction @Item1 => m_Wrapper.m_PlayerInput_Item1;
        public InputAction @Item2 => m_Wrapper.m_PlayerInput_Item2;
        public InputAction @Item3 => m_Wrapper.m_PlayerInput_Item3;
        public InputAction @Target => m_Wrapper.m_PlayerInput_Target;
        public InputAction @Menu => m_Wrapper.m_PlayerInput_Menu;
        public InputAction @Dash => m_Wrapper.m_PlayerInput_Dash;
        public InputAction @Parry => m_Wrapper.m_PlayerInput_Parry;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnForward;
                @Right.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRight;
                @Interact.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnAttack;
                @BigAttack.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnBigAttack;
                @BigAttack.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnBigAttack;
                @BigAttack.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnBigAttack;
                @Cancel.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCancel;
                @Item0.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem0;
                @Item0.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem0;
                @Item0.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem0;
                @Item1.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem1;
                @Item1.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem1;
                @Item1.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem1;
                @Item2.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem2;
                @Item2.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem2;
                @Item2.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem2;
                @Item3.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem3;
                @Item3.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem3;
                @Item3.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnItem3;
                @Target.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTarget;
                @Menu.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMenu;
                @Dash.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnDash;
                @Parry.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnParry;
                @Parry.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnParry;
                @Parry.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnParry;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @BigAttack.started += instance.OnBigAttack;
                @BigAttack.performed += instance.OnBigAttack;
                @BigAttack.canceled += instance.OnBigAttack;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Item0.started += instance.OnItem0;
                @Item0.performed += instance.OnItem0;
                @Item0.canceled += instance.OnItem0;
                @Item1.started += instance.OnItem1;
                @Item1.performed += instance.OnItem1;
                @Item1.canceled += instance.OnItem1;
                @Item2.started += instance.OnItem2;
                @Item2.performed += instance.OnItem2;
                @Item2.canceled += instance.OnItem2;
                @Item3.started += instance.OnItem3;
                @Item3.performed += instance.OnItem3;
                @Item3.canceled += instance.OnItem3;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Parry.started += instance.OnParry;
                @Parry.performed += instance.OnParry;
                @Parry.canceled += instance.OnParry;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayerInputActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnBigAttack(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnItem0(InputAction.CallbackContext context);
        void OnItem1(InputAction.CallbackContext context);
        void OnItem2(InputAction.CallbackContext context);
        void OnItem3(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnParry(InputAction.CallbackContext context);
    }
}
