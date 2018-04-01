using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector3FieldViewer : FieldViewer
	{
		public Vector3FieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(Vector3);
		}

		protected override void DrawField()
		{
			var value = (Vector3) _fieldInfo.GetValue(_model);

			string x = GUILayout.TextField(value.x.ToString());
			string y = GUILayout.TextField(value.y.ToString());
			string z = GUILayout.TextField(value.z.ToString());

			_fieldInfo.SetValue(_model, new Vector3(x.ToFloat(value.x), y.ToFloat(value.y), z.ToFloat(value.z)));
		}
	}
}