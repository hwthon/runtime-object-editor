using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class FloatFieldViewer : FieldViewer
	{
		public FloatFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(float);
		}

		protected override void DrawField()
		{
			float floatValue = GetTextValue().ToFloat();

			string textValue = GUILayout.TextField(floatValue.ToString());

			_fieldInfo.SetValue(_model, textValue.ToFloat(floatValue));
		}
	}
}