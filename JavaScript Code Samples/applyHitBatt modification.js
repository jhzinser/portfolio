//This is a small snippet of code added to Synrec_TBS, a larger plugin written in JavaScript for RPG Maker MZ.
//This code allows the plugin to use the default Magic Reflection functionality within RPG Maker MZ.

var hasBeenReflected = false;
var animationReflectConfirmed = false;
var reflectRng = Math.random(); 
//Magic Reflection rate is from 0 to 1, so we get a random number in the same range
//We define the random number here so we can use it in multiple formulas.

//This forEach loop checks to see if the animation is played.
//animTargets have the attack animation displayed, reflectTargets get a "bubble shield" animation instead.
targets.forEach((t)=>{
    //Check if the user's attack is a magical attack, and check the target battler's magic reflection rate.
		if (action.isMagical() && (t._battler.mrf > reflectRng)) {
			//The action was reflected! Show the attack animation on the caster and the reflect animation on the target.
      reflectTargets.push(t);
			if (!animationReflectConfirmed) {
				animTargets.push(this);
				animationReflectConfirmed = true;
			}
		} else {
      //Show the attack animation on the target.
			animTargets.push(t);
		}
	})

//This forEach loop determines hit logic.
hitTargets.forEach((t)=>{
  if (action.isMagical() && (t.mrf > reflectRng)) {
    if (!hasBeenReflected) {
      //A multi-target attack should only be reflected once even if it hits multiple targets that reflect it.
      //If this is the first time this attack's been reflected, perform attack calculations against the b
      hasBeenReflected = true;
      action.apply(battler);
      const item = action.item();
      const type = item.damage.type;
      const is_damage = [1,2].includes(type);
      if(TBS_MV_MODE){
        const result = battler._result;
        if(
          result.missed ||
          result.evaded ||
          result.hpAffected ||
          result.mpDamage !== 0
        ){
          battler.startDamagePopup();
        }
      }else{
        if(battler.shouldPopupDamage()){
          battler.startDamagePopup();
        }
      }
    }
    
  } else {
    //This section is the default code that comes with the plugin, provided for context.
    action.apply(t);
    const item = action.item();
    const type = item.damage.type;
    const is_damage = [1,2].includes(type);
    if(TBS_MV_MODE){
      const result = t._result;
      if(
        result.missed ||
        result.evaded ||
        result.hpAffected ||
        result.mpDamage !== 0
      ){
        t.startDamagePopup();
        const cnt = t.cnt;
        if(
          Math.random() <= cnt && 
          !is_counter &&
          is_damage
        ){
          t._tbsCounter = true;
        }
      }
    }else{
      if(t.shouldPopupDamage()){
        t.startDamagePopup();
        const cnt = t.cnt;
        if(
          Math.random() <= cnt && 
          !is_counter &&
          is_damage
        ){
          t._tbsCounter = true;
        }
      }
    }
  }
  
})
