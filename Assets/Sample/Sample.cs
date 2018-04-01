using System.Collections;
using System.Collections.Generic;
using RuntimeObjectEditor;
using UnityEngine;

public class Sample : MonoBehaviour
{
	[System.Serializable]
	public class TestModel
	{
		public string name;

		public int count;

		public float range;

		public bool toggle;
		public Vector2 vector2;
		public Vector3 vector3;
		public Vector4 vector4;
		public Color color;

		public Test2Model test2;
	}

	[System.Serializable]
	public class Test2Model
	{
		public string name;

		public int count;

		public float range;

		public List<string> texts;
		public List<int> ints;
		public List<float> floats;
		public List<bool> bools;
		public List<Vector2> vector2s;
		public List<Vector3> vector3s;
		public List<Vector4> vector4s;
		public List<Color> colors;
		public List<Test3Model> test3s;
	}

	public class Test3Model
	{
		public string name;
	}

	public ObjectEditor modelEditor;

	public TestModel testModel = new TestModel
	{
		name = "test",
			count = 1,
			test2 = new Test2Model { texts = new List<string>() { "abc", "def", "ggg" } }
	};

	// private void OnGUI()
	// {
	// using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height)))
	// 	{
	// 		using(new GUILayout.HorizontalScope())
	// 		{
	// 			GUILayout.Label("name");
	// 			GUILayout.TextField("aaaa");
	// 		}
	// 	}
	// }

	// Use this for initialization
	void Start()
	{
		modelEditor.Open(testModel, () =>
		{
			Debug.Log("closed");
		});
	}

	void OnGUI()
	{
		if (!modelEditor.Visible)
		{
			float headerHeight = Screen.height / 10f;

			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, headerHeight)))
			{
				using(new GUILayout.HorizontalScope(GUI.skin.box))
				{
					GUILayout.Label("a", GUILayout.ExpandWidth(true));

					if (GUILayout.Button("X", GUILayout.ExpandWidth(false)))
					{
						modelEditor.Open(testModel);
					}
				}
			}
		}
	}
}