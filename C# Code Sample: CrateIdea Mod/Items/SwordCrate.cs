using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class SwordCrate : ModItem
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
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.SwordCrate>());
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
            // Always drop at least one sword.
            int[] themedDrops = new int[] {
                ItemID.WoodenSword,
                ItemID.BorealWoodSword,
                ItemID.AshWoodSword,
                ItemID.PalmWoodSword,
                ItemID.CactusSword,
                ItemID.RichMahoganySword,
                ItemID.EbonwoodSword,
                ItemID.ShadewoodSword,
                ItemID.TinShortsword,
                ItemID.IronShortsword,
                ItemID.LeadShortsword,
                ItemID.TungstenShortsword,
                ItemID.SilverShortsword,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 5, 40));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 1, 3));

            // Drop pre-hm shortswords (except the Copper Shortsword)
            IItemDropRule[] shortswordTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.TinShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.IronShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeadShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.TungstenShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.SilverShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.GoldShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.PlatinumShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.Gladius, 1, 1, 1),
                ItemDropRule.Common(ItemID.Swordfish, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(2, shortswordTypes));

            // Drop pre-hm ore and wood swords
            IItemDropRule[] basicBroadswordTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.CopperBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.TinBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.IronBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeadBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.SilverBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.TungstenBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.GoldBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.PlatinumBroadsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.WoodenSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.BorealWoodSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.CactusSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.PalmWoodSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.RichMahoganySword, 1, 1, 1),
                ItemDropRule.Common(ItemID.AshWoodSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.EbonwoodSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.ShadewoodSword, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(3, basicBroadswordTypes));

            // Drop rare swords
            IItemDropRule[] rareBroadswords = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.CandyCaneSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.DyeTradersScimitar, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBlade, 1, 1, 1),
                ItemDropRule.Common(ItemID.Katana, 1, 1, 1),
                ItemDropRule.Common(ItemID.BoneSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.EnchantedSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.FalconBlade, 1, 1, 1),
                ItemDropRule.Common(ItemID.StylistKilLaKillScissorsIWish, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, rareBroadswords));

            // Can get stronger swords post-EOC
            IItemDropRule[] postEocBroadswords = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.LightsBane, 1, 1, 1),
                ItemDropRule.Common(ItemID.BloodButcherer, 1, 1, 1),
                ItemDropRule.Common(ItemID.BladeofGrass, 1, 1, 1),
            };
            if (NPC.downedBoss1)
            {
                itemLoot.Add(new OneFromRulesRule(20, postEocBroadswords));
            }

            // Can get phaseblades post-Boss2
            IItemDropRule[] phaseblades = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BluePhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.GreenPhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.OrangePhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.PurplePhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedPhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.YellowPhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.WhitePhaseblade, 1, 1, 1),
            };
            if (NPC.downedBoss2)
            {
                itemLoot.Add(new OneFromRulesRule(20, phaseblades));
            }

            // Can get a Bee Keeper post-Queen Bee
            IItemDropRule[] beeKeeperDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BeeKeeper, 1, 1, 1),
            };
            if (NPC.downedQueenBee)
            {
                itemLoot.Add(new OneFromRulesRule(20, beeKeeperDrop));
            }

            // Can get a Bee Keeper post-Queen Bee
            IItemDropRule[] muramasaDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Muramasa, 1, 1, 1),
            };
            if (NPC.downedBoss3)
            {
                itemLoot.Add(new OneFromRulesRule(20, muramasaDrop));
            }

            // Rare chance at the Terragrim (or a Copper Shortsword)!
            IItemDropRule[] terragrimTable = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Terragrim, 1, 1, 1),
                ItemDropRule.Common(ItemID.CopperShortsword, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(210, terragrimTable));

            // Drop sword related furniture
            IItemDropRule[] swordFurniture = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.SwordRack, 1, 1, 1),
                ItemDropRule.Common(ItemID.SwordStatue, 1, 1, 1),
                ItemDropRule.Common(ItemID.CatSword, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, swordFurniture));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 7),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 7),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}