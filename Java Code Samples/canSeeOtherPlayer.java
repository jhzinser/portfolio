// canSeeOtherPlayer function
// Takes two Player objects with a set direction and location on a grid. 
// Determines if the first player can see the second player.
// Different players can see in 360 degrees around them, in a cone in front of them,
// or in a straight line, depending on different options they would pick.

import java.util.ArrayList;

//Directions Enum
enum Direction {
    UP,
    RIGHT,
    DOWN,
    LEFT;
}

//Vision Types Enum
enum VisionType {
    VISION_360,
    VISION_CONE,
    VISION_LINE;
}

class Player {
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

class Main {
    public static void main(String[] args) {
        //We can test the data with a list of players.
        ArrayList<Player> playerList = new ArrayList<Player>();
        playerList.add(new Player("Axton", 3, 6, 4));
        playerList.add(new Player("Bradicus", 0, 5, 5, Direction.RIGHT, VisionType.VISION_LINE));
        playerList.add(new Player("Chadicus", 1, 5, 5, Direction.RIGHT, VisionType.VISION_CONE));
        playerList.add(new Player("Dirk", 5, 5, 5, Direction.LEFT, VisionType.VISION_LINE));
        playerList.add(new Player("Errol", 7, 5, 5, Direction.LEFT, VisionType.VISION_CONE));
        playerList.add(new Player("Flynn", 3, 1, 6, Direction.UP, VisionType.VISION_LINE));
        playerList.add(new Player("Gimli", 2, 2, 6, Direction.UP, VisionType.VISION_CONE));
        playerList.add(new Player("Harken", 1, 7, 5, Direction.DOWN, VisionType.VISION_LINE));
        playerList.add(new Player("Irma", 2, 9, 5, Direction.DOWN, VisionType.VISION_CONE));

        //For each player in the list: Display their name, variables, and whether they can see each other player.
        for (Player i : playerList) {
            System.out.println(i.name + " is at " + i.x + "," + i.y + " facing " + i.facing);
            System.out.println(i.name + " has " + i.visionType + " and has " + i.visionRange + " vision range");
            
            for (Player j: playerList) {
                if (i == j) continue;
                if (i.canSeeOtherPlayer(j)) System.out.println(i.name + " can see " + j.name + " at " + j.x + "," + j.y);
                else System.out.println(i.name + " cannot see " + j.name + " at " + j.x + "," + j.y);

            }
            System.out.println();
        }
    }
}

