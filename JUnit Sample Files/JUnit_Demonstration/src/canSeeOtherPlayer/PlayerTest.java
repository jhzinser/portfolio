/**
 * 
 */
package canSeeOtherPlayer;

import static org.junit.jupiter.api.Assertions.*;

//import org.junit.jupiter.api.AfterAll;
//import org.junit.jupiter.api.AfterEach;
//import org.junit.jupiter.api.BeforeAll;
//import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

/**
 * @author Jeremy Zinser
 * Tests the Player class and canSeeOtherPlayer method.
 */
class PlayerTest {

	

	/**
	 * Test method for constructor with String, int, int, int.
	 * Defaults to Direction.DOWN and VisionType.VISION_360.
	 */
	@Test
	void testPlayerConstructor1() {
		Player playerFoo = new Player ("foo", 1, 2, 3);
		assertEquals("foo", playerFoo.name);
		assertEquals(1, playerFoo.x);
		assertEquals(2, playerFoo.y);
		assertEquals(3, playerFoo.visionRange);
		assertEquals(Direction.DOWN, playerFoo.facing);
		assertEquals(VisionType.VISION_360, playerFoo.visionType);
	}

	/**
	 * Test method for constructor with String, int, int, int, Direction, VisionType.
	 */
	@Test
	void testPlayerConstructor2() {
		Player playerFoo = new Player ("foo", 1, 2, 3, Direction.UP, VisionType.VISION_LINE);
		assertEquals("foo", playerFoo.name);
		assertEquals(1, playerFoo.x);
		assertEquals(2, playerFoo.y);
		assertEquals(3, playerFoo.visionRange);
		assertEquals(Direction.UP, playerFoo.facing);
		assertEquals(VisionType.VISION_LINE, playerFoo.visionType);		
	}

	/**
	 * Test method to see if CanSeeOtherPlayer works with 360-degree vision mode.
	 * Foo should be able to see Bar, Bar should not be able to see Foo.
	 */
	@Test
	void testCanSeeOtherPlayer360() {
		Player playerFoo = new Player ("foo", 1, 2, 3, Direction.DOWN, VisionType.VISION_360);
		Player playerBar = new Player ("bar", 3, 2, 1, Direction.DOWN, VisionType.VISION_360);
		assertTrue(playerFoo.canSeeOtherPlayer(playerBar));
		assertFalse(playerBar.canSeeOtherPlayer(playerFoo));
	}

	/**
	 * Test method to see if CanSeeOtherPlayer works with cone-shaped vision mode.
	 * Foo should be able to see Bar and Baz, but not Qux.
	 * Bar should be able to see Foo, but not Baz or Qux.
	 * Baz should be able to see Bar and Qux, but not Foo.
	 * Qux should be able to see Bar and Baz, but not Foo. 
	 */
	@Test
	void testCanSeeOtherPlayerCone() {
		Player playerFoo = new Player ("foo", 3, 5, 5, Direction.DOWN, VisionType.VISION_CONE);
		Player playerBar = new Player ("bar", 3, 2, 5, Direction.UP, VisionType.VISION_CONE);
		Player playerBaz = new Player ("baz", 4, 2, 5, Direction.LEFT, VisionType.VISION_CONE);
		Player playerQux = new Player ("qux", 1, 3, 5, Direction.RIGHT, VisionType.VISION_CONE);
		
		
		assertTrue(playerFoo.canSeeOtherPlayer(playerBar));
		assertTrue(playerFoo.canSeeOtherPlayer(playerBaz));
		assertFalse(playerFoo.canSeeOtherPlayer(playerQux));

		assertTrue(playerBar.canSeeOtherPlayer(playerFoo));
		assertFalse(playerBar.canSeeOtherPlayer(playerBaz));
		assertFalse(playerBar.canSeeOtherPlayer(playerQux));
		
		
		assertFalse(playerBaz.canSeeOtherPlayer(playerFoo));
		assertTrue(playerBaz.canSeeOtherPlayer(playerBar));
		assertTrue(playerBaz.canSeeOtherPlayer(playerQux));	
		
		assertFalse(playerQux.canSeeOtherPlayer(playerFoo));
		assertTrue(playerQux.canSeeOtherPlayer(playerBar));
		assertTrue(playerQux.canSeeOtherPlayer(playerBaz));	
	}


	/**
	 * Test method to see if CanSeeOtherPlayer works with line-shaped vision mode.
	 * Foo should be able to see Bar, but not Baz or Qux.
	 * Bar should be able to see Foo, but not Baz or Qux.
	 * Baz should be able to see Bar, but not Foo or Qux.
	 * Qux should not be able to see any other player. 
	 */
	@Test
	void testCanSeeOtherPlayerLine() {
		Player playerFoo = new Player ("foo", 3, 5, 5, Direction.DOWN, VisionType.VISION_LINE);
		Player playerBar = new Player ("bar", 3, 2, 5, Direction.UP, VisionType.VISION_LINE);
		Player playerBaz = new Player ("baz", 4, 2, 5, Direction.LEFT, VisionType.VISION_LINE);
		Player playerQux = new Player ("qux", 1, 3, 5, Direction.RIGHT, VisionType.VISION_LINE);
		
		
		assertTrue(playerFoo.canSeeOtherPlayer(playerBar));
		assertFalse(playerFoo.canSeeOtherPlayer(playerBaz));
		assertFalse(playerFoo.canSeeOtherPlayer(playerQux));

		assertTrue(playerBar.canSeeOtherPlayer(playerFoo));
		assertFalse(playerBar.canSeeOtherPlayer(playerBaz));
		assertFalse(playerBar.canSeeOtherPlayer(playerQux));
		
		
		assertFalse(playerBaz.canSeeOtherPlayer(playerFoo));
		assertTrue(playerBaz.canSeeOtherPlayer(playerBar));
		assertFalse(playerBaz.canSeeOtherPlayer(playerQux));	
		
		assertFalse(playerQux.canSeeOtherPlayer(playerFoo));
		assertFalse(playerQux.canSeeOtherPlayer(playerBar));
		assertFalse(playerQux.canSeeOtherPlayer(playerBaz));	
	}
}
