using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
    public class CrateOfCthulhu : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.CrateIdea.hjson file.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MoonLordLegs;

            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CrateOfCthulhu>());
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
            // Drop a Moon Lord drop or the Bottomless Shimmer Bucket.
            int[] themedDrops = new int[] {
                ItemID.PortalGun,
                ItemID.Meowmere,
                ItemID.Terrarian,
                ItemID.StarWrath,
                ItemID.SDMG,
                ItemID.LastPrism,
                ItemID.LunarFlareBook,
                ItemID.RainbowCrystalStaff,
                ItemID.MoonlordTurretStaff,
                ItemID.Celeb2,
                ItemID.BottomlessShimmerBucket
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 10, 25));
            itemLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 5, 1, 1));
            // Drop Luminite.
            itemLoot.Add(ItemDropRule.Common(ItemID.LunarOre, 1, 30, 50));

            // Drop fragments from the Celestial Pillars.
            IItemDropRule[] celestialFragments = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FragmentSolar, 1, 10, 20),
                ItemDropRule.Common(ItemID.FragmentVortex, 1, 10, 20),
                ItemDropRule.Common(ItemID.FragmentNebula, 1, 10, 20),
                ItemDropRule.Common(ItemID.FragmentStardust, 1, 10, 20),
            };
            itemLoot.Add(new OneFromRulesRule(1, celestialFragments));

            // Chance to drop any Fragment or Luminite bricks
            IItemDropRule[] celestialBricks = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.SolarBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.VortexBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.NebulaBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.StardustBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.LunarBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.LunarRustBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.DarkCelestialBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.AstraBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.CosmicEmberBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.CryocoreBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.MercuryBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.StarRoyaleBrick, 1, 25, 50),
                ItemDropRule.Common(ItemID.HeavenforgeBrick, 1, 25, 50),
            };
            itemLoot.Add(new OneFromRulesRule(3, celestialBricks));

            // Golden Delight, because why not? You pretty much win the game anyway.
            IItemDropRule[] deliciousFood = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GoldenDelight, 1, 2, 5),
                ItemDropRule.Common(ItemID.Bacon, 1, 2, 5),
            };
            itemLoot.Add(new OneFromRulesRule(5, deliciousFood));

            // Functional statues drop chance.
            IItemDropRule[] statues = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.HeartStatue, 1, 3, 3),
                ItemDropRule.Common(ItemID.StarStatue, 1, 3, 3),
                ItemDropRule.Common(ItemID.KingStatue, 1, 3, 3),
                ItemDropRule.Common(ItemID.QueenStatue, 1, 3, 3)
            };
            itemLoot.Add(new OneFromRulesRule(5, statues));

            // Ore drop chance.
            IItemDropRule[] oreDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.CopperOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.TinOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.LeadOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.IronOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.SilverOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.TungstenOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.GoldOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.PlatinumOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.DemoniteOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.CrimtaneOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.Meteorite, 1, 20, 60),
                ItemDropRule.Common(ItemID.Hellstone, 1, 20, 60),
                ItemDropRule.Common(ItemID.PalladiumOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.CobaltOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.MythrilOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.OrichalcumOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.AdamantiteOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.TitaniumOre, 1, 20, 60),
                ItemDropRule.Common(ItemID.ChlorophyteOre, 1, 20, 60),
            };
            itemLoot.Add(new OneFromRulesRule(3, oreDrop));

            // Bar drop chance.
            IItemDropRule[] barDrop = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.CopperBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.TinBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.LeadBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.IronBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.SilverBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.TungstenBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.GoldBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.PlatinumBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.DemoniteBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.CrimtaneBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.MeteoriteBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.HellstoneBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.PalladiumBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.CobaltBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.MythrilBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.OrichalcumBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.AdamantiteBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.TitaniumBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.ChlorophyteBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.SpectreBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.HallowedBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.ShroomiteBar, 1, 10, 30),
                ItemDropRule.Common(ItemID.LunarBar, 1, 10, 30),
            };
            itemLoot.Add(new OneFromRulesRule(3, barDrop));

            // Drop a random dev item
            IItemDropRule[] devItems = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.AaronsHelmet, 1, 1, 1),
                ItemDropRule.Common(ItemID.AaronsBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.AaronsLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.ArkhalisHat, 1, 1, 1),
                ItemDropRule.Common(ItemID.ArkhalisPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.ArkhalisShirt, 1, 1, 1),
                ItemDropRule.Common(ItemID.ArkhalisWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.Arkhalis, 1, 1, 1),
                ItemDropRule.Common(ItemID.CenxsBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.CenxsDress, 1, 1, 1),
                ItemDropRule.Common(ItemID.CenxsDressPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.CenxsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.CenxsLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.CenxsTiara, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrownosMask, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrownosBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrownosLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.CrownosWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.DTownsHelmet, 1, 1, 1),
                ItemDropRule.Common(ItemID.DTownsBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.DTownsLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.DTownsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.JimsBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.JimsHelmet, 1, 1, 1),
                ItemDropRule.Common(ItemID.JimsLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.JimsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.BejeweledValkyrieBody, 1, 1, 1),
                ItemDropRule.Common(ItemID.BejeweledValkyrieHead, 1, 1, 1),
                ItemDropRule.Common(ItemID.BejeweledValkyrieWing, 1, 1, 1),
                ItemDropRule.Common(ItemID.ValkyrieYoyo, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeinforsAccessory, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeinforsHat, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeinforsPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeinforsShirt, 1, 1, 1),
                ItemDropRule.Common(ItemID.LeinforsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.LokisDye, 1, 1, 1),
                ItemDropRule.Common(ItemID.LokisHelm, 1, 1, 1),
                ItemDropRule.Common(ItemID.LokisPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.LokisShirt, 1, 1, 1),
                ItemDropRule.Common(ItemID.LokisWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedsHelmet, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedsLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedsBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.RedsYoyo, 1, 1, 1),
                ItemDropRule.Common(ItemID.SkiphsHelm, 1, 1, 1),
                ItemDropRule.Common(ItemID.SkiphsPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.SkiphsShirt, 1, 1, 1),
                ItemDropRule.Common(ItemID.SkiphsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.DevDye, 1, 1, 1),
                ItemDropRule.Common(ItemID.WillsHelmet, 1, 1, 1),
                ItemDropRule.Common(ItemID.WillsBreastplate, 1, 1, 1),
                ItemDropRule.Common(ItemID.WillsLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.WillsWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.Yoraiz0rDarkness, 1, 1, 1),
                ItemDropRule.Common(ItemID.Yoraiz0rHead, 1, 1, 1),
                ItemDropRule.Common(ItemID.Yoraiz0rPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.Yoraiz0rShirt, 1, 1, 1),
                ItemDropRule.Common(ItemID.Yoraiz0rWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.GroxTheGreatArmor, 1, 1, 1),
                ItemDropRule.Common(ItemID.GroxTheGreatGreaves, 1, 1, 1),
                ItemDropRule.Common(ItemID.GroxTheGreatHelm, 1, 1, 1),
                ItemDropRule.Common(ItemID.GroxTheGreatWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.FoodBarbarianArmor, 1, 1, 1),
                ItemDropRule.Common(ItemID.FoodBarbarianGreaves, 1, 1, 1),
                ItemDropRule.Common(ItemID.FoodBarbarianHelm, 1, 1, 1),
                ItemDropRule.Common(ItemID.FoodBarbarianWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.SafemanDressLeggings, 1, 1, 1),
                ItemDropRule.Common(ItemID.SafemanSunDress, 1, 1, 1),
                ItemDropRule.Common(ItemID.SafemanSunHair, 1, 1, 1),
                ItemDropRule.Common(ItemID.SafemanWings, 1, 1, 1),
                ItemDropRule.Common(ItemID.GhostarPants, 1, 1, 1),
                ItemDropRule.Common(ItemID.GhostarShirt, 1, 1, 1),
                ItemDropRule.Common(ItemID.GhostarSkullPin, 1, 1, 1),
                ItemDropRule.Common(ItemID.GhostarsWings, 1, 1, 1)
            };
            itemLoot.Add(new OneFromRulesRule(4, devItems));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 5, 10),
                ItemDropRule.Common(ItemID.MasterBait, 1, 5, 10),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}