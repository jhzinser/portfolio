using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
	public class Excalicrate : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<SwordCrate>();

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Excalicrate>());
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
            // Always drop at least one sword.
            int[] themedDrops = new int[] {
                ItemID.Gladius,
                ItemID.Swordfish,
                ItemID.FieryGreatsword,
                ItemID.PearlwoodSword,
                ItemID.Starfury,
                ItemID.CobaltSword,
                ItemID.PalladiumSword,
                ItemID.BluePhaseblade,
                ItemID.RedPhaseblade,
                ItemID.Bladetongue,
                ItemID.TaxCollectorsStickOfDoom,
                ItemID.DyeTradersScimitar,
                ItemID.StylistKilLaKillScissorsIWish,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 50, 75));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 2, 1, 5));

            // Drop pre-hm swords (except the Copper Shortsword)
            IItemDropRule[] oldSwords = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.TinShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.IronShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeadShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.TungstenShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.SilverShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.GoldShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.PlatinumShortsword, 1, 1, 1),
                ItemDropRule.Common(ItemID.Gladius, 1, 1, 1),
                ItemDropRule.Common(ItemID.Swordfish, 1, 1, 1),
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
                ItemDropRule.Common(ItemID.CandyCaneSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.DyeTradersScimitar, 1, 1, 1),
                ItemDropRule.Common(ItemID.IceBlade, 1, 1, 1),
                ItemDropRule.Common(ItemID.Katana, 1, 1, 1),
                ItemDropRule.Common(ItemID.BoneSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.EnchantedSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.FalconBlade, 1, 1, 1),
                ItemDropRule.Common(ItemID.StylistKilLaKillScissorsIWish, 1, 1, 1),
                ItemDropRule.Common(ItemID.LightsBane, 1, 1, 1),
                ItemDropRule.Common(ItemID.BloodButcherer, 1, 1, 1),
                ItemDropRule.Common(ItemID.BladeofGrass, 1, 1, 1),
                ItemDropRule.Common(ItemID.BluePhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.GreenPhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.OrangePhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.PurplePhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedPhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.YellowPhaseblade, 1, 1, 1),
                ItemDropRule.Common(ItemID.WhitePhaseblade, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(4, oldSwords));

            // Drop new ore swords, the Pearlwood Sword, and the Breaker Blade
            IItemDropRule[] hmOreSwords = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.PearlwoodSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.CobaltSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.PalladiumSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.MythrilSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.OrichalcumSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.AdamantiteSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.TitaniumSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.BreakerBlade, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(5, hmOreSwords));

            // Drop Phasesabers.
            IItemDropRule[] basicBroadswordTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BluePhasesaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedPhasesaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.GreenPhasesaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.YellowPhasesaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.PurplePhasesaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.OrangePhasesaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.WhitePhasesaber, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, basicBroadswordTypes));

            // Drop rare swords (and the Sky Fracture since it's TECHNICALLY a sword)
            IItemDropRule[] rareBroadswords = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.SkyFracture, 1, 1, 1),
                ItemDropRule.Common(ItemID.BeamSword, 1, 1, 1),
                ItemDropRule.Common(ItemID.Frostbrand, 1, 1, 1),
                ItemDropRule.Common(ItemID.Bladetongue, 1, 1, 1),
                ItemDropRule.Common(ItemID.TaxCollectorsStickOfDoom, 1, 1, 1),
                ItemDropRule.Common(ItemID.DyeTradersScimitar, 1, 1, 1),
                ItemDropRule.Common(ItemID.StylistKilLaKillScissorsIWish, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(10, rareBroadswords));

            // Can get stronger swords post-Mechs (including the Blade Staff)
            IItemDropRule[] postMechsBroadswords = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Excalibur, 1, 1, 1),
                ItemDropRule.Common(ItemID.ChlorophyteClaymore, 1, 1, 1),
                ItemDropRule.Common(ItemID.ChlorophyteSaber, 1, 1, 1),
                ItemDropRule.Common(ItemID.Smolstar, 1, 1, 1),
            };
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                itemLoot.Add(new OneFromRulesRule(10, postMechsBroadswords));
            }

            // Can get a Bee Keeper post-Queen Bee
            IItemDropRule[] beeKeeperDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BeeKeeper, 1, 1, 1),
            };
            if (NPC.downedQueenBee)
            {
                itemLoot.Add(new OneFromRulesRule(20, beeKeeperDrop));
            }

            // Can get a Muramasa post-Skeletron
            IItemDropRule[] muramasaDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Muramasa, 1, 1, 1),
            };
            if (NPC.downedBoss3)
            {
                itemLoot.Add(new OneFromRulesRule(20, muramasaDrop));
            }

            // Can get a Seedler or Broken Hero Sword post-Plantera
            IItemDropRule[] seedlerDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Seedler, 1, 1, 1),
                ItemDropRule.Common(ItemID.BrokenHeroSword, 1, 1, 1),
            };
            if (NPC.downedPlantBoss)
            {
                itemLoot.Add(new OneFromRulesRule(18, seedlerDrop));
            }

            // Can get a Starlight post-EoL
            IItemDropRule[] starlightDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.PiercingStarlight, 1, 1, 1),
            };
            if (NPC.downedEmpressOfLight)
            {
                itemLoot.Add(new OneFromRulesRule(30, starlightDrop));
            }

            // Rare chance at the Terragrim!
            IItemDropRule[] terragrimTable = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Terragrim, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(210, terragrimTable));

            // Rare chance at the Arkhalis (or a Copper Shortsword)!
            IItemDropRule[] arkhalisTable = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Arkhalis, 1, 1, 1),
                ItemDropRule.Common(ItemID.CopperShortsword, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(210, arkhalisTable));

            // Drop sword related furniture
            IItemDropRule[] swordFurniture = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.SwordRack, 1, 1, 2),
                ItemDropRule.Common(ItemID.SwordStatue, 1, 1, 2),
                ItemDropRule.Common(ItemID.CatSword, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(6, swordFurniture));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 8),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 8),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}