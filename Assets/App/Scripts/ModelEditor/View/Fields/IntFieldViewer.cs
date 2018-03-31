using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class IntFieldViewer : FieldViewer
	{
		public IntFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(int);
		}

		protected override void DrawField()
		{
			int intValue = GetTextValue().ToInt();

			string textValue = GUILayout.TextField(intValue.ToString());

			_fieldInfo.SetValue(_model, textValue.ToInt(intValue));
		}
	}
}