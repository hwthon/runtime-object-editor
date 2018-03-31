using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public static class Factory
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
			if (TextArrayFieldViewer.Available(fieldInfo.FieldType))
			{
				return new TextArrayFieldViewer(model, fieldInfo);
			}

			if (IsClass(fieldInfo.FieldType))
			{
				return new ObjectViewer(fieldInfo.GetValue(model));
			}

			return new FieldViewer(model, fieldInfo);
		}

		public static Viewer Create(ObjectViewer parent, object model, FieldInfo fieldInfo)
		{
			Viewer viewer = Create(model, fieldInfo);

			var objectViewer = viewer as ObjectViewer;
			if (objectViewer != null)
			{
				objectViewer.SetParent(parent);
			}

			return viewer;
		}

		public static bool IsClass(System.Type type)
		{
			return type.IsClass;
		}
	}
}