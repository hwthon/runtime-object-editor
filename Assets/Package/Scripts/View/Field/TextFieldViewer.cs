using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class TextFieldViewer : FieldViewer
	{
		public TextFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(string);
		}

		protected override void DrawField()
		{
			_fieldInfo.SetValue(_model, GUILayout.TextField(GetTextValue()));
		}
	}
}