using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class IntFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return IntFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new IntFieldViewer(model, fieldInfo);
		}
	}
}