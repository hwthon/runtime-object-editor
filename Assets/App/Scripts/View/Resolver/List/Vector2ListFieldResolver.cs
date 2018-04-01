using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector2ListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return Vector2ListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new Vector2ListFieldViewer(model, fieldInfo);
		}
	}
}