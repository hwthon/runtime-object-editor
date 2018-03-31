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
			if (TextFieldViewer.Available(fieldInfo.FieldType))
			{
				return new TextFieldViewer(model, fieldInfo);
			}

			if (IntFieldViewer.Available(fieldInfo.FieldType))
			{
				return new IntFieldViewer(model, fieldInfo);
			}

			if (FloatFieldViewer.Available(fieldInfo.FieldType))
			{
				return new FloatFieldViewer(model, fieldInfo);
			}

			// TODO: リスト

			if (IsClass(fieldInfo.FieldType))
			{
				return new ObjectViewer(fieldInfo.GetValue(model));
			}

			return new FieldViewer(model, fieldInfo);
		}


		public static bool IsClass(System.Type type)
		{
			return type.IsClass;
		}
	}
}