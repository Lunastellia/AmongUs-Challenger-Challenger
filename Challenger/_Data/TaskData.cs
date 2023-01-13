using System.Linq;
using HarmonyLib;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Roles;

namespace ChallengerMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
    public class CompleteTask
    {

        public static void Postfix(PlayerControl __instance)


        {

            if ((__instance == Crewmate1.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate1Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate1Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate1Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate1Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate1Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate1Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate1Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate1Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate1Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate1Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate1Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate1Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate1Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate1Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate1Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate1Task = 15f;
                }
                return;
            }

            if ((__instance == Crewmate2.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate2Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate2Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate2Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate2Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate2Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate2Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate2Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate2Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate2Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate2Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate2Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate2Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate2Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate2Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate2Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate2Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate3.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate3Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate3Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate3Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate3Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate3Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate3Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate3Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate3Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate3Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate3Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate3Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate3Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate3Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate3Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate3Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate3Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate4.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate4Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate4Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate4Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate4Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate4Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate4Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate4Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate4Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate4Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate4Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate4Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate4Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate4Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate4Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate4Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate4Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate5.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate5Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate5Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate5Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate5Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate5Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate5Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate5Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate5Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate5Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate5Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate5Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate5Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate5Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate5Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate5Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate5Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate6.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate6Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate6Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate6Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate6Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate6Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate6Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate6Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate6Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate6Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate6Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate6Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate6Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate6Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate6Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate6Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate6Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate7.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate7Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate7Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate7Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate7Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate7Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate7Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate7Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate7Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate7Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate7Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate7Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate7Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate7Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate7Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate7Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate7Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate8.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate8Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate8Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate8Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate8Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate8Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate8Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate8Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate8Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate8Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate8Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate8Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate8Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate8Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate8Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate8Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate8Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate9.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate9Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate9Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate9Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate9Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate9Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate9Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate9Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate9Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate9Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate9Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate9Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate9Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate9Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate9Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate9Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate9Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate10.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate10Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate10Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate10Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate10Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate10Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate10Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate10Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate10Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate10Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate10Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate10Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate10Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate10Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate10Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate10Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate10Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate11.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate11Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate11Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate11Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate11Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate11Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate11Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate11Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate11Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate11Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate11Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate11Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate11Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate11Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate11Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate11Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate11Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate12.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate12Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate12Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate12Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate12Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate12Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate12Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate12Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate12Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate12Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate12Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate12Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate12Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate12Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate12Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate12Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate12Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate13.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate13Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate13Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate13Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate13Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate13Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate13Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate13Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate13Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate13Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate13Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate13Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate13Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate13Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate13Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate13Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate13Task = 15f;
                }
                return;
            }
            if ((__instance == Crewmate14.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Crewmate14Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Crewmate14Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Crewmate14Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Crewmate14Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Crewmate14Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Crewmate14Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Crewmate14Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Crewmate14Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Crewmate14Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Crewmate14Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Crewmate14Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Crewmate14Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Crewmate14Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Crewmate14Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Crewmate14Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Crewmate14Task = 15f;
                }
                return;
            }
            if ((__instance == Sheriff1.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Sheriff1Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Sheriff1Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Sheriff1Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Sheriff1Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Sheriff1Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Sheriff1Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Sheriff1Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Sheriff1Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Sheriff1Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Sheriff1Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Sheriff1Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Sheriff1Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Sheriff1Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Sheriff1Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Sheriff1Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Sheriff1Task = 15f;
                }
                return;
            }
            if ((__instance == Sheriff2.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Sheriff2Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Sheriff2Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Sheriff2Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Sheriff2Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Sheriff2Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Sheriff2Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Sheriff2Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Sheriff2Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Sheriff2Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Sheriff2Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Sheriff2Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Sheriff2Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Sheriff2Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Sheriff2Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Sheriff2Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Sheriff2Task = 15f;
                }
                return;
            }
            if ((__instance == Sheriff3.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Sheriff3Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Sheriff3Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Sheriff3Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Sheriff3Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Sheriff3Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Sheriff3Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Sheriff3Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Sheriff3Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Sheriff3Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Sheriff3Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Sheriff3Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Sheriff3Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Sheriff3Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Sheriff3Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Sheriff3Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Sheriff3Task = 15f;
                }
                return;
            }
            if ((__instance == Guardian.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    GuardianTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    GuardianTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    GuardianTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    GuardianTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    GuardianTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    GuardianTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    GuardianTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    GuardianTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    GuardianTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    GuardianTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    GuardianTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    GuardianTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    GuardianTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    GuardianTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    GuardianTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    GuardianTask = 15f;
                }
                return;
            }
            if ((__instance == Engineer.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    EngineerTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    EngineerTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    EngineerTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    EngineerTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    EngineerTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    EngineerTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    EngineerTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    EngineerTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    EngineerTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    EngineerTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    EngineerTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    EngineerTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    EngineerTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    EngineerTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    EngineerTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    EngineerTask = 15f;
                }
                return;
            }
            if ((__instance == Timelord.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    TimelordTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    TimelordTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    TimelordTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    TimelordTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    TimelordTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    TimelordTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    TimelordTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    TimelordTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    TimelordTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    TimelordTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    TimelordTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    TimelordTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    TimelordTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    TimelordTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    TimelordTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    TimelordTask = 15f;
                }
                return;
            }
            if ((__instance == Hunter.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    HunterTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    HunterTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    HunterTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    HunterTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    HunterTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    HunterTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    HunterTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    HunterTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    HunterTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    HunterTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    HunterTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    HunterTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    HunterTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    HunterTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    HunterTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    HunterTask = 15f;
                }
                return;
            }
            if ((__instance == Mystic.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    MysticTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    MysticTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    MysticTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    MysticTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    MysticTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    MysticTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    MysticTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    MysticTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    MysticTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    MysticTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    MysticTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    MysticTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    MysticTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    MysticTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    MysticTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    MysticTask = 15f;
                }
                return;
            }
            if ((__instance == Spirit.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    SpiritTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    SpiritTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    SpiritTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    SpiritTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    SpiritTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    SpiritTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    SpiritTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    SpiritTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    SpiritTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    SpiritTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    SpiritTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    SpiritTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    SpiritTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    SpiritTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    SpiritTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    SpiritTask = 15f;
                }
                return;
            }
            if ((__instance == Mayor.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                var tasksLeft = TaskData.Count(x => !x.Complete);

                if (tasksLeft == 0)
                {
                    Mayor.TaskEND = true;
                }
                else { }


                if (tasksFinish == 0)
                {
                    MayorTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    MayorTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    MayorTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    MayorTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    MayorTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    MayorTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    MayorTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    MayorTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    MayorTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    MayorTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    MayorTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    MayorTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    MayorTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    MayorTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    MayorTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    MayorTask = 15f;
                }
                return;
            }
            if ((__instance == Detective.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    DetectiveTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    DetectiveTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    DetectiveTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    DetectiveTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    DetectiveTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    DetectiveTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    DetectiveTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    DetectiveTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    DetectiveTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    DetectiveTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    DetectiveTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    DetectiveTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    DetectiveTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    DetectiveTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    DetectiveTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    DetectiveTask = 15f;
                }
                return;
            }
            if ((__instance == Nightwatch.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    NightwatchTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    NightwatchTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    NightwatchTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    NightwatchTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    NightwatchTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    NightwatchTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    NightwatchTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    NightwatchTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    NightwatchTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    NightwatchTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    NightwatchTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    NightwatchTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    NightwatchTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    NightwatchTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    NightwatchTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    NightwatchTask = 15f;
                }
                return;
            }
            if ((__instance == Spy.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    SpyTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    SpyTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    SpyTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    SpyTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    SpyTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    SpyTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    SpyTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    SpyTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    SpyTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    SpyTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    SpyTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    SpyTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    SpyTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    SpyTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    SpyTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    SpyTask = 15f;
                }
                return;
            }
            if ((__instance == Informant.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                var tasksLeft = TaskData.Count(x => !x.Complete);
                
                if (tasksLeft == 0)
                {
                    Informant.TaskEND = true;
                }
                else { }
                

                if (tasksFinish == 0)
                {
                    InformantTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    InformantTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    InformantTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    InformantTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    InformantTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    InformantTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    InformantTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    InformantTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    InformantTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    InformantTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    InformantTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    InformantTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    InformantTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    InformantTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    InformantTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    InformantTask = 15f;
                }
                return;
            }
            if ((__instance == Bait.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    BaitTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    BaitTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    BaitTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    BaitTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    BaitTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    BaitTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    BaitTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    BaitTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    BaitTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    BaitTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    BaitTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    BaitTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    BaitTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    BaitTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    BaitTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    BaitTask = 15f;
                }
                return;
            }
            if ((__instance == Mentalist.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    MentalistTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    MentalistTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    MentalistTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    MentalistTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    MentalistTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    MentalistTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    MentalistTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    MentalistTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    MentalistTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    MentalistTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    MentalistTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    MentalistTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    MentalistTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    MentalistTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    MentalistTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    MentalistTask = 15f;
                }
                return;
            }
            if ((__instance == Builder.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    BuilderTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    BuilderTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    BuilderTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    BuilderTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    BuilderTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    BuilderTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    BuilderTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    BuilderTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    BuilderTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    BuilderTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    BuilderTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    BuilderTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    BuilderTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    BuilderTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    BuilderTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    BuilderTask = 15f;
                }
                return;
            }
            if ((__instance == Dictator.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    DictatorTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    DictatorTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    DictatorTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    DictatorTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    DictatorTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    DictatorTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    DictatorTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    DictatorTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    DictatorTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    DictatorTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    DictatorTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    DictatorTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    DictatorTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    DictatorTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    DictatorTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    DictatorTask = 15f;
                }
                return;
            }
            if ((__instance == Sentinel.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    SentinelTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    SentinelTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    SentinelTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    SentinelTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    SentinelTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    SentinelTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    SentinelTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    SentinelTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    SentinelTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    SentinelTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    SentinelTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    SentinelTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    SentinelTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    SentinelTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    SentinelTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    SentinelTask = 15f;
                }
                return;
            }
            if ((__instance == Teammate1.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Teammate1Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Teammate1Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Teammate1Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Teammate1Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Teammate1Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Teammate1Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Teammate1Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Teammate1Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Teammate1Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Teammate1Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Teammate1Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Teammate1Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Teammate1Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Teammate1Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Teammate1Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Teammate1Task = 15f;
                }
                return;
            }
            if ((__instance == Teammate2.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    Teammate2Task = 0f;
                }
                if (tasksFinish == 1)
                {
                    Teammate2Task = 1f;
                }
                if (tasksFinish == 2)
                {
                    Teammate2Task = 2f;
                }
                if (tasksFinish == 3)
                {
                    Teammate2Task = 3f;
                }
                if (tasksFinish == 4)
                {
                    Teammate2Task = 4f;
                }
                if (tasksFinish == 5)
                {
                    Teammate2Task = 5f;
                }
                if (tasksFinish == 6)
                {
                    Teammate2Task = 6f;
                }
                if (tasksFinish == 7)
                {
                    Teammate2Task = 7f;
                }
                if (tasksFinish == 8)
                {
                    Teammate2Task = 8f;
                }
                if (tasksFinish == 9)
                {
                    Teammate2Task = 9f;
                }
                if (tasksFinish == 10)
                {
                    Teammate2Task = 10f;
                }
                if (tasksFinish == 11)
                {
                    Teammate2Task = 11f;
                }
                if (tasksFinish == 12)
                {
                    Teammate2Task = 12f;
                }
                if (tasksFinish == 13)
                {
                    Teammate2Task = 13f;
                }
                if (tasksFinish == 14)
                {
                    Teammate2Task = 14f;
                }
                if (tasksFinish == 15)
                {
                    Teammate2Task = 15f;
                }
                return;
            }
            if ((__instance == Lawkeeper.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                var tasksLeft = TaskData.Count(x => !x.Complete);

                if (tasksLeft == 0)
                {
                    Lawkeeper.TaskEND = true;
                }
                else { }
                if (tasksFinish == 0)
                {
                    LawkeeperTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    LawkeeperTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    LawkeeperTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    LawkeeperTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    LawkeeperTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    LawkeeperTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    LawkeeperTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    LawkeeperTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    LawkeeperTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    LawkeeperTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    LawkeeperTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    LawkeeperTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    LawkeeperTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    LawkeeperTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    LawkeeperTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    LawkeeperTask = 15f;
                }
                return;
            }
            if ((__instance == Fake.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    FakeTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    FakeTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    FakeTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    FakeTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    FakeTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    FakeTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    FakeTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    FakeTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    FakeTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    FakeTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    FakeTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    FakeTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    FakeTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    FakeTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    FakeTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    FakeTask = 15f;
                }
                return;
            }
            if ((__instance == Traveler.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    TravelerTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    TravelerTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    TravelerTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    TravelerTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    TravelerTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    TravelerTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    TravelerTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    TravelerTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    TravelerTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    TravelerTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    TravelerTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    TravelerTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    TravelerTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    TravelerTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    TravelerTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    TravelerTask = 15f;
                }
                return;
            }
            if ((__instance == Leader.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    LeaderTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    LeaderTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    LeaderTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    LeaderTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    LeaderTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    LeaderTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    LeaderTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    LeaderTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    LeaderTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    LeaderTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    LeaderTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    LeaderTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    LeaderTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    LeaderTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    LeaderTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    LeaderTask = 15f;
                }
                return;
            }
            if ((__instance == Doctor.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    DoctorTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    DoctorTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    DoctorTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    DoctorTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    DoctorTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    DoctorTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    DoctorTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    DoctorTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    DoctorTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    DoctorTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    DoctorTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    DoctorTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    DoctorTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    DoctorTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    DoctorTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    DoctorTask = 15f;
                }
                return;
            }
            if ((__instance == Slave.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    SlaveTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    SlaveTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    SlaveTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    SlaveTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    SlaveTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    SlaveTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    SlaveTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    SlaveTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    SlaveTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    SlaveTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    SlaveTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    SlaveTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    SlaveTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    SlaveTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    SlaveTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    SlaveTask = 15f;
                }
                return;
            }
            if ((__instance == Mercenary.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    MercenaryTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    MercenaryTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    MercenaryTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    MercenaryTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    MercenaryTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    MercenaryTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    MercenaryTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    MercenaryTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    MercenaryTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    MercenaryTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    MercenaryTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    MercenaryTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    MercenaryTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    MercenaryTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    MercenaryTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    MercenaryTask = 15f;
                }
                return;
            }
            if ((__instance == CopyCat.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                var tasksLeft = TaskData.Count(x => !x.Complete);

                if (tasksLeft == 0)
                {
                    CopyCat.TaskEND = true;
                }
                else { }

                if (tasksFinish == 0)
                {
                    CopyCatTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    CopyCatTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    CopyCatTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    CopyCatTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    CopyCatTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    CopyCatTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    CopyCatTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    CopyCatTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    CopyCatTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    CopyCatTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    CopyCatTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    CopyCatTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    CopyCatTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    CopyCatTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    CopyCatTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    CopyCatTask = 15f;
                }
                return;
            }
            if ((__instance == Revenger.Role))
            {
                var TaskData = __instance.Data.Tasks.ToArray();
                var tasksFinish = TaskData.Count(x => x.Complete);
                if (tasksFinish == 0)
                {
                    RevengerTask = 0f;
                }
                if (tasksFinish == 1)
                {
                    RevengerTask = 1f;
                }
                if (tasksFinish == 2)
                {
                    RevengerTask = 2f;
                }
                if (tasksFinish == 3)
                {
                    RevengerTask = 3f;
                }
                if (tasksFinish == 4)
                {
                    RevengerTask = 4f;
                }
                if (tasksFinish == 5)
                {
                    RevengerTask = 5f;
                }
                if (tasksFinish == 6)
                {
                    RevengerTask = 6f;
                }
                if (tasksFinish == 7)
                {
                    RevengerTask = 7f;
                }
                if (tasksFinish == 8)
                {
                    RevengerTask = 8f;
                }
                if (tasksFinish == 9)
                {
                    RevengerTask = 9f;
                }
                if (tasksFinish == 10)
                {
                    RevengerTask = 10f;
                }
                if (tasksFinish == 11)
                {
                    RevengerTask = 11f;
                }
                if (tasksFinish == 12)
                {
                    RevengerTask = 12f;
                }
                if (tasksFinish == 13)
                {
                    RevengerTask = 13f;
                }
                if (tasksFinish == 14)
                {
                    RevengerTask = 14f;
                }
                if (tasksFinish == 15)
                {
                    RevengerTask = 15f;
                }
                return;
            }

        }
    }
}