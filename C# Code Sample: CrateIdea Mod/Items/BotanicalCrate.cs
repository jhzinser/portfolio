using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
    public class BotanicalCrate : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<GardenCrate>();

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.BotanicalCrate>());
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
            // Drop at least one herb (or a Garland, which can be shimmered into one of each herb).
            int[] themedDrops = new int[] {
                ItemID.Daybloom,
                ItemID.Shiverthorn,
                ItemID.Waterleaf,
                ItemID.Moonglow,
                ItemID.Blinkroot,
                ItemID.Deathweed,
                ItemID.Fireblossom,
                ItemID.GarlandHat,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 50, 75));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 2, 1, 5));

            // Herbs
            IItemDropRule[] herbs = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Daybloom, 1, 1, 7),
                ItemDropRule.Common(ItemID.Waterleaf, 1, 1, 7),
                ItemDropRule.Common(ItemID.Shiverthorn, 1, 1, 7),
                ItemDropRule.Common(ItemID.Moonglow, 1, 1, 7),
                ItemDropRule.Common(ItemID.Blinkroot, 1, 1, 7),
                ItemDropRule.Common(ItemID.Fireblossom, 1, 1, 7),
                ItemDropRule.Common(ItemID.Deathweed, 1, 1, 7),
            };
            itemLoot.Add(new OneFromRulesRule(2, herbs));

            // Herb seeds
            IItemDropRule[] herbSeeds = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.DaybloomSeeds, 1, 1, 7),
                ItemDropRule.Common(ItemID.WaterleafSeeds, 1, 1, 7),
                ItemDropRule.Common(ItemID.ShiverthornSeeds, 1, 1, 7),
                ItemDropRule.Common(ItemID.MoonglowSeeds, 1, 1, 7),
                ItemDropRule.Common(ItemID.BlinkrootSeeds, 1, 1, 7),
                ItemDropRule.Common(ItemID.FireblossomSeeds, 1, 1, 7),
                ItemDropRule.Common(ItemID.DeathweedSeeds, 1, 1, 7),
            };
            itemLoot.Add(new OneFromRulesRule(2, herbSeeds));

            // Herb Bag
            IItemDropRule[] herbBags = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.HerbBag, 1, 1, 3),
            };
            itemLoot.Add(new OneFromRulesRule(2, herbBags));

            // Misc seeds
            IItemDropRule[] miscSeeds = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GrassSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.CorruptSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.CrimsonSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.HallowedSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.MushroomGrassSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.JungleGrassSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.AshGrassSeeds, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketWild, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketBlue, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketMagenta, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketPink, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketRed, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketYellow, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketViolet, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketWhite, 1, 15, 40),
                ItemDropRule.Common(ItemID.FlowerPacketTallGrass, 1, 15, 40),
            };
            itemLoot.Add(new OneFromRulesRule(3, miscSeeds));

            // Mushrooms
            IItemDropRule[] shroom = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Mushroom, 1, 2, 20),
                ItemDropRule.Common(ItemID.VileMushroom, 1, 2, 20),
                ItemDropRule.Common(ItemID.ViciousMushroom, 1, 2, 20),
                ItemDropRule.Common(ItemID.GlowingMushroom, 1, 15, 40),
                ItemDropRule.Common(ItemID.TealMushroom, 1, 1, 2),
                ItemDropRule.Common(ItemID.GreenMushroom, 1, 1, 2),
            };
            itemLoot.Add(new OneFromRulesRule(4, shroom));

            // Miscellaneous plants
            IItemDropRule[] miscPlants = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.PineTreeBlock, 1, 30, 120),
                ItemDropRule.Common(ItemID.Holly, 1, 1, 3),
                ItemDropRule.Common(ItemID.Sunflower, 1, 1, 4),
                ItemDropRule.Common(ItemID.JungleSpores, 1, 2, 8),
                ItemDropRule.Common(ItemID.Vine, 1, 1, 5),
                ItemDropRule.Common(ItemID.LivingWoodWand, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeafWand, 1, 1, 1),
                ItemDropRule.Common(ItemID.LivingMahoganyWand, 1, 1, 1),
                ItemDropRule.Common(ItemID.LivingMahoganyLeafWand, 1, 1, 1),
                ItemDropRule.Common(ItemID.SkyBlueFlower, 1, 1, 2),
                ItemDropRule.Common(ItemID.PinkPricklyPear, 1, 1, 2),
                ItemDropRule.Common(ItemID.OrangeBloodroot, 1, 1, 2),
                ItemDropRule.Common(ItemID.LimeKelp, 1, 1, 2),
                ItemDropRule.Common(ItemID.YellowMarigold, 1, 1, 2),
                ItemDropRule.Common(ItemID.BlueBerries, 1, 1, 2),
            };
            itemLoot.Add(new OneFromRulesRule(3, miscPlants));

            // Garden supplies
            IItemDropRule[] gardenSupplies = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ClayPot, 1, 2, 15),
                ItemDropRule.Common(ItemID.PotSuspended, 1, 1, 5),
                ItemDropRule.Common(ItemID.DayBloomPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.ShiverthornPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.CorruptPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.CrimsonPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.FireBlossomPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.WaterleafPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.BlinkrootPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.MoonglowPlanterBox, 1, 2, 8),
                ItemDropRule.Common(ItemID.GardenGnome, 1, 1, 5),
                ItemDropRule.Common(ItemID.GravediggerShovel, 1, 1, 1),
                ItemDropRule.Common(ItemID.StaffofRegrowth, 1, 1, 1),
                ItemDropRule.Common(ItemID.LivingLoom, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, gardenSupplies));


            // Accessories and Weapons that are plant-based
            IItemDropRule[] plantBasedGear = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Vilethorn, 1, 1, 1),
                ItemDropRule.Common(ItemID.StarAnise, 1, 200, 300),
                ItemDropRule.Common(ItemID.ThornChakram, 1, 1, 1),
                ItemDropRule.Common(ItemID.FlowerofFire, 1, 1, 1),
                ItemDropRule.Common(ItemID.FlowerofFrost, 1, 1, 1),
                ItemDropRule.Common(ItemID.BladeofGrass, 1, 1, 1),
                ItemDropRule.Common(ItemID.ThornWhip, 1, 1, 1),
                ItemDropRule.Common(ItemID.AbigailsFlower, 1, 1, 1),
                ItemDropRule.Common(ItemID.NaturesGift, 1, 1, 1),
                ItemDropRule.Common(ItemID.JungleRose, 1, 1, 1),
                ItemDropRule.Common(ItemID.FlowerBoots, 1, 1, 1),
                ItemDropRule.Common(ItemID.AnkletoftheWind, 1, 1, 1),
                ItemDropRule.Common(ItemID.ObsidianRose, 1, 1, 1),
                ItemDropRule.Common(ItemID.SunflowerMinecart, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, plantBasedGear));

            // Chance for a Life Fruit!
            IItemDropRule[] lifeFruit = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.LifeFruit, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, lifeFruit));


            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 8),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 8),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}