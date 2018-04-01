using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class BooleanFieldViewer : FieldViewer
	{
		public BooleanFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(bool);
		}

		protected override void DrawField()
		{
			bool value = (bool) _fieldInfo.GetValue(_model);

			value = GUILayout.Toggle(value, string.Empty);

			_fieldInfo.SetValue(_model, value);
		}
	}
}