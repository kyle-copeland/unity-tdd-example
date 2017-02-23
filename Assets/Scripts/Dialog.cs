using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialog : ScriptableObject {
	[SerializeField]
	public string[] sections;
	[SerializeField]
	private int currentSection;

	public string GetNext() {
		return sections[currentSection++];
	}

	public void Reset() {
		currentSection = 0;
	}
}
