using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector2ListFieldViewer : ListFieldViewer<Vector2>
	{
		public Vector2ListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<Vector2>);
		}

		protected override Vector2 DrawItemField(Vector2 value)
		{
			string x = GUILayout.TextField(value.x.ToString());
			string y = GUILayout.TextField(value.y.ToString());

			return new Vector2(x.ToFloat(value.x), y.ToFloat(value.y));
		}
	}
}