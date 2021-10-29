// GENERATED AUTOMATICALLY FROM 'Assets/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""CardSlider"",
            ""id"": ""20bc90a4-6c7d-433f-a319-a2f399bbfcec"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""ab7f927c-c710-4c57-8794-91b2de65f6e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapPosition"",
                    ""type"": ""Value"",
                    ""id"": ""08c72410-e5b2-499b-9ae5-e54ca8f50864"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapRadius"",
                    ""type"": ""Value"",
                    ""id"": ""6c608b9a-7e12-4cab-84c8-78d13288f862"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapDelta"",
                    ""type"": ""Value"",
                    ""id"": ""4d105780-565e-48b3-92a5-efcb6c3cdb2c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8b8d1acb-ba33-42cb-9ea5-4673e04d45ef"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a783828-fc64-43dd-8141-ba408ca18632"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb6f7f01-f575-4839-9290-d0c087190dde"",
                    ""path"": ""<Pointer>/radius"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapRadius"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f22e26fa-330e-4218-a0bb-a8788c004f68"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CardSlider
        m_CardSlider = asset.FindActionMap("CardSlider", throwIfNotFound: true);
        m_CardSlider_Tap = m_CardSlider.FindAction("Tap", throwIfNotFound: true);
        m_CardSlider_TapPosition = m_CardSlider.FindAction("TapPosition", throwIfNotFound: true);
        m_CardSlider_TapRadius = m_CardSlider.FindAction("TapRadius", throwIfNotFound: true);
        m_CardSlider_TapDelta = m_CardSlider.FindAction("TapDelta", throwIfNotFound: true);
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

    // CardSlider
    private readonly InputActionMap m_CardSlider;
    private ICardSliderActions m_CardSliderActionsCallbackInterface;
    private readonly InputAction m_CardSlider_Tap;
    private readonly InputAction m_CardSlider_TapPosition;
    private readonly InputAction m_CardSlider_TapRadius;
    private readonly InputAction m_CardSlider_TapDelta;
    public struct CardSliderActions
    {
        private @Inputs m_Wrapper;
        public CardSliderActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_CardSlider_Tap;
        public InputAction @TapPosition => m_Wrapper.m_CardSlider_TapPosition;
        public InputAction @TapRadius => m_Wrapper.m_CardSlider_TapRadius;
        public InputAction @TapDelta => m_Wrapper.m_CardSlider_TapDelta;
        public InputActionMap Get() { return m_Wrapper.m_CardSlider; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CardSliderActions set) { return set.Get(); }
        public void SetCallbacks(ICardSliderActions instance)
        {
            if (m_Wrapper.m_CardSliderActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTap;
                @TapPosition.started -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapPosition;
                @TapPosition.performed -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapPosition;
                @TapPosition.canceled -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapPosition;
                @TapRadius.started -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapRadius;
                @TapRadius.performed -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapRadius;
                @TapRadius.canceled -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapRadius;
                @TapDelta.started -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapDelta;
                @TapDelta.performed -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapDelta;
                @TapDelta.canceled -= m_Wrapper.m_CardSliderActionsCallbackInterface.OnTapDelta;
            }
            m_Wrapper.m_CardSliderActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @TapPosition.started += instance.OnTapPosition;
                @TapPosition.performed += instance.OnTapPosition;
                @TapPosition.canceled += instance.OnTapPosition;
                @TapRadius.started += instance.OnTapRadius;
                @TapRadius.performed += instance.OnTapRadius;
                @TapRadius.canceled += instance.OnTapRadius;
                @TapDelta.started += instance.OnTapDelta;
                @TapDelta.performed += instance.OnTapDelta;
                @TapDelta.canceled += instance.OnTapDelta;
            }
        }
    }
    public CardSliderActions @CardSlider => new CardSliderActions(this);
    public interface ICardSliderActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnTapPosition(InputAction.CallbackContext context);
        void OnTapRadius(InputAction.CallbackContext context);
        void OnTapDelta(InputAction.CallbackContext context);
    }
}
