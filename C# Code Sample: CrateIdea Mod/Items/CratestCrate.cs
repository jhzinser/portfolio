using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class CratestCrate : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<CrateCrate>();

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CratestCrate>());
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
            // This crate is special. It will always drop at least one other crate.
            int[] themedDrops = new int[] {
                ItemID.WoodenCrateHard,
                ItemID.IronCrateHard,
                ItemID.GoldenCrateHard,
                ItemID.CorruptFishingCrateHard,
                ItemID.CrimsonFishingCrateHard,
                ItemID.FloatingIslandFishingCrateHard,
                ItemID.JungleFishingCrateHard,
                ItemID.FrozenCrateHard,
                ItemID.OasisCrateHard,
                ItemID.DungeonFishingCrateHard,
                ItemID.LavaCrateHard,
                ItemID.HallowedFishingCrateHard,
                ModContent.ItemType<Excalicrate>(),
                ModContent.ItemType<SherwoodCrate>(),
                ModContent.ItemType<CoolerCoolCrate>(),
                ModContent.ItemType<BotanicalCrate>(),
                ModContent.ItemType<BigFishCrate>(),
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Chance to drop a bonus wooden crate (or two!)
            IItemDropRule[] woodCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.WoodenCrateHard, 1, 1, 2),
            };
            itemLoot.Add(new OneFromRulesRule(2, woodCrateBonus));

            // Chance to drop a bonus iron crate.
            IItemDropRule[] ironCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IronCrateHard, 1, 1, 1)
            };
            itemLoot.Add(new OneFromRulesRule(5, ironCrateBonus));

            // Chance to drop a bonus golden crate.
            IItemDropRule[] goldenCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GoldenCrateHard, 1, 1, 1)
            };
            itemLoot.Add(new OneFromRulesRule(15, goldenCrateBonus));

            // If Moon Lord is defeated, chance for a Crate of Cthulhu.
            IItemDropRule[] moonlordCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ModContent.ItemType<CrateOfCthulhu>(), 1, 1, 1)
            };
            if (NPC.downedMoonlord)
            {
                itemLoot.Add(new OneFromRulesRule(15, moonlordCrateBonus));
            }

            // Chance to drop a bonus vanilla biome crate.
            IItemDropRule[] biomeCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FrozenCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.OasisCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.JungleFishingCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.FloatingIslandFishingCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.CorruptFishingCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrimsonFishingCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.DungeonFishingCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.LavaCrateHard, 1, 1, 1),
                ItemDropRule.Common(ItemID.HallowedFishingCrateHard, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(5, biomeCrateBonus));

            // Chance to drop a bonus Crate Idea crate.
            IItemDropRule[] moddedCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ModContent.ItemType<Excalicrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<SherwoodCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<CoolerCoolCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<BotanicalCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<BigFishCrate>(), 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(5, moddedCrateBonus));
        }
    }
}