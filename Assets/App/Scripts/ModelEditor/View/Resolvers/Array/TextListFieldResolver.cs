using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class TextListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return TextListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new TextListFieldViewer(model, fieldInfo);
		}
	}
}