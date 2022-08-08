using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIElement : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] GameObject cursorOn;
	[SerializeField] GameObject activated;
	[SerializeField] UnityEvent action;

	public void Activate()
	{
		cursorOn.SetActive(false);
		activated.SetActive(true);
		action?.Invoke();
	}

	public void MoveCursorOn()
	{
		cursorOn.SetActive(true);
	}

	public void MoveCursorOff()
	{
		cursorOn.SetActive(false);
	}
}
