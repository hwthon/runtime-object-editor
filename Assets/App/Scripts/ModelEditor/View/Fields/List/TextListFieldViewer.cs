using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class TextListFieldViewer : ListFieldViewer<string>
	{
		public TextListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<string>);
		}

		protected override string DrawItemField(string value)
		{
			return GUILayout.TextField(value);
		}
	}
}