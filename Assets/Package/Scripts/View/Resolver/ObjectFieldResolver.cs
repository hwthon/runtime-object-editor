using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class ObjectFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return ObjectFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new ObjectFieldViewer(model, fieldInfo);
		}
	}
}