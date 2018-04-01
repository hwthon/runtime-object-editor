using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class ColorListFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return ColorListFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new ColorListFieldViewer(model, fieldInfo);
		}
	}
}