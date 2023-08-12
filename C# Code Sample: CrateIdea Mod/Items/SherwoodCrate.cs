using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class SherwoodCrate : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<ArcherCrate>();

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.SherwoodCrate>());
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
            // Drop a Magic Quiver, an archery potion or a single Wooden or Bone arrow.
            int[] themedDrops = new int[] {
                ItemID.ArcheryPotion,
                ItemID.WoodenArrow,
                ItemID.BoneArrow,
                ItemID.MagicQuiver,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 50, 75));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 2, 1, 5));

            // Always drop some pre-HM/early HM arrows!
            IItemDropRule[] arrowTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenArrow, 1, 35, 350),
                ItemDropRule.Common(ItemID.FlamingArrow, 1, 30, 300),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 30, 300),
                ItemDropRule.Common(ItemID.UnholyArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.JestersArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.ShimmerArrow, 1, 30, 350),
                ItemDropRule.Common(ItemID.BoneArrow, 1, 33, 333),
                ItemDropRule.Common(ItemID.HellfireArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.HolyArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.CursedArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.IchorArrow, 1, 15, 150),
            };
            itemLoot.Add(new OneFromRulesRule(1, arrowTypes));

            // 2nd
            IItemDropRule[] arrowTypes2 = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenArrow, 1, 35, 350),
                ItemDropRule.Common(ItemID.FlamingArrow, 1, 30, 300),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 30, 300),
                ItemDropRule.Common(ItemID.UnholyArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.JestersArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.ShimmerArrow, 1, 30, 350),
                ItemDropRule.Common(ItemID.BoneArrow, 1, 33, 333),
                ItemDropRule.Common(ItemID.HellfireArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.HolyArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.CursedArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.IchorArrow, 1, 15, 150),
            };
            itemLoot.Add(new OneFromRulesRule(5, arrowTypes2));

            // 3rd
            IItemDropRule[] arrowTypes3 = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.WoodenArrow, 1, 35, 350),
                ItemDropRule.Common(ItemID.FlamingArrow, 1, 30, 300),
                ItemDropRule.Common(ItemID.FrostburnArrow, 1, 30, 300),
                ItemDropRule.Common(ItemID.UnholyArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.JestersArrow, 1, 25, 250),
                ItemDropRule.Common(ItemID.ShimmerArrow, 1, 30, 350),
                ItemDropRule.Common(ItemID.BoneArrow, 1, 33, 333),
                ItemDropRule.Common(ItemID.HellfireArrow, 1, 20, 200),
                ItemDropRule.Common(ItemID.HolyArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.CursedArrow, 1, 15, 150),
                ItemDropRule.Common(ItemID.IchorArrow, 1, 15, 150),
            };
            itemLoot.Add(new OneFromRulesRule(15, arrowTypes3));

            // Drop pre-hm bows
            IItemDropRule[] preHmBows = new IItemDropRule[] {
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
                ItemDropRule.Common(ItemID.BloodRainBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.DemonBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.TendonBow, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, preHmBows));

            // Drop repeaters
            IItemDropRule[] repeaters = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.CobaltRepeater, 1, 1, 1),
                ItemDropRule.Common(ItemID.PalladiumRepeater, 1, 1, 1),
                ItemDropRule.Common(ItemID.MythrilRepeater, 1, 1, 1),
                ItemDropRule.Common(ItemID.OrichalcumRepeater, 1, 1, 1),
                ItemDropRule.Common(ItemID.AdamantiteRepeater, 1, 1, 1),
                ItemDropRule.Common(ItemID.TitaniumRepeater, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(5, repeaters));

            // Drop rare bows
            IItemDropRule[] rareBows = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ShadowFlameBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.DaedalusStormbow, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(9, rareBows));

            // Can get stronger bows post-Mechs
            IItemDropRule[] postMechsBows = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.PulseBow, 1, 1, 1),
                ItemDropRule.Common(ItemID.HallowedRepeater, 1, 1, 1),
                ItemDropRule.Common(ItemID.ChlorophyteShotbow, 1, 1, 1),
            };
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                itemLoot.Add(new OneFromRulesRule(12, postMechsBows));
            }

            // Can get a Bee's Knees post-Queen Bee
            IItemDropRule[] beesKneesDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BeesKnees, 1, 1, 1),
            };
            if (NPC.downedQueenBee)
            {
                itemLoot.Add(new OneFromRulesRule(20, beesKneesDrop));
            }

            // Can get a Tsunami post-Fishron
            IItemDropRule[] tsunamiDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Tsunami, 1, 1, 1),
            };
            if (NPC.downedFishron)
            {
                itemLoot.Add(new OneFromRulesRule(30, tsunamiDrop));
            }

            // Can get an Eventide post-EoL
            IItemDropRule[] eventideDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FairyQueenRangedItem, 1, 1, 1),
            };
            if (NPC.downedEmpressOfLight)
            {
                itemLoot.Add(new OneFromRulesRule(30, eventideDrop));
            }

            // Archery Potions are a given.
            IItemDropRule[] archeryPotionDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ArcheryPotion, 1, 3, 7),
            };
            itemLoot.Add(new OneFromRulesRule(20, archeryPotionDrop));

            // The giant bow is the wrong kind of bow, but put it in anyway because I am a sucker for bad puns.
            IItemDropRule[] nonBowBows = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GiantBow, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(10, nonBowBows));

            // Drop bow- and arrow-related furniture
            IItemDropRule[] archeryFurniture = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ArrowSign, 1, 1, 2),
                ItemDropRule.Common(ItemID.PaintedArrowSign, 1, 1, 2),
                ItemDropRule.Common(ItemID.BowStatue, 1, 1, 2),
            };
            itemLoot.Add(new OneFromRulesRule(6, archeryFurniture));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 8),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 8),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}