using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class DialogBoxController : MonoBehaviour, IUITextPrinter {

	public string dialog;
	public float printSpeed;
	public UnityEvent dialogDoneEvent;

	private DialogBoxWriter dialogBoxWriter;

	void Start() {
		dialogBoxWriter = new DialogBoxWriter ();
		dialogBoxWriter.SetUITextPrinter (this);

		StartCoroutine (Print(dialog));
	}

	private IEnumerator Print(string desiredText) {
		dialogBoxWriter.SetText (desiredText);
		while (dialogBoxWriter.HasMoreText ()) {
			dialogBoxWriter.Print ();
			yield return new WaitForSeconds(printSpeed);
		}
		dialogDoneEvent.Invoke ();
	}

	public void PrintToUI(string text) {
		GetComponent<Text> ().text = text;
	}
}
