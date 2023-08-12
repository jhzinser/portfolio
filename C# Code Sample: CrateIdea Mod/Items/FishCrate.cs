using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrateIdea.Items
{
    public class FishCrate : ModItem
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
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FishCrate>());
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
            // Themed drops are "functional" fish or Oysters.
            int[] themedDrops = new int[] {
                ItemID.PurpleClubberfish,
                ItemID.BalloonPufferfish,
                ItemID.ReaverShark,
                ItemID.Rockfish,
                ItemID.SawtoothShark,
                ItemID.Swordfish,
                ItemID.Oyster,
            };
            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

            // Drop coins
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 5, 40));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 1, 3));

            // Normal Fish table.
            IItemDropRule[] normalFishTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.AtlanticCod, 1, 1, 3),
                ItemDropRule.Common(ItemID.Bass, 1, 1, 3),
                ItemDropRule.Common(ItemID.Salmon, 1, 1, 3),
                ItemDropRule.Common(ItemID.RedSnapper, 1, 1, 3),
                ItemDropRule.Common(ItemID.Shrimp, 1, 1, 3),
                ItemDropRule.Common(ItemID.Trout, 1, 1, 3),
                ItemDropRule.Common(ItemID.Tuna, 1, 1, 3),
                ItemDropRule.Common(ItemID.Flounder, 1, 1, 3),
                ItemDropRule.Common(ItemID.RockLobster, 1, 1, 3),
                ItemDropRule.Common(ItemID.NeonTetra, 1, 1, 3),
            };
            itemLoot.Add(new OneFromRulesRule(1, normalFishTypes));

            // Uncommon Fish table.
            IItemDropRule[] uncommonFishTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.ArmoredCavefish, 1, 1, 3),
                ItemDropRule.Common(ItemID.BlueJellyfish, 1, 1, 3),
                ItemDropRule.Common(ItemID.CrimsonTigerfish, 1, 1, 3),
                ItemDropRule.Common(ItemID.Damselfish, 1, 1, 3),
                ItemDropRule.Common(ItemID.DoubleCod, 1, 1, 3),
                ItemDropRule.Common(ItemID.Ebonkoi, 1, 1, 3),
                ItemDropRule.Common(ItemID.FrostMinnow, 1, 1, 3),
                ItemDropRule.Common(ItemID.PinkJellyfish, 1, 1, 3),
                ItemDropRule.Common(ItemID.Hemopiranha, 1, 1, 3),
                ItemDropRule.Common(ItemID.Honeyfin, 1, 1, 3),
                ItemDropRule.Common(ItemID.SpecularFish, 1, 1, 3),
                ItemDropRule.Common(ItemID.Stinkfish, 1, 1, 3),
                ItemDropRule.Common(ItemID.VariegatedLardfish, 1, 1, 3),
            };
            itemLoot.Add(new OneFromRulesRule(3, uncommonFishTypes));

            // Lava Fish table.
            IItemDropRule[] lavaFishTypes = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FlarefinKoi, 1, 1, 3),
                ItemDropRule.Common(ItemID.Obsidifish, 1, 1, 3),
            };
            itemLoot.Add(new OneFromRulesRule(7, lavaFishTypes));


            // Smaller chance at a Quest Fish.
            IItemDropRule[] questFish = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.AmanitaFungifin, 1, 1, 1),
                ItemDropRule.Common(ItemID.Angelfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Batfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.BloodyManowar, 1, 1, 1),
                ItemDropRule.Common(ItemID.Bonefish, 1, 1, 1),
                ItemDropRule.Common(ItemID.BumblebeeTuna, 1, 1, 1),
                ItemDropRule.Common(ItemID.CapnTunabeard, 1, 1, 1),
                ItemDropRule.Common(ItemID.Catfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Cloudfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Clownfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Cursedfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.DemonicHellfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Derpfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Dirtfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.DynamiteFish, 1, 1, 1),
                ItemDropRule.Common(ItemID.EaterofPlankton, 1, 1, 1),
                ItemDropRule.Common(ItemID.FallenStarfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Fishotron, 1, 1, 1),
                ItemDropRule.Common(ItemID.TheFishofCthulu, 1, 1, 1),
                ItemDropRule.Common(ItemID.Fishron, 1, 1, 1),
                ItemDropRule.Common(ItemID.GuideVoodooFish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Harpyfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Hungerfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Ichorfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.InfectedScabbardfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Jewelfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.MirageFish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Mudfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.MutantFlinxfin, 1, 1, 1),
                ItemDropRule.Common(ItemID.Pengfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Pixiefish, 1, 1, 1),
                ItemDropRule.Common(ItemID.ScarabFish, 1, 1, 1),
                ItemDropRule.Common(ItemID.ScorpioFish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Slimefish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Spiderfish, 1, 1, 1),
                ItemDropRule.Common(ItemID.TropicalBarracuda, 1, 1, 1),
                ItemDropRule.Common(ItemID.TundraTrout, 1, 1, 1),
                ItemDropRule.Common(ItemID.UnicornFish, 1, 1, 1),
                ItemDropRule.Common(ItemID.Wyverntail, 1, 1, 1),
                ItemDropRule.Common(ItemID.ZombieFish, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(10, questFish));

            // Sure, why not just drop a Seafood Dinner chance in there? It's fish.
            IItemDropRule[] dinnerTable = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.SeafoodDinner, 1, 1, 3),
            };
            itemLoot.Add(new OneFromRulesRule(6, dinnerTable));

            // Golden Carp chance!
            IItemDropRule[] goldenCarp = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.GoldenCarp, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(40, goldenCarp));

            // Consumable functional fish
            IItemDropRule[] functionalFish = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.BombFish, 1, 3, 8),
                ItemDropRule.Common(ItemID.FrostDaggerfish, 1, 75, 150),
            };
            itemLoot.Add(new OneFromRulesRule(5, functionalFish));

            // VERY SMALL CHANCE at the Minishark.
            IItemDropRule[] minisharkTable = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.Minishark, 1, 1, 1),
                ItemDropRule.Common(ItemID.TinCan, 1, 1, 1),
            };
            itemLoot.Add(new OneFromRulesRule(210, minisharkTable));

            // Fishing potions, because why not?
            IItemDropRule[] fishingPotionChance = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.FishingPotion, 1, 2, 5),
                ItemDropRule.Common(ItemID.CratePotion, 1, 2, 5),
                ItemDropRule.Common(ItemID.SonarPotion, 1, 2, 5),
            };
            itemLoot.Add(new OneFromRulesRule(20, fishingPotionChance));

            // Drop (high-end) bait
            IItemDropRule[] highendBait = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 7),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 7),
            };
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}