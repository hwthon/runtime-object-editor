using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
// using UnityEngine.UI;

namespace SerializableModelEditor
{
	public class Viewer : MonoBehaviour
	{
		[SerializeField]
		private Transform _root;

		public void Show(object model)
		{
			foreach (FieldInfo fieldInfo in model.GetType().GetFields())
			{
				if (fieldInfo.FieldType == typeof(string))
				{
					GameObject field = Instantiate(Resources.Load<GameObject>("Fields/Field"));

					field.transform.SetParent(_root);
				}
			}
		}

		private void Update()
		{

		}
	}
}

/**

Viewer.Show(model);
viewer.onclose?
viewer.onsaved??
いる？

objectのメンバーを辿っていく



*/