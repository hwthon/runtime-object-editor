using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class FloatFieldViewer : FieldViewer
	{
		public FloatFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(float);
		}

		protected override void DrawField()
		{
			float floatValue = ToFloat(GetTextValue());

			string textValue = GUILayout.TextField(floatValue.ToString());

			_fieldInfo.SetValue(_model, ToFloat(textValue, floatValue));
		}

		private static float ToFloat(string text, float defaultValue = 0f)
		{
			float floatValue = 0f;

			if (!string.IsNullOrEmpty(text))
			{
				bool success = float.TryParse(text, out floatValue);
				if (!success)
				{
					return defaultValue;
				}
			}

			return floatValue;
		}
	}
}