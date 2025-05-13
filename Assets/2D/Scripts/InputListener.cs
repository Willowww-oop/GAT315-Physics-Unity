using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
	[SerializeField] InputActionSO inputEvent;

	[Header("Unity Events")]
	public UnityEvent<Vector2> OnVector2Input;
	public UnityEvent<float> OnFloatInput;
	public UnityEvent OnButtonPressed;
	public UnityEvent OnButtonReleased;

	public InputActionSO InputEvent => inputEvent;

	private void OnEnable()
	{
		if (inputEvent != null) inputEvent.Initialize();

		inputEvent.OnVector2Input += ((value) => OnVector2Input.Invoke(value));
		inputEvent.OnFloatInput += ((value) => OnFloatInput.Invoke(value));
		inputEvent.OnButtonPressed += (() => OnButtonPressed.Invoke());
		inputEvent.OnButtonReleased += (() => OnButtonReleased.Invoke());
	}

	private void OnDisable()
	{
		if (inputEvent != null)	inputEvent.Deinitialize();
	}
}

