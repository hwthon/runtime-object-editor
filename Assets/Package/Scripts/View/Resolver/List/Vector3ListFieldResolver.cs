using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class Vector3ListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return Vector3ListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new Vector3ListFieldViewer(model, fieldInfo);
		}
	}
}