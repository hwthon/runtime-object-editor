using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class BooleanListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return BooleanListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new BooleanListFieldViewer(model, fieldInfo);
		}
	}
}