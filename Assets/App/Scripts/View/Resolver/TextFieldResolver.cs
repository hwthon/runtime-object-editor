using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class TextFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return TextFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new TextFieldViewer(model, fieldInfo);
		}
	}
}