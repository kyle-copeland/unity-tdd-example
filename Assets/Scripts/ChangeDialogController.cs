using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogController : MonoBehaviour {

	void Update() {
		if (Input.GetButtonDown ("Submit")) {
			GameObject.FindObjectOfType<DialogManager> ().StartNextDialogSection();
		}
	}
}
