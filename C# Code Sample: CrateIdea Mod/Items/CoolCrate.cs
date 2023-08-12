using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class CoolCrate : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            // Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
            ItemID.Sets.IsFishingCrate[Type] = true;
            //ItemID.Sets.IsFishingCrateHardmode[Type] = true; // This is a crate that mimics a pre-hardmode biome crate, so this is commented out

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CoolCrate>());
            Item.width = 12; //The hitbox dimensions are intentionally smaller so that it looks nicer when fished up on a bobber
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 1);
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Crates;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            // The Cool Crate always drops sunglasses.
            int[] themedDrops = new int[] {
                ItemID.Sunglasses,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 5, 40));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 1, 3));

            // Drop ice, ice is cool
            IItemDropRule[] iceTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IceBlock, 1, 10, 40),
                ItemDropRule.Common(ItemID.PurpleIceBlock, 1, 10, 40),
                ItemDropRule.Common(ItemID.RedIceBlock, 1, 10, 40),
                ItemDropRule.Common(ItemID.ThinIce, 1, 10, 40),
                ItemDropRule.Common(ItemID.IceBrick, 1, 10, 40),
                ItemDropRule.Common(ItemID.IceChest, 1, 1, 2),
                ItemDropRule.Common(ItemID.IceTorch, 1, 10, 40),
                ItemDropRule.Common(ItemID.IceMachine, 1, 10, 40),
                ItemDropRule.Common(ItemID.SnowBlock, 1, 10, 40),
                ItemDropRule.Common(ItemID.SnowBrick, 1, 10, 40),
                ItemDropRule.Common(ItemID.SlushBlock, 1, 10, 40),
            };
            itemLoot.Add(new OneFromRulesRule(1, iceTypes));

            // This might be a drink cooler! Drop drinks.
            IItemDropRule[] coolDrinks = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.AppleJuice, 1, 2, 6),
                ItemDropRule.Common(ItemID.GrapeJuice, 1, 2, 6),
                ItemDropRule.Common(ItemID.Lemonade, 1, 2, 6),
                ItemDropRule.Common(ItemID.BananaDaiquiri, 1, 2, 6),
                ItemDropRule.Common(ItemID.PeachSangria, 1, 2, 6),
                ItemDropRule.Common(ItemID.PinaColada, 1, 2, 6),
                ItemDropRule.Common(ItemID.TropicalSmoothie, 1, 2, 6),
                ItemDropRule.Common(ItemID.BloodyMoscato, 1, 2, 6),
                ItemDropRule.Common(ItemID.SmoothieofDarkness, 1, 2, 6),
                ItemDropRule.Common(ItemID.PrismaticPunch, 1, 2, 6),
                ItemDropRule.Common(ItemID.FruitJuice, 1, 2, 6),
                ItemDropRule.Common(ItemID.MilkCarton, 1, 2, 6),
                ItemDropRule.Common(ItemID.CreamSoda, 1, 2, 6),
                ItemDropRule.Common(ItemID.JojaCola, 1, 2, 6),
                ItemDropRule.Common(ItemID.Ale, 1, 2, 6),
                ItemDropRule.Common(ItemID.Sake, 1, 2, 6),
            };
            itemLoot.Add(new OneFromRulesRule(6, coolDrinks));


            // Ice Weapons/Tools in here!
            IItemDropRule[] iceGear = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IceMirror, 1, 1, 1),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 100, 200),
                ItemDropRule.Common(ItemID.FrostDaggerfish, 1, 100, 200),
                ItemDropRule.Common(ItemID.BlizzardinaBottle, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBoomerang, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBlade, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(10, iceGear));

            // Capes are cool.
            IItemDropRule[] capes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.HunterCloak, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrimsonCloak, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedCape, 1, 1, 1),
                ItemDropRule.Common(ItemID.WinterCape, 1, 1, 1),
                ItemDropRule.Common(ItemID.MysteriousCape, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(15, capes));

            // Spike. That's a cool name, so we're going to drop spikes.
            IItemDropRule[] spike = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Spike, 1, 10, 25),
            };
            itemLoot.Add(new OneFromRulesRule(8, spike));

            //Guitars are cool.
            IItemDropRule[] guitars = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IvyGuitar, 1, 1, 1),
                ItemDropRule.Common(ItemID.CarbonGuitar, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(15, guitars));

            //Ninja stars are cool.
            IItemDropRule[] ninjaStars = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Shuriken, 1, 250, 350),
            };
            itemLoot.Add(new OneFromRulesRule(7, ninjaStars));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 7),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 7),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}