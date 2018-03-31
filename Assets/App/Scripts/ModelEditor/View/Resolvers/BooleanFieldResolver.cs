using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class BooleanFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return BooleanFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new BooleanFieldViewer(model, fieldInfo);
		}
	}
}