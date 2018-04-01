using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class FloatListFieldViewer : ListFieldViewer<float>
	{
		public FloatListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<float>);
		}

		protected override float DrawItemField(float value)
		{
			return GUILayout.TextField(value.ToString()).ToFloat(value);
		}
	}
}