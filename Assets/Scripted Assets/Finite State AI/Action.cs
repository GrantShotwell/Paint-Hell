using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateAi {

	public abstract class Action : ScriptableObject {

		public abstract void TriggerEnter(StateController controller);
		public abstract void TriggerUpdate(StateController controller);
		public abstract void TriggerExit(StateController controller);

	}

}
