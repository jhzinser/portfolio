using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Localization;
using CrateIdea.Items;

namespace CrateIdea
{
    public class CustomRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            //Add recipe groups for prehardmode and hardmode crates.
            //This can easily be updated as new crates are added.
            RecipeGroup crateIdeaCrates = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} Prehardmode Crate Idea Crate",
                ModContent.ItemType<SwordCrate>(),
                ModContent.ItemType<ArcherCrate>(),
                ModContent.ItemType<CoolCrate>(),
                ModContent.ItemType<GardenCrate>(),
                ModContent.ItemType<FishCrate>()
            ); 
            RecipeGroup crateIdeaCratesHM = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} Hardmode Crate Idea Crate",
                ModContent.ItemType<Excalicrate>(),
                ModContent.ItemType<SherwoodCrate>(),
                ModContent.ItemType<CoolerCoolCrate>(),
                ModContent.ItemType<BotanicalCrate>(),
                ModContent.ItemType<BigFishCrate>()
            );

            RecipeGroup.RegisterGroup("CrateIdeaCrate", crateIdeaCrates);
            RecipeGroup.RegisterGroup("CrateIdeaCrateHM", crateIdeaCratesHM);
        }

        public override void AddRecipes()
        {
            //Recipes to convert Crate Idea crates to vanilla crates.
            Recipe toWoodCrate = Recipe.Create(ItemID.WoodenCrate, 2);
            toWoodCrate.AddRecipeGroup("CrateIdeaCrate");
            toWoodCrate.AddTile(TileID.DemonAltar);
            toWoodCrate.DisableDecraft();
            toWoodCrate.Register();

            Recipe toIronCrate = Recipe.Create(ItemID.IronCrate);
            toIronCrate.AddRecipeGroup("CrateIdeaCrate");
            toIronCrate.AddTile(TileID.DemonAltar);
            toIronCrate.DisableDecraft();
            toIronCrate.Register();

            Recipe toGoldCrate = Recipe.Create(ItemID.GoldenCrate);
            toGoldCrate.AddRecipeGroup("CrateIdeaCrate", 3);
            toGoldCrate.AddTile(TileID.DemonAltar);
            toGoldCrate.DisableDecraft();
            toGoldCrate.Register();

            //Recipes to convert hardmode Crate Idea crates to vanilla crates.
            Recipe toWoodCrateHM = Recipe.Create(ItemID.WoodenCrateHard, 2);
            toWoodCrateHM.AddRecipeGroup("CrateIdeaCrateHM");
            toWoodCrateHM.AddTile(TileID.DemonAltar);
            toWoodCrateHM.DisableDecraft();
            toWoodCrateHM.Register();

            Recipe toIronCrateHM = Recipe.Create(ItemID.IronCrateHard);
            toIronCrateHM.AddRecipeGroup("CrateIdeaCrateHM");
            toIronCrateHM.AddTile(TileID.DemonAltar);
            toIronCrateHM.DisableDecraft();
            toIronCrateHM.Register();

            Recipe toGoldCrateHM = Recipe.Create(ItemID.GoldenCrateHard);
            toGoldCrateHM.AddRecipeGroup("CrateIdeaCrateHM", 3);
            toGoldCrateHM.AddTile(TileID.DemonAltar);
            toGoldCrateHM.DisableDecraft();
            toGoldCrateHM.Register();

        }
    }
}
