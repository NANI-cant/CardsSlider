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
            ""name"": ""CardDragger"",
            ""id"": ""20bc90a4-6c7d-433f-a319-a2f399bbfcec"",
            ""actions"": [
                {
                    ""name"": ""Take/Drop"",
                    ""type"": ""Button"",
                    ""id"": ""ab7f927c-c710-4c57-8794-91b2de65f6e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dragging"",
                    ""type"": ""Value"",
                    ""id"": ""08c72410-e5b2-499b-9ae5-e54ca8f50864"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Value"",
                    ""id"": ""3ba1df64-bf29-47ed-b08a-6edefc5a5c8b"",
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
                    ""action"": ""Take/Drop"",
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
                    ""action"": ""Dragging"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66828a68-06ca-4b8d-8a62-871c36c4874d"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CardDragger
        m_CardDragger = asset.FindActionMap("CardDragger", throwIfNotFound: true);
        m_CardDragger_TakeDrop = m_CardDragger.FindAction("Take/Drop", throwIfNotFound: true);
        m_CardDragger_Dragging = m_CardDragger.FindAction("Dragging", throwIfNotFound: true);
        m_CardDragger_Slide = m_CardDragger.FindAction("Slide", throwIfNotFound: true);
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

    // CardDragger
    private readonly InputActionMap m_CardDragger;
    private ICardDraggerActions m_CardDraggerActionsCallbackInterface;
    private readonly InputAction m_CardDragger_TakeDrop;
    private readonly InputAction m_CardDragger_Dragging;
    private readonly InputAction m_CardDragger_Slide;
    public struct CardDraggerActions
    {
        private @Inputs m_Wrapper;
        public CardDraggerActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @TakeDrop => m_Wrapper.m_CardDragger_TakeDrop;
        public InputAction @Dragging => m_Wrapper.m_CardDragger_Dragging;
        public InputAction @Slide => m_Wrapper.m_CardDragger_Slide;
        public InputActionMap Get() { return m_Wrapper.m_CardDragger; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CardDraggerActions set) { return set.Get(); }
        public void SetCallbacks(ICardDraggerActions instance)
        {
            if (m_Wrapper.m_CardDraggerActionsCallbackInterface != null)
            {
                @TakeDrop.started -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnTakeDrop;
                @TakeDrop.performed -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnTakeDrop;
                @TakeDrop.canceled -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnTakeDrop;
                @Dragging.started -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnDragging;
                @Dragging.performed -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnDragging;
                @Dragging.canceled -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnDragging;
                @Slide.started -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_CardDraggerActionsCallbackInterface.OnSlide;
            }
            m_Wrapper.m_CardDraggerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TakeDrop.started += instance.OnTakeDrop;
                @TakeDrop.performed += instance.OnTakeDrop;
                @TakeDrop.canceled += instance.OnTakeDrop;
                @Dragging.started += instance.OnDragging;
                @Dragging.performed += instance.OnDragging;
                @Dragging.canceled += instance.OnDragging;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
            }
        }
    }
    public CardDraggerActions @CardDragger => new CardDraggerActions(this);
    public interface ICardDraggerActions
    {
        void OnTakeDrop(InputAction.CallbackContext context);
        void OnDragging(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
    }
}
