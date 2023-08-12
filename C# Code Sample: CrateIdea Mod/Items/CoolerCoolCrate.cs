using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
    public class CoolerCoolCrate : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            // Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<CoolCrate>();

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CoolerCoolCrate>());
            Item.width = 12; //The hitbox dimensions are intentionally smaller so that it looks nicer when fished up on a bobber
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 2);
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
            // The Cooler Cool Crate always drops sunglasses.
            int[] themedDrops = new int[] {
                ItemID.Sunglasses,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 50, 75));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 2, 1, 5));

            // Drop ice, ice is cool
            IItemDropRule[] iceTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IceBlock, 1, 10, 50),
                ItemDropRule.Common(ItemID.PurpleIceBlock, 1, 10, 50),
                ItemDropRule.Common(ItemID.RedIceBlock, 1, 10, 50),
                ItemDropRule.Common(ItemID.PinkIceBlock, 1, 10, 50),
                ItemDropRule.Common(ItemID.ThinIce, 1, 10, 50),
                ItemDropRule.Common(ItemID.IceBrick, 1, 10, 50),
                ItemDropRule.Common(ItemID.IceChest, 1, 1, 2),
                ItemDropRule.Common(ItemID.IceTorch, 1, 10, 50),
                ItemDropRule.Common(ItemID.IceMachine, 1, 10, 50),
                ItemDropRule.Common(ItemID.SnowBlock, 1, 10, 50),
                ItemDropRule.Common(ItemID.SnowBrick, 1, 10, 50),
                ItemDropRule.Common(ItemID.SlushBlock, 1, 10, 100),
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
            itemLoot.Add(new OneFromRulesRule(5, coolDrinks));


            // Prehardmode Ice Weapons/Tools in here!
            IItemDropRule[] iceGear = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IceMirror, 1, 1, 1),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 100, 200),
                ItemDropRule.Common(ItemID.FrostDaggerfish, 1, 100, 200),
                ItemDropRule.Common(ItemID.BlizzardinaBottle, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBoomerang, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBlade, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(11, iceGear));

            // And add hardmode Ice Weapons/Tools as well.
            IItemDropRule[] hmIceGear = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Frostbrand, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.FlowerofFrost, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceRod, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceSickle, 1, 1, 1),
                ItemDropRule.Common(ItemID.FrozenTurtleShell, 1, 1, 1),
                ItemDropRule.Common(ItemID.FrostStaff, 1, 1, 1),
                ItemDropRule.Common(ItemID.Amarok, 1, 1, 1),
                ItemDropRule.Common(ItemID.CoolWhip, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(12, hmIceGear));

            // Chance at a Frost Core!
            IItemDropRule[] frostCore = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FrostCore, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(15, frostCore));

            // Now we're going to add cool things.
            // Capes are cool.
            IItemDropRule[] capes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.HunterCloak, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrimsonCloak, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedCape, 1, 1, 1),
                ItemDropRule.Common(ItemID.WinterCape, 1, 1, 1),
                ItemDropRule.Common(ItemID.MysteriousCape, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(14, capes));

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

            //If plantera has been defeated, The Axe is a guitar and therefore is cool.
            IItemDropRule[] theAxe = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.TheAxe, 1, 250, 350),
            };
            if (NPC.downedPlantBoss)
            {
                itemLoot.Add(new OneFromRulesRule(30, theAxe));
            }

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 8),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 8),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}