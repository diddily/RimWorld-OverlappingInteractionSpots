using HarmonyLib;
using System.Reflection;
using RimWorld;
using Verse;

namespace OverlappingInteractionSpots
{
	[StaticConstructorOnStartup]
	public class OverlappingInteractionSpots : Mod
	{
		public OverlappingInteractionSpots(ModContentPack content)
			: base(content)
		{
			new Harmony("diddily.OverlappingInteractionSpots").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
	
	[HarmonyPatch(typeof(PlaceWorker_PreventInteractionSpotOverlap), "AllowsPlacing")]
	class PlaceWorker_PreventInteractionSpotOverlap_AllowsPlacing
	{
		public static bool Prefix(ref AcceptanceReport __result)
		{
			__result = true;
			return false;
		}
	}
}  