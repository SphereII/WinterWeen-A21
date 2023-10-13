using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace Harmony.Dialog
{
    public class DialogStatementPatches
    {
        /*
         * This patch is necessary to allow actions to be added to a statement. The game already supports actions to statements,
         * but the GetRespones() doesn't create a full response for the [ Next ] lines. It just returns a pre-generated " [Next]"
         * to pass the NextStatementID. Instead, we'll loop around and grab the full reference to it.
         */
        [HarmonyPatch(typeof(DialogStatement))]
        [HarmonyPatch("GetResponses")]
        public class DialogStatementGetResponses
        {
            public static void Postfix(DialogStatement __instance, ref List<BaseResponseEntry> __result)
            {
                foreach (var responses in __result)
                {
                    var statementID = responses.Response.NextStatementID;
                    foreach (var t in __instance.OwnerDialog.Statements)
                    {
                        if (t.NextStatementID != statementID) continue;
                        responses.Response.Actions = t.Actions;
                        break;
                    }
                }
            }
        } 
    }
}