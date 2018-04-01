using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class Vector2FieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return Vector2FieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new Vector2FieldViewer(model, fieldInfo);
		}
	}
}