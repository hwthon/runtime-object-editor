using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class Vector3ListFieldViewer : ListFieldViewer<Vector3>
	{
		public Vector3ListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<Vector3>);
		}

		protected override Vector3 DrawItemField(Vector3 value)
		{
			string x = GUILayout.TextField(value.x.ToString());
			string y = GUILayout.TextField(value.y.ToString());
			string z = GUILayout.TextField(value.z.ToString());

			return new Vector3(x.ToFloat(value.x), y.ToFloat(value.y), z.ToFloat(value.z));
		}
	}
}