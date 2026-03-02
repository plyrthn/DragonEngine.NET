using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
#if TURN_BASED_GAME

namespace DragonEngineLibrary
{
    public static class BattleTurnManager
    {
        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_TEST", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_Test();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_SKIP_WAIT_TIME", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DELib_BattleTurnManager_SkipWaitTime(bool readOnly, bool getNextFighter);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_CHANGE_ACTION_STEP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_ChangeActionStep(ActionStep step);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_CHANGE_PHASE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_ChangePhase(TurnPhase phase);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_SWITCH_ACTIVE_FIGHTER", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_SwitchActiveFighter(uint uid, bool no_ui_change);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_SWITCH_TURN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_SwitchTurn();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_REQUESTRUNAWAY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_RequestRunAway(IntPtr fighterPtr, bool success);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_WARPFIGHTER", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_WarpFighter(IntPtr fighterPtr, ref PoseInfo inf);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_RELEASE_MENU", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_ReleaseMenu();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_FORCECOUNTERCOMMAND", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool DELib_BattleTurnManager_ForceCounterCommand(IntPtr counterFighter, IntPtr attacker, RPGSkillID skillID);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_CURRENTPHASE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TurnPhase DELib_BattleTurnManager_Getter_CurrentPhase();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_CURRENTACTIONSTEP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ActionStep DELib_BattleTurnManager_Getter_CurrentActionStep();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_ACTIONTYPE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ActionType DELib_BattleTurnManager_Getter_ActionType();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_ENDSTATE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint DELib_BattleTurnManager_Getter_EndState();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_BATTLECONFIGID", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint DELib_BattleTurnManager_Getter_BattleConfigID();


        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_REQ_PLAY_START_HACT", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool DELib_BattleTurnManager_RequestPlayStartHact();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_REQUESTHACTEVENT", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool DELib_BattleTurnManager_RequestHactEvent(ref HActRequestOptions option);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_DOEXECTURNAICOMMAND", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool DELib_BattleTurnManager_DoExecTurnAICommand(IntPtr fighter, IntPtr inf);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_EXECTURNAICOMMANDDECIDE", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool DELib_BattleTurnManager_ExecTurnAICommandDecide(IntPtr fighter);

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_RPG_CAMERA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint DELib_BattleTurnManager_Getter_RPGCamera();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_UI_ROOT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong DELib_BattleTurnManager_Getter_UI_Root();
        [DllImport("Y7Internal.dll", EntryPoint = "LIB_RPGBTLMENU_GET_RPG_MENU", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DELib_BattleTurnManager_GetRpgMenu();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_HACT_READY_UI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint DELib_BattleTurnManager_Getter_HAct_Ready_UI_Root();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_TARGET_FIGHTER", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint DELib_BattleTurnManager_Getter_Target_Fighter();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_GETTER_SELECTED_FIGHTER", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint DELib_BattleTurnManager_Getter_Selected_Fighter();

        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_SETTER_SELECTED_FIGHTER", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DELib_BattleTurnManager_Setter_Selected_Fighter(uint handle);


        [DllImport("Y7Internal.dll", EntryPoint = "LIB_BATTLETURNMANAGER_PTR", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Pointer();

        public enum TurnPhase : uint
        {
            StartWait = 0x0,
            Start = 0x1,
            Action = 0x2,
            Event = 0x3,
            Cleanup = 0x4,
            End = 0x5,
            BattleResult = 0x6,
            NumPhases = 0x7,
        };

        public enum ActionStep
        {
            Init = 0x0,
            SelectCommand = 0x1,
            SelectTarget = 0x2,
            SelectCombinaiton = 0x3,
            TriggeredEvent = 0x4,
            ActionStart = 0x5,
            Ready = 0x6,
            Action = 0x7,
            ActionFinalize = 0x8,
            ActionEnd = 0x9,
            NumActionSteps = 0xA,
        };

        public enum ActionType
        {
            None = 0x0,
            Normal = 0x1,
            Interrupt = 0x2,
            Revenge = 0x3,
            Combination = 0x4,
            NumType = 0x5,
        };

        public static EntityHandle<CameraBase> RPGCamera  
        { 
            get
            { 
                return DELib_BattleTurnManager_Getter_RPGCamera(); 
            } 
        }

        public static TurnPhase CurrentPhase { get { return DELib_BattleTurnManager_Getter_CurrentPhase(); } }
        public static ActionStep CurrentActionStep { get { return DELib_BattleTurnManager_Getter_CurrentActionStep(); } }
        public static ActionType CurrentActionType { get { return DELib_BattleTurnManager_Getter_ActionType(); } }

        public static uint EndState { get { return DELib_BattleTurnManager_Getter_EndState(); } }

        public static uint BattleConfigID { get { return DELib_BattleTurnManager_Getter_BattleConfigID(); } }

        public delegate IntPtr OverrideAttackerSelectionDelegate(IntPtr battleTurnManager, bool readOnly, bool getNextFighter);


        public static UIHandleBase UIRoot
        {
            get
            {
                return new UIHandleBase() { Handle = DELib_BattleTurnManager_Getter_UI_Root() };
            }
        }

        public static IntPtr RpgUI
        {
            get
            {
                return DELib_BattleTurnManager_GetRpgMenu(); 
            }
        }

        public static UIHandleBase HActReadyUI
        {
            get
            {
                return new UIHandleBase() { Handle = DELib_BattleTurnManager_Getter_HAct_Ready_UI_Root() };
            }
        }

        public static EntityHandle<Character> TargetFighter
        {
            get
            {
                return new EntityHandle<Character>(DELib_BattleTurnManager_Getter_Target_Fighter());
            }
        }

        public static EntityHandle<Character> SelectedFighter
        {
            get
            {
                return new EntityHandle<Character>(DELib_BattleTurnManager_Getter_Selected_Fighter());
            }
            set
            {
                DELib_BattleTurnManager_Setter_Selected_Fighter(value.UID);
            }
        }

        public static class OverrideAttackerSelectionInfo
        {
            public static Func<bool, bool, Fighter> overrideFunc;
            public static OverrideAttackerSelectionDelegate deleg;
            public static IntPtr delegPtr;
        }


        internal static IntPtr ReturnManualAttackerSelectionResult(IntPtr battleTurnManager, bool readOnly, bool getNextFighter)
        {
            if (OverrideAttackerSelectionInfo.overrideFunc == null)
            {
                //no overrides, CPP library should jump to trampoline after getting 0
                return IntPtr.Zero;
            }
            else
            {
                //CPP library will return what we returned
                Fighter result = OverrideAttackerSelectionInfo.overrideFunc(readOnly, getNextFighter);
                IntPtr ptr;

                ptr = result._ptr;

                return ptr;
            }
        }

        /// <summary>
        /// Manually decide who attacks when the game wants to pick an attacker.
        /// </summary>
        public static void OverrideAttackerSelection(Func<bool, bool, Fighter> function)
        {
            OverrideAttackerSelectionInfo.overrideFunc = function;
        }

        public static void OverrideAttackerSelection2(Func<IntPtr, bool, bool, IntPtr> function)
        {
            if(function == null)
            {
                BattleTurnManager.OverrideAttackerSelectionInfo.deleg = null;
                BattleTurnManager.OverrideAttackerSelectionInfo.delegPtr = IntPtr.Zero;
            }
            else
            {
                BattleTurnManager.OverrideAttackerSelectionInfo.deleg = new BattleTurnManager.OverrideAttackerSelectionDelegate(function);
                BattleTurnManager.OverrideAttackerSelectionInfo.delegPtr = Marshal.GetFunctionPointerForDelegate(BattleTurnManager.OverrideAttackerSelectionInfo.deleg);
            }

            DragonEngine.DELib_RegisterAttackerOverrideFunc(BattleTurnManager.OverrideAttackerSelectionInfo.delegPtr);
        }

        /// <summary>
        /// Run away or not. Seems to end the battle either way? Weird function
        /// </summary>
        public static void RequestRunAway(Fighter fighter, bool success)
        {
            DELib_BattleTurnManager_RequestRunAway(fighter._ptr, success);
        }

        /// <summary>
        /// "Counter" an attacker with specified rpg skill.
        /// </summary>
        public static bool ForceCounterCommand(Fighter counterFighter, Fighter attacker, RPGSkillID skillID)
        {
            return DELib_BattleTurnManager_ForceCounterCommand(counterFighter._ptr, attacker._ptr, skillID);
        }

        /// <summary>
        /// Teleport the fighter to specified position.
        /// </summary>
        public static void WarpFighter(Fighter fighter, PoseInfo poseInf)
        {
            DELib_BattleTurnManager_WarpFighter(fighter._ptr, ref poseInf);
        }

        /// <summary>Removes the RPG UI.</summary>
        public static void ReleaseMenu()
        {
            DELib_BattleTurnManager_ReleaseMenu();
        }

        public static void SwitchTurn()
        {
            DELib_BattleTurnManager_SwitchTurn();
        }

        public static void SwitchActiveFighter(FighterID id, bool noUIChange)
        {
            DELib_BattleTurnManager_SwitchActiveFighter(id.Handle, noUIChange);
        }

        public static void ChangePhase(TurnPhase phase)
        {
            DELib_BattleTurnManager_ChangePhase(phase);
        }

        public static void ChangeActionStep(ActionStep step)
        {
            DELib_BattleTurnManager_ChangeActionStep(step);
        }

        public static Fighter SkipWaitTime(bool readOnly, bool getNextFighter)
        {
            IntPtr next = DELib_BattleTurnManager_SkipWaitTime(readOnly, getNextFighter);
            Fighter fighter = new Fighter(next);

            return fighter;
        }

        /// <summary>
        /// Starts a hact in queue
        /// </summary>
        /// <returns></returns>
        public static bool RequestPlayStartHact()
        {
            return DELib_BattleTurnManager_RequestPlayStartHact();
        }

        /// <summary>
        /// Request a hact to be played, barely functional? 
        /// </summary>
        public static bool RequestHActEvent(HActRequestOptions hact)
        {
            return DELib_BattleTurnManager_RequestHactEvent(ref hact);
        }


        public static bool DoExecTurnAICommand(Fighter fighter, BattleSelectCommandInfo inf)
        {
            //memory leak!
            return DELib_BattleTurnManager_DoExecTurnAICommand(fighter._ptr, inf.ToIntPtr());
        }

        public static bool ExecTurnAICommandDecide(Fighter fighter)
        {
            return DELib_BattleTurnManager_ExecTurnAICommandDecide(fighter._ptr);
        }

        // ---- Battle area control (offsets from debug PDB) ----
        // BattleTurnManager is 0x3080 bytes. These offsets control
        // the area culling system that hides world geometry during battle.
        private const int OFF_AREA_CTRL = 0xA0;           // BattleAreaControl2* m_area_ctrl
        private const int OFF_IS_RECHECK_BATTLE_AREA = 0x139; // bool m_is_recheck_battle_area

        /// <summary>
        /// Whether the battle area recheck flag is set.
        /// When true, the engine recalculates visible area each frame.
        /// </summary>
        public static bool IsRecheckBattleArea
        {
            get
            {
                IntPtr ptr = Pointer();
                if (ptr == IntPtr.Zero) return false;
                return Marshal.ReadByte(ptr + OFF_IS_RECHECK_BATTLE_AREA) != 0;
            }
            set
            {
                IntPtr ptr = Pointer();
                if (ptr == IntPtr.Zero) return;
                Marshal.WriteByte(ptr + OFF_IS_RECHECK_BATTLE_AREA, value ? (byte)1 : (byte)0);
            }
        }

        /// <summary>
        /// Pointer to BattleAreaControl2 which manages battle zone culling.
        /// </summary>
        public static IntPtr AreaControlPtr
        {
            get
            {
                IntPtr ptr = Pointer();
                if (ptr == IntPtr.Zero) return IntPtr.Zero;
                return Marshal.ReadIntPtr(ptr + OFF_AREA_CTRL);
            }
            set
            {
                IntPtr ptr = Pointer();
                if (ptr == IntPtr.Zero) return;
                Marshal.WriteIntPtr(ptr + OFF_AREA_CTRL, value);
            }
        }

        /// <summary>
        /// Disable the battle area culling system. Nulls the area controller
        /// and clears the recheck flag so world geometry stays visible.
        /// WARNING: Nulling the pointer crashes if the engine dereferences it
        /// during phase processing. Use ExpandBattleArea() instead.
        /// </summary>
        public static void DisableAreaCulling()
        {
            IntPtr ptr = Pointer();
            if (ptr == IntPtr.Zero) return;

            IntPtr oldCtrl = Marshal.ReadIntPtr(ptr + OFF_AREA_CTRL);
            Marshal.WriteIntPtr(ptr + OFF_AREA_CTRL, IntPtr.Zero);
            Marshal.WriteByte(ptr + OFF_IS_RECHECK_BATTLE_AREA, 0);
        }

        // m_battle_field_orbox at +0x200 (oriented bounding box)
        // Layout: center(Vec4 16b), extents(Vec4 16b), axes(3xVec4 48b) = 80 bytes total
        // Expanding the extents to a huge value makes the entire map "inside" the battle area.
        private const int OFF_BATTLE_FIELD_ORBOX = 0x200;

        /// <summary>
        /// Expand the battle field bounding box to cover the entire map.
        /// This prevents world geometry culling without nulling any pointers.
        /// Call AFTER ChangePhase(StartWait) and AFTER ChangePhase(Start).
        /// </summary>
        public static void ExpandBattleArea()
        {
            IntPtr ptr = Pointer();
            if (ptr == IntPtr.Zero) return;

            IntPtr orbox = ptr + OFF_BATTLE_FIELD_ORBOX;

            // Extents start at orbox+16 (after center Vec4)
            // Write very large extents (10km) for X, Y, Z
            byte[] bigExtent = BitConverter.GetBytes(10000f);
            Marshal.Copy(bigExtent, 0, orbox + 16, 4);  // extent X
            Marshal.Copy(bigExtent, 0, orbox + 20, 4);  // extent Y
            Marshal.Copy(bigExtent, 0, orbox + 24, 4);  // extent Z
        }
    }
}
#endif