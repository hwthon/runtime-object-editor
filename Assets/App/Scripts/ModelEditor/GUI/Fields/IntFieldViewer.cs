using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class IntFieldViewer : FieldViewer
	{
		public IntFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(int);
		}

		protected override void DrawField()
		{
			int intValue = ToInt(GetTextValue());

			string textValue = GUILayout.TextField(intValue.ToString());

			_fieldInfo.SetValue(_model, ToInt(textValue, intValue));
		}

		private static int ToInt(string text, int defaultValue = 0)
		{
			int intValue = 0;

			if (!string.IsNullOrEmpty(text))
			{
				bool success = int.TryParse(text, out intValue);
				if (!success)
				{
					return defaultValue;
				}
			}

			return intValue;
		}
	}
}