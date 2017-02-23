using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

	public Dialog dialog;
	public GameObject dialogPrefab;

	void Start () {
		dialog.Reset ();
		StartNextDialogSection ();
	}

	public void StartNextDialogSection() {
		DialogBoxController dbc = dialogPrefab.GetComponentInChildren<DialogBoxController> ();
		dbc.dialog = dialog.GetNext ();

		GameObject newDialog = GameObject.Instantiate (dialogPrefab);
		foreach (Transform child in this.transform) {
			Destroy (child.gameObject);
		}
		newDialog.transform.SetParent (this.transform, false);
	}
}
