//Loadout script by Mka0207@fwkzt.com

using System;
using System.Globalization;

namespace Oxide.Plugins
{
	//Register our plugin
	[Info("FWKZTPlug", "Mka0207", "0.1")]
	
	class Loadouts : RustPlugin 
	{	
		int GetHoursSinceLastWipe()
		{
			//Get the current time.
			DateTime CurrentDate = DateTime.Now;
			
			//Store the time the rust server was wiped, EXACT time.
			DateTime LastWipeDate = new DateTime(2019, 11, 28, 16, 0, 0);
			
			//Get how many hours its been since the server wiped.
			double LastWipeHours = (CurrentDate - LastWipeDate).TotalHours;

			//Convert it to a integer.
			int NumHrs = Convert.ToInt32( Math.Round( LastWipeHours ) );
			
			return NumHrs;
		}

		//Grab the number of current online players.
		int GetPlayerCount()
		{
			int Counter = 0;
			
			foreach ( BasePlayer player in BasePlayer.activePlayerList )
			{
				Counter++;
			}
			
			return Counter;
		}
		//Easy function for broadcasting the wipe time.
		void AnnounceWipeTime()
		{
			if ( GetHoursSinceLastWipe() <= 48 )
			{
				string AdjustedTime = GetHoursSinceLastWipe().ToString();
				PrintToChat("Last Wipe : " + AdjustedTime + " hours ago." );
			}
			else
			{
				int Hours2Days = GetHoursSinceLastWipe()/24;
				string AdjustedTime = Hours2Days.ToString();
				PrintToChat("Last Wipe : " + AdjustedTime + " days ago." );
			}
		}
		//Runs when the plugin is loaded.
		void Loaded()
		{
			//Create our advert timers.
			timer.Repeat(290, 0, () =>
			{
				string PlyAmnt = GetPlayerCount().ToString();
				PrintToChat("Check us out @ discord.me/fwkzt" );
			});
			timer.Repeat(360f, 0, () =>
			{
				string PlyAmnt = GetPlayerCount().ToString();
				PrintToChat( PlyAmnt + " players are currently online." );
			});
			timer.Repeat(420f, 0, () =>
			{
				AnnounceWipeTime();
			});
			//Let the players know our plugin loaded.
			PrintToChat("FWKZT Plugin has been Updated.");
		}
		
		//Calls when the plugin is unloaded.
		void UnLoaded()
		{
		}
		
		//Give out loadouts based on the number of days passed since wipe.
		//Todo; Setup limits for how many times a player can get these free items?
		void OnPlayerRespawned(BasePlayer player)
		{
			//Wipe Day Zero
			if ( GetHoursSinceLastWipe() <= 24 )
			{
				player.inventory.GiveItem( ItemManager.CreateByName("coal") );
			}
			else
			{
				//First Day
				if ( GetHoursSinceLastWipe()/24 >= 1 && GetHoursSinceLastWipe()/24 < 2 )
				{
					player.inventory.GiveItem( ItemManager.CreateByName("cloth", 30) );
					player.inventory.GiveItem( ItemManager.CreateByName("apple", 3) );
				}
				//Second Day
				else if ( GetHoursSinceLastWipe()/24 >= 2 && GetHoursSinceLastWipe()/24 < 3 )
				{
					player.inventory.GiveItem( ItemManager.CreateByName("stone.pickaxe") );
					player.inventory.GiveItem( ItemManager.CreateByName("cloth", 50) );
					player.inventory.GiveItem( ItemManager.CreateByName("apple", 4) );
				}
				//Third Day
				else if ( GetHoursSinceLastWipe()/24 >= 3 && GetHoursSinceLastWipe()/24 < 4 )
				{
					player.inventory.GiveItem(ItemManager.CreateByName("stonehatchet"));
					player.inventory.GiveItem( ItemManager.CreateByName("stone.pickaxe") );
					player.inventory.GiveItem(ItemManager.CreateByName("arrow.wooden", 20));
					player.inventory.GiveItem(ItemManager.CreateByName("crossbow"));
					player.inventory.GiveItem( ItemManager.CreateByName("cloth", 50) );
					player.inventory.GiveItem( ItemManager.CreateByName("apple", 4) );
				}
				//Fourth Day
				else if ( GetHoursSinceLastWipe()/24 >= 4 && GetHoursSinceLastWipe()/24 < 5 )
				{
					player.inventory.GiveItem(ItemManager.CreateByName("stonehatchet"));
					player.inventory.GiveItem( ItemManager.CreateByName("stone.pickaxe") );
					player.inventory.GiveItem(ItemManager.CreateByName("arrow.wooden", 20));
					player.inventory.GiveItem(ItemManager.CreateByName("crossbow"));
					player.inventory.GiveItem( ItemManager.CreateByName("cloth", 50) );
					player.inventory.GiveItem( ItemManager.CreateByName("apple", 4) );
				}
			}
		}
	}
}
