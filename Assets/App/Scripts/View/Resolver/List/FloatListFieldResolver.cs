using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class FloatListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return FloatListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new FloatListFieldViewer(model, fieldInfo);
		}
	}
}