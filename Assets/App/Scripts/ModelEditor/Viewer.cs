using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

namespace SerializableModelEditor
{
	public class Viewer : MonoBehaviour
	{
		[SerializeField]
		private ObjectViewer _root;

		public void Show(object model)
		{
			_root.Initialize(model);
		}

		private void Update()
		{

		}
	}
}

/**

Viewer.Show(model);
viewer.onclose?
viewer.onsaved??
いる？

objectのメンバーを辿っていく



*/