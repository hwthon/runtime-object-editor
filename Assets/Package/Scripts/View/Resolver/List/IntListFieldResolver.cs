using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class IntListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return IntListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new IntListFieldViewer(model, fieldInfo);
		}
	}
}