package canSeeOtherPlayer;

public class Player {

    String name;
    int x;
    int y;
    int visionRange;
    Direction facing;
    VisionType visionType;
    
    public Player (String nameIn, int xIn, int yIn, int visionRangeIn) {
        name = nameIn;
        x = xIn;
        y = yIn;
        visionRange = visionRangeIn;
        facing = Direction.DOWN;
        visionType = VisionType.VISION_360;
    }
    
    public Player(String nameIn, int xIn, int yIn, int visionRangeIn, Direction facingIn, VisionType visionTypeIn) {
        name = nameIn;
        x = xIn;
        y = yIn;
        visionRange = visionRangeIn;
        facing = facingIn;
        visionType = visionTypeIn;
    }
    
    public boolean canSeeOtherPlayer(Player otherPlayer) {
        //Check to see distance from the other player
        int xDistance = x - otherPlayer.x;
        int yDistance = y - otherPlayer.y;
        int totalDistance = Math.abs(xDistance) + Math.abs(yDistance);
        
        //Compare the distance to the vision range
        if (totalDistance <= visionRange) {
            //If the player has 360 vision, we can return True now.
            if (visionType == VisionType.VISION_360) return true;
            
            //Other vision types require the player to be facing the other player.
            
            //Facing Up:
            if (facing == Direction.UP) {
                //yDistance must be negative
                //Line vision must have no X distance, cone vision must have less X distance than Y distance
                if (yDistance > 0) return false; 
                if (visionType == VisionType.VISION_LINE && xDistance == 0) return true;
                if (visionType == VisionType.VISION_CONE && Math.abs(xDistance) < Math.abs(yDistance) ) return true;
            }
            
            //Facing Down:
            if (facing == Direction.DOWN) {
                //yDistance must be positive
                //Line vision must have no X distance, cone vision must have less X distance than Y distance
                if (yDistance < 0) return false; 
                if (visionType == VisionType.VISION_LINE && xDistance == 0) return true;
                if (visionType == VisionType.VISION_CONE && Math.abs(xDistance) < Math.abs(yDistance) ) return true;
            }

            
            //Facing Right:
            if (facing == Direction.RIGHT) {
                //xDistance must be positive
                //Line vision must have no Y distance, cone vision must have less Y distance than X distance
                if (xDistance > 0) return false; 
                if (visionType == VisionType.VISION_LINE && yDistance == 0) return true;
                if (visionType == VisionType.VISION_CONE && Math.abs(yDistance) < Math.abs(xDistance) ) return true;      
            }

            
            //Facing Left:
            if (facing == Direction.LEFT) {
                //xDistance must be negative
                //Line vision must have no Y distance, cone vision must have less Y distance than X distance
                if (xDistance < 0) return false; 
                if (visionType == VisionType.VISION_LINE && yDistance == 0) return true;
                if (visionType == VisionType.VISION_CONE && Math.abs(yDistance) < Math.abs(xDistance) ) return true; 
            }
           
        }
        
        //If we reach this point, the other player is out of range and cannot be seen
        return false;
    }
	
}
