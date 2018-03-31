using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class TextArrayFieldViewer : Viewer
	{
		protected object _model;
		protected FieldInfo _fieldInfo;

		public TextArrayFieldViewer(object model, FieldInfo fieldInfo)
		{
			_model = model;
			_fieldInfo = fieldInfo;
		}

		public static bool Available(System.Type type)
		{
			return type == typeof(List<string>);
		}

		public sealed override void OnGUI()
		{
			if (_model == null || _fieldInfo == null)
			{
				return;
			}

			using(new GUILayout.HorizontalScope())
			{
				GUILayout.Label(_fieldInfo.Name);

				System.Type itemType = typeof(string);
				System.Type listType = typeof(List<>).MakeGenericType(itemType);
				// MethodInfo add = listType.GetMethod("Add", new System.Type[] { itemType });
				// PropertyInfo indexer = listType.GetProperty("Item");

				// object list = Activator.CreateInstance(listType);
				// add.Invoke(list, new object[] { "Hello World" });
				// object item = indexer.GetValue(list, new object[] { 0 });

				var l = _fieldInfo.GetValue(_model) as List<string>;
				foreach (string a in l)
				{
					GUILayout.Label(a);
				}
			}
		}
	}
}