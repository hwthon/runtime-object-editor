using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class Vector4ListFieldViewer : ListFieldViewer<Vector4>
	{
		public Vector4ListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<Vector4>);
		}

		protected override Vector4 DrawItemField(Vector4 value)
		{
			string x = GUILayout.TextField(value.x.ToString());
			string y = GUILayout.TextField(value.y.ToString());
			string z = GUILayout.TextField(value.z.ToString());
			string w = GUILayout.TextField(value.w.ToString());

			return new Vector4(x.ToFloat(value.x), y.ToFloat(value.y), z.ToFloat(value.z), w.ToFloat(value.w));
		}
	}
}