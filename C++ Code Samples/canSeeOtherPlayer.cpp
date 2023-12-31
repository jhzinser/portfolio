// canSeeOtherPlayer function
// Takes two Player objects with a set direction and location on a grid. 
// Determines if the first player can see the second player.
// Different players can see in 360 degrees around them, in a cone in front of them,
// or in a straight line, depending on different options they would pick.
#include <iostream>
#include <string>
#include <vector>
#include <cmath>
using namespace std;

//Directions Enum
enum Direction {
    UP,
    RIGHT,
    DOWN,
    LEFT
};

//Vision Types Enum
enum VisionType {
    VISION_360,
    VISION_CONE,
    VISION_LINE
};

class Player
{
    public: string name;
    public: int x;
    public: int y;
    public: int visionRange;
    public: Direction facing;
    public: VisionType visionType;
    
    public: Player (string nameIn, int xIn, int yIn, int visionRangeIn) {
        name = nameIn;
        x = xIn;
        y = yIn;
        visionRange = visionRangeIn;
        facing = DOWN;
        visionType = VISION_360;
    }
    
    public: Player(string nameIn, int xIn, int yIn, int visionRangeIn, Direction facingIn, VisionType visionTypeIn) {
        name = nameIn;
        x = xIn;
        y = yIn;
        visionRange = visionRangeIn;
        facing = facingIn;
        visionType = visionTypeIn;
    }
    
     public: bool canSeeOtherPlayer(Player otherPlayer) {
         //Check to see distance from the other player
        int xDistance = x - otherPlayer.x;
        int yDistance = y - otherPlayer.y;
        int totalDistance = abs(xDistance) + abs(yDistance);
        //Compare the distance to the vision range
        if (totalDistance <= visionRange) {
            //If the player has 360 vision, we can return True now.
            if (visionType == VISION_360) return true;
            
            //Other vision types require the player to be facing the other player.
            
            //Facing Up:
            if (facing == UP) {
                //yDistance must be negative
                //Line vision must have no X distance, cone vision must have less X distance than Y distance
                if (yDistance > 0) return false; 
                if (visionType == VISION_LINE && xDistance == 0) return true;
                if (visionType == VISION_CONE && abs(xDistance) < abs(yDistance) ) return true;
            }
            
            //Facing Down:
            if (facing == DOWN) {
                //yDistance must be positive
                //Line vision must have no X distance, cone vision must have less X distance than Y distance
                if (yDistance < 0) return false; 
                if (visionType == VISION_LINE && xDistance == 0) return true;
                if (visionType == VISION_CONE && abs(xDistance) < abs(yDistance) ) return true;
            }

            
            //Facing Right:
            if (facing == RIGHT) {
                //xDistance must be positive
                //Line vision must have no Y distance, cone vision must have less Y distance than X distance
                if (xDistance > 0) return false; 
                if (visionType == VISION_LINE && yDistance == 0) return true;
                if (visionType == VISION_CONE && abs(yDistance) < abs(xDistance) ) return true;      
            }

            
            //Facing Left:
            if (facing == LEFT) {
                //xDistance must be negative
                //Line vision must have no Y distance, cone vision must have less Y distance than X distance
                if (xDistance < 0) return false; 
                if (visionType == VISION_LINE && yDistance == 0) return true;
                if (visionType == VISION_CONE && abs(yDistance) < abs(xDistance) ) return true; 
            }
           
        }
        
        //If we reach this point, the other player is out of range and cannot be seen
        
        return false;
     }
    
};

int main() {
    
    //We can test the data with a vector of players.
    vector<Player> playerVector = {
        Player("Axton", 3, 6, 4),
        Player("Bradicus", 0, 5, 5, RIGHT, VISION_LINE),
        Player("Chadicus", 1, 5, 5, RIGHT, VISION_CONE),
        Player("Dirk", 5, 5, 5, LEFT, VISION_LINE),
        Player("Errol", 7, 5, 5, LEFT, VISION_CONE),
        Player("Flynn", 3, 1, 6, UP, VISION_LINE),
        Player("Gimli", 2, 2, 6, UP, VISION_CONE),
        Player("Harken", 1, 7, 5, DOWN, VISION_LINE),
        Player("Irma", 2, 9, 5, DOWN, VISION_CONE)
    };
    
    //Use these vectors for test data output.
    vector<string> directionsVector = {"UP", "RIGHT", "DOWN", "LEFT"};
    vector<string> visionTypesVector = {"360-Degree Vision", "Cone-Shaped Vision", "Straight Line Vision"};
    
    //For each player in the vector: Display their name, variables, and whether they can see each other player.
    for (int i = 0; i < playerVector.size(); i++) {
        cout << playerVector[i].name + " is at " + to_string(playerVector[i].x) + "," + to_string(playerVector[i].y);
        cout << " facing " + directionsVector[playerVector[i].facing] + "\n";
        cout << playerVector[i].name + " has " + visionTypesVector[playerVector[i].visionType] + " and has " + to_string(playerVector[i].visionRange) + " vision range\n";
        
        for (int j = 0; j < playerVector.size(); j++){
            if (i == j) continue;
            if (playerVector[i].canSeeOtherPlayer(playerVector[j])) {
                cout << playerVector[i].name + " can see " + playerVector[j].name + " at " + to_string(playerVector[j].x) + "," + to_string(playerVector[j].y) + "\n";
            }
            else {
                cout << playerVector[i].name + " cannot see " + playerVector[j].name + " at " + to_string(playerVector[j].x) + "," + to_string(playerVector[j].y) + "\n";
            }
        }
        cout << "\n";
    }
    
    return 0;
}
