using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class BooleanListFieldViewer : ListFieldViewer<bool>
	{
		public BooleanListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<bool>);
		}

		protected override bool DrawItemField(bool value)
		{
			return GUILayout.Toggle(value, string.Empty);
		}
	}
}