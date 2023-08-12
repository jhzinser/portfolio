using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class ArcherCrate : ModItem
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
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ArcherCrate>());
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
            // Drop an archery potion or a single Wooden or Bone arrow.
            int[] themedDrops = new int[] {
                ItemID.ArcheryPotion,
                ItemID.WoodenArrow,
                ItemID.BoneArrow,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 5, 40));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 1, 3));

            // Always drop some pre-HM arrows!
            IItemDropRule[] arrowTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.FlamingArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.UnholyArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.JestersArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.ShimmerArrow, 1, 20, 250),
                ItemDropRule.Common(ItemID.BoneArrow, 1, 22, 222),
                ItemDropRule.Common(ItemID.HellfireArrow, 1, 10, 100),
            };
            itemLoot.Add(new OneFromRulesRule(1, arrowTypes));

            // And chance for MORE pre-HM arrows!
            IItemDropRule[] arrowTypes2 = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.FlamingArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.UnholyArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.JestersArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.ShimmerArrow, 1, 20, 250),
                ItemDropRule.Common(ItemID.BoneArrow, 1, 22, 222),
                ItemDropRule.Common(ItemID.HellfireArrow, 1, 10, 100),
            };
            itemLoot.Add(new OneFromRulesRule(5, arrowTypes2));


            // And ANOTHER chance for MORE pre-HM arrows!
            IItemDropRule[] arrowTypes3 = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.FlamingArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.UnholyArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.JestersArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.ShimmerArrow, 1, 20, 250),
                ItemDropRule.Common(ItemID.BoneArrow, 1, 22, 222),
                ItemDropRule.Common(ItemID.HellfireArrow, 1, 10, 100),
            };
            itemLoot.Add(new OneFromRulesRule(15, arrowTypes3));

            // Drop basic pre-hm bows
            IItemDropRule[] basicBowTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.CopperBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.TinBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.IronBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeadBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.SilverBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.TungstenBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.GoldBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.PlatinumBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.WoodenBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.BorealWoodBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.PalmWoodBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.RichMahoganyBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.AshWoodBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.EbonwoodBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.ShadewoodBow, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(3, basicBowTypes));

            // Drop the one rare bow that isn't boss locked
            IItemDropRule[] rareBows = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BloodRainBow, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(8, rareBows));

            // Can get stronger bows post-EOC
            IItemDropRule[] postEocBows = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.DemonBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.TendonBow, 1, 1, 1),
            };
            if (NPC.downedBoss1)
            {
                itemLoot.Add(new OneFromRulesRule(18, postEocBows));
            }

            // Can get a Bee's Knees post-Queen Bee
            IItemDropRule[] beesKneesDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BeesKnees, 1, 1, 1),
            };
            if (NPC.downedQueenBee)
            {
                itemLoot.Add(new OneFromRulesRule(20, beesKneesDrop));
            }

            // Archery Potions are a given.
            IItemDropRule[] archeryPotionDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ArcheryPotion, 1, 2, 5),
            };
            itemLoot.Add(new OneFromRulesRule(20, archeryPotionDrop));

            // The giant bow is the wrong kind of bow, but put it in anyway because I am a sucker for bad puns.
            IItemDropRule[] nonBowBows = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GiantBow, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(10, nonBowBows));

            // Drop bow- and arrow-related furniture
            IItemDropRule[] archeryFurniture = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ArrowSign, 1, 1, 1),
                ItemDropRule.Common(ItemID.PaintedArrowSign, 1, 1, 1),
                ItemDropRule.Common(ItemID.BowStatue, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, archeryFurniture));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 7),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 7),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}