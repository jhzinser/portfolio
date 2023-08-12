using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class CrateCrate : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFishingCrate[Type] = true;
            //ItemID.Sets.IsFishingCrateHardmode[Type] = true; // This is a crate that mimics a pre-hardmode biome crate, so this is commented out

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CrateCrate>());
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
                ItemID.WoodenCrate,
                ItemID.IronCrate,
                ItemID.GoldenCrate,
                ItemID.CorruptFishingCrate,
                ItemID.CrimsonFishingCrate,
                ItemID.FloatingIslandFishingCrate,
                ItemID.JungleFishingCrate,
                ItemID.FrozenCrate,
                ItemID.OasisCrate,
                ModContent.ItemType<SwordCrate>(),
                ModContent.ItemType<ArcherCrate>(),
                ModContent.ItemType<CoolCrate>(),
                ModContent.ItemType<GardenCrate>(),
                ModContent.ItemType<FishCrate>(),
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Chance to drop a bonus wooden crate (or two!)
            IItemDropRule[] woodCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenCrate, 1, 1, 1),
                ItemDropRule.Common(ItemID.WoodenCrate, 1, 1, 2),
            };
            itemLoot.Add(new OneFromRulesRule(2, woodCrateBonus));

            // Chance to drop a bonus iron crate.
            IItemDropRule[] ironCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.IronCrate, 1, 1, 1)
            };
            itemLoot.Add(new OneFromRulesRule(5, ironCrateBonus));

            // Chance to drop a bonus golden crate.
            IItemDropRule[] goldenCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GoldenCrate, 1, 1, 1)
            };
            itemLoot.Add(new OneFromRulesRule(15, goldenCrateBonus));

            // Chance to drop a bonus vanilla biome crate.
            IItemDropRule[] biomeCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FrozenCrate, 1, 1, 1),
                ItemDropRule.Common(ItemID.OasisCrate, 1, 1, 1),
                ItemDropRule.Common(ItemID.JungleFishingCrate, 1, 1, 1),
                ItemDropRule.Common(ItemID.FloatingIslandFishingCrate, 1, 1, 1),
                ItemDropRule.Common(ItemID.CorruptFishingCrate, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrimsonFishingCrate, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(5, biomeCrateBonus));

            // Chance to drop a bonus Crate Idea crate.
            IItemDropRule[] moddedCrateBonus = new IItemDropRule[] {
                ItemDropRule.Common(ModContent.ItemType<SwordCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<ArcherCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<CoolCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<GardenCrate>(), 1, 1, 1),
                ItemDropRule.Common(ModContent.ItemType<FishCrate>(), 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(5, moddedCrateBonus));
        }
    }
}