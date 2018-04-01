using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector4FieldViewer : FieldViewer
	{
		public Vector4FieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(Vector4);
		}

		protected override void DrawField()
		{
			var value = (Vector4) _fieldInfo.GetValue(_model);

			string x = GUILayout.TextField(value.x.ToString());
			string y = GUILayout.TextField(value.y.ToString());
			string z = GUILayout.TextField(value.z.ToString());
			string w = GUILayout.TextField(value.w.ToString());

			_fieldInfo.SetValue(_model, new Vector4(x.ToFloat(value.x), y.ToFloat(value.y), z.ToFloat(value.z), w.ToFloat(value.w)));
		}
	}
}