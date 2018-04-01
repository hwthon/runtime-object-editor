using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class IntListFieldViewer : ListFieldViewer<int>
	{
		public IntListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<int>);
		}

		protected override int DrawItemField(int value)
		{
			return GUILayout.TextField(value.ToString()).ToInt(value);
		}
	}
}