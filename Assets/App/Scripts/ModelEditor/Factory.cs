using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class Factory
	{
		public Viewer FindOrCreate(object model)
		{
			// find
			var gameObject = new GameObject("Viewer");
			var viewer = gameObject.AddComponent<Viewer>();
			viewer.Show(model);
			return viewer;
		}
	}
}