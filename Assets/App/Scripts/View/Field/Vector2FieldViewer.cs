using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector2FieldViewer : FieldViewer
	{
		public Vector2FieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(Vector2);
		}

		protected override void DrawField()
		{
			var value = (Vector2) _fieldInfo.GetValue(_model);

			string x = GUILayout.TextField(value.x.ToString());
			string y = GUILayout.TextField(value.y.ToString());

			_fieldInfo.SetValue(_model, new Vector2(x.ToFloat(value.x), y.ToFloat(value.y)));
		}
	}
}