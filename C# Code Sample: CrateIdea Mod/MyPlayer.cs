
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.Core;
using Terraria.ModLoader.IO;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using CrateIdea.Items;

namespace CrateIdea
{
    public class MyPlayer : ModPlayer
    {
        public override void CatchFish(
          FishingAttempt attempt,
          ref int itemDrop,
          ref int npcSpawn,
          ref AdvancedPopupRequest sonar,
          ref Vector2 sonarPosition)
        {
            //Prehardmode Crates
            if (!Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<SwordCrate>();
            }
            if (!Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<ArcherCrate>();
            }
            if (!Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<CoolCrate>();
            }
            if (!Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<GardenCrate>();
            }
            if (!Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<FishCrate>();
            }

            //Hardmode Crates.
            if (Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<Excalicrate>();
            }
            if (Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<SherwoodCrate>();
            }
            if (Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<CoolerCoolCrate>();
            }
            if (Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<BotanicalCrate>();
            }
            if (Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 20 : 40))
            {
                itemDrop = ModContent.ItemType<BigFishCrate>();
            }

            //The Crate of Cthulhu is a special case.
            if (NPC.downedMoonlord & Main.rand.NextBool(this.Player.cratePotion ? 35 : 70))
            {
                itemDrop = ModContent.ItemType<CrateOfCthulhu>();
            }

            //The Crate Crate and Cratest Crate get a section all on their own.
            if (!Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 200 : 400))
            {
                itemDrop = ModContent.ItemType<CrateCrate>();
            }
            if (Main.hardMode & Main.rand.NextBool(this.Player.cratePotion ? 200 : 400))
            {
                itemDrop = ModContent.ItemType<CratestCrate>();
            }

        }
    }
}
