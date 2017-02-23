using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxWriter {
	private string text;
	private int textPosition;
	private IUITextPrinter uiTextPrinter;

	public void Print() {
		if (HasMoreText ()) {
			uiTextPrinter.PrintToUI (text.Substring (0, textPosition + 1));
			textPosition++;
		} else {
			throw new IllegalStateException ();
		}
	}

	public bool HasMoreText() {
		return !string.IsNullOrEmpty (text) && textPosition < text.Length;
	}

	public void SetText(string text) {
		this.text = text;
		textPosition = 0;
	}

	public void SetUITextPrinter(IUITextPrinter uiTextPrinter) {
		this.uiTextPrinter = uiTextPrinter;
	}
}
