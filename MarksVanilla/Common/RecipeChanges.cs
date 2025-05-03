using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace MarksVanilla.Common
{

    //make another array that stores all final recipes, and say if recipe != recipe

    public class RecipeChanges : ModSystem
    {
    
        public Recipe[] RevampedRecipes = {};
        


        //pulls from already existing recipes, smaller if done before adding new ones
        public override void PostAddRecipes(){
            // declare item ids for all recipes I want to disable
            short[] disabledRecipes = {};
            disabledRecipes = [ItemID.Flamarang, ItemID.AdamantiteBar, ItemID.TitaniumBar, ItemID.MeteoriteBar, ItemID.HellstoneBar, ItemID.ChlorophyteBar];

        
            for (int i = 0; i < disabledRecipes.Length; i++){
            
                for (int j = 0; j < Recipe.numRecipes; j++){

                    Recipe recipe = Main.recipe[j]; //grab the recipe in question

                    if (recipe.HasResult(disabledRecipes[i]) && Array.IndexOf(RevampedRecipes, recipe) == -1){ //cross reference the 2 arrays

                        recipe.DisableRecipe(); //disable the recipe if needed

                        continue; //skip the remainder of the array and go to next 1D index
                    }
                }
            }


        }

        public override void AddRecipes() // This is where we get to add our custom recipes
        {
            // Flamarang Recipe
            Recipe recipe1 = Recipe.Create(ItemID.Flamarang); //this makes a new recipe for the Flamarang
            recipe1.AddIngredient(ItemID.HellstoneBar, 15);
            recipe1.AddIngredient(ItemID.EnchantedBoomerang, 1);
            recipe1.AddTile(TileID.Anvils); //crafted at anvils
            recipe1.Register(); //finalize recipe



            // Meteorite Bars
            Recipe recipe2 = Recipe.Create(ItemID.MeteoriteBar); //this makes a new recipe for Meteorite Bars
            recipe2.AddIngredient(ItemID.Meteorite, 4);
            recipe2.AddTile(TileID.Furnaces); //crafted at furnaces
            recipe2.Register(); //finalize recipe


            // Hellstone Bars
            Recipe recipe3 = Recipe.Create(ItemID.HellstoneBar); //this makes a new recipe for Hellstone Bars
            recipe3.AddIngredient(ItemID.Hellstone, 4);
            recipe3.AddIngredient(ItemID.Obsidian, 1);
            recipe3.AddTile(TileID.Hellforge); //crafted at anvil
            recipe3.Register(); //finalize recipe


            //Adamantite Bars
            Recipe recipe4 = Recipe.Create(ItemID.AdamantiteBar); //this makes a new recipe for Adamantite Bars
            recipe4.AddIngredient(ItemID.AdamantiteOre, 5);
            recipe4.AddTile(TileID.AdamantiteForge); //crafted at adamantite forge
            recipe4.Register(); //finalize recipe


            // Titanium Bars
            Recipe recipe5 = Recipe.Create(ItemID.TitaniumBar); //this makes a new recipe for Titanium Bars
            recipe5.AddIngredient(ItemID.TitaniumOre, 5);
            recipe5.AddTile(TileID.AdamantiteForge); //crafted at adamantite forge
            recipe5.Register(); //finalize recipe


            // Chlorophyte Bars
            Recipe recipe6 = Recipe.Create(ItemID.ChlorophyteBar); //this makes a new recipe for Chlorophyte Bars
            recipe6.AddIngredient(ItemID.ChlorophyteOre, 6);
            recipe6.AddTile(TileID.AdamantiteForge); //crafted at adamantite forge
            recipe6.Register(); //finalize recipe


            RevampedRecipes = [recipe1, recipe2, recipe3, recipe4, recipe5, recipe6];

        }

    }

}