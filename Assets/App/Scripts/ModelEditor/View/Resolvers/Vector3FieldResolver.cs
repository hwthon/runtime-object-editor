using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Vector3FieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return Vector3FieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new Vector3FieldViewer(model, fieldInfo);
		}
	}
}