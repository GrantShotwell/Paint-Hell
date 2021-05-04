using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateAi {

	[System.Serializable]
	public class Transition {

		public Decision decision;
		public State trueState, falseState;

	}

}
