using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[SerializeField] int positions;
	[SerializeField] UIElement[] uiElements;

	int currentElementIndex;

	PlayerInputs inputs;

	private void OnEnable()
	{
		inputs = new PlayerInputs();
		inputs.Player.Enable();

		SetupInputEvents();

		ShowSelectedElementVisuals();
	}

	private void OnDisable()
	{
		RemoveInputEvents();
	}

	private void SetupInputEvents()
	{
		inputs.Player.UP.performed += UP_performed;
		inputs.Player.DOWN.performed += DOWN_performed;
		inputs.Player.RIGHT.performed += RIGHT_performed;
	}

	private void RemoveInputEvents()
	{
		inputs.Player.UP.performed -= UP_performed;
		inputs.Player.DOWN.performed -= DOWN_performed;
		inputs.Player.RIGHT.performed -= RIGHT_performed;
	}

	private void UP_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		HideSelectedElementVisuals();
		if (currentElementIndex == 0) currentElementIndex = uiElements.Length - 1;
		else currentElementIndex -= 1;
		ShowSelectedElementVisuals();
		AudioManager.instance.PlayUIMove();
	}

	private void RIGHT_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		uiElements[currentElementIndex].Activate();
		AudioManager.instance.PlayUISelect();
	}

	private void DOWN_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		HideSelectedElementVisuals();
		if (currentElementIndex == uiElements.Length - 1) currentElementIndex = 0;
		else currentElementIndex += 1;
		ShowSelectedElementVisuals();
		AudioManager.instance.PlayUIMove();
	}

	void HideSelectedElementVisuals()
	{
		uiElements[currentElementIndex].MoveCursorOff();
	}

	void ShowSelectedElementVisuals()
	{
		uiElements[currentElementIndex].MoveCursorOn();
	}
}
