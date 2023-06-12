
# canSeeOtherPlayer function
# Takes two Player objects with a set direction and location on a grid. 
# Determines if the first player can see the second player.
# Different players can see in 360 degrees around them, in a cone in front of them,
# or in a straight line, depending on different options they would pick.

#Direction Constants:
UP = 0;
RIGHT = 1;
DOWN = 2;
LEFT = 3;

#Vision Type Constants:
VISION_360 = 0;
VISION_CONE = 1;
VISION_LINE = 2;

class Player:
  def __init__(self, name, x, y, visionRange = 5, facing = DOWN, visionType = VISION_360):
    self.name = name; #The player's name, used for identifying the player.
    self.x = x; #The player's X coordinate. Higher numbers are to the right of lower numbers.
    self.y = y; #The player's Y coordinate. Higher numbers are up from lower numbers.
    self.visionRange = visionRange; #The distance the player can see.
    self.facing = facing; #The direction the player is looking.
    self.visionType = visionType; #The type of vision the player has.
    
  def canSeeOtherPlayer(self, otherPlayer):
    #Check to see distance from the other player
    xDistance = self.x - otherPlayer.x;
    yDistance = self.y - otherPlayer.y;
    totalDistance = abs(xDistance) + abs(yDistance);
    
    #Compare the distance to the vision range
    if (totalDistance <= self.visionRange):
      #If the player has 360 vision, we can return True now.
      if (self.visionType == VISION_360): return True;
      
      #Other vision types require the player to be facing the other player.
      
      #Facing Up:
      if (self.facing == UP):
        #yDistance must be negative
        #Line vision must have no X distance, cone vision must have less X distance than Y distance
        if (yDistance > 0): return False; 
        if (self.visionType == VISION_LINE and xDistance == 0): return True;
        if (self.visionType == VISION_CONE and abs(xDistance) < abs(yDistance) ): return True;
      
      #Facing Down:
      if (self.facing == DOWN):
        #yDistance must be positive
        #Line vision must have no X distance, cone vision must have less X distance than Y distance
        if (yDistance < 0): return False; 
        if (self.visionType == VISION_LINE and xDistance == 0): return True;
        if (self.visionType == VISION_CONE and abs(xDistance) < abs(yDistance) ): return True;
      
      #Facing Right:
      if (self.facing == RIGHT):
        #xDistance must be positive
        #Line vision must have no Y distance, cone vision must have less Y distance than X distance
        if (xDistance > 0): return False; 
        if (self.visionType == VISION_LINE and yDistance == 0): return True;
        if (self.visionType == VISION_CONE and abs(yDistance) < abs(xDistance) ): return True;
      
      #Facing Left:
      if (self.facing == LEFT):
        #xDistance must be negative
        #Line vision must have no Y distance, cone vision must have less Y distance than X distance
        if (xDistance < 0): return False; 
        if (self.visionType == VISION_LINE and yDistance == 0): return True;
        if (self.visionType == VISION_CONE and abs(yDistance) < abs(xDistance) ): return True;
       
    #If we reach this point, the other player is out of range and cannot be seen
    return False;
    
#We can test the data with a list of players.
playerList = [
  Player('Axton', 3, 6, 4),
  Player('Bradicus', 0, 5, 5, RIGHT, VISION_LINE),
  Player('Chadicus', 1, 5, 5, RIGHT, VISION_CONE),
  Player('Dirk', 5, 5, 5, LEFT, VISION_LINE),
  Player('Errol', 7, 5, 5, LEFT, VISION_CONE),
  Player('Flynn', 3, 1, 6, UP, VISION_LINE),
  Player('Gimli', 2, 2, 6, UP, VISION_CONE),
  Player('Harken', 1, 7, 5, DOWN, VISION_LINE),
  Player('Irma', 2, 9, 5, DOWN, VISION_CONE)
]

#Use these lists for test data output.
directionsList = ['UP', 'RIGHT', 'DOWN', 'LEFT']
visionTypesList = ['360-Degree Vision', 'Cone-Shaped Vision', 'Straight Line Vision']

#For each player in the list: Display their name, variables, and whether they can see each other player.
for i in playerList:
    print(f'{i.name} is at {i.x},{i.y} facing {directionsList[i.facing]}')
    print(f'{i.name} has {visionTypesList[i.visionType]} and has {i.visionRange} vision range')
    
    for j in playerList:
        if i == j: continue;
        if i.canSeeOtherPlayer(j): print(f'{i.name} can see {j.name} at {j.x},{j.y}')  
        else: print(f'{i.name} cannot see {j.name} at {j.x},{j.y}')
    print (f' ')
    
#End of code
