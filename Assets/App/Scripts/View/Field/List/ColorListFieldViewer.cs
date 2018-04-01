using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ColorListFieldViewer : ListFieldViewer<Color>
	{
		public ColorListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<Color>);
		}

		protected override Color DrawItemField(Color value)
		{
			string r = GUILayout.TextField(value.r.ToString());
			string g = GUILayout.TextField(value.g.ToString());
			string b = GUILayout.TextField(value.b.ToString());
			string a = GUILayout.TextField(value.a.ToString());

			var color = new Color(r.ToFloat(value.r), g.ToFloat(value.g), b.ToFloat(value.b), a.ToFloat(value.a));
			return color;
		}
	}
}