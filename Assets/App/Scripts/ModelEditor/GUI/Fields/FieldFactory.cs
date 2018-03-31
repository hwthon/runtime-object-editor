using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public static class FieldFactory
	{
		public static Viewer Create(object model, FieldInfo fieldInfo)
		{
			Debug.Log(fieldInfo.Name + " is " + fieldInfo.FieldType);
			if (IsText(fieldInfo.FieldType))
			{
				return new TextFieldViewer(model, fieldInfo);
			}

			if (IsInt(fieldInfo.FieldType))
			{
				return new FieldViewer(model, fieldInfo);
			}

			if (IsFloat(fieldInfo.FieldType))
			{
				return new FieldViewer(model, fieldInfo);
			}

			// TODO: リスト

			if (IsClass(fieldInfo.FieldType))
			{
				return new ObjectViewer(fieldInfo.GetValue(model));
			}

			return new FieldViewer(model, fieldInfo);
		}

		public static bool IsText(System.Type type)
		{
			return type == typeof(string) || type == typeof(System.String);
		}

		public static bool IsInt(System.Type type)
		{
			return type == typeof(int);
		}

		public static bool IsFloat(System.Type type)
		{
			return type == typeof(float);
		}

		public static bool IsClass(System.Type type)
		{
			return type.IsClass;
		}
	}
}