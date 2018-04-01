using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class Vector4ListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return Vector4ListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new Vector4ListFieldViewer(model, fieldInfo);
		}
	}
}