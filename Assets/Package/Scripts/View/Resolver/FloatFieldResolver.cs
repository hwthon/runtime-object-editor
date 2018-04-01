using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class FloatFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return FloatFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new FloatFieldViewer(model, fieldInfo);
		}
	}
}