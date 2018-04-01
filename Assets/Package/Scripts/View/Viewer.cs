using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public abstract class Viewer
	{
		protected Viewer _parent;

		public int Parents { get { return _parent == null ? 0 : _parent.Parents + 1; } }

		public abstract void OnGUI();

		public void SetParent(Viewer parent)
		{
			_parent = parent;
		}
	}
}