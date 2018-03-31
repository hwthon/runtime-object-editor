using System.Collections;
using System.Collections.Generic;
using SerializableModelEditor;
using UnityEngine;

public class Sample : MonoBehaviour
{
	[System.Serializable]
	public class TestModel
	{
		public string name;

		public int count;

		public float range;
	}

	public Viewer viewer;

	// Use this for initialization
	void Start()
	{
		viewer.Show(new TestModel
		{
			name = "test",
				count = 1
		});
	}

	// Update is called once per frame
	void Update()
	{

	}
}