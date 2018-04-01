using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector4FieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return Vector4FieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new Vector4FieldViewer(model, fieldInfo);
		}
	}
}