using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateAi;

public class GapAheadDecision : Decision {

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) return LogErrorWrongController(this, controller);



	}

}
