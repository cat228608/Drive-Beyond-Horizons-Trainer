using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Memory;

namespace DBH_Trainer
{
    public partial class Form1 : Form
    {
        public static class Offsets
        {
            public const long GWORLD = 0x7790460;
            public const long UWorld_OwningGameInstance = 0x1B8;
            public const long UGameInstance_LocalPlayers = 0x38;
            public const long UPlayer_PlayerController = 0x30;
            public const long APlayerController_AcknowledgedPawn = 0x338;
            public const long ACharacter_CharacterMovement = 0x320;
            public const long UCharacterMovementComponent_MaxWalkSpeed = 0x1E8;
            public const long UCharacterMovementComponent_JumpZVelocity = 0x178;
            public const long UCharacterMovementComponent_GravityScale = 0x170;
            public const long UCharacterMovementComponent_AirControl = 0x220;
            public const long UPawnMovementComponent_Velocity = 0xB8;
            public const long UCharacterMovementComponent_MovementMode = 0x01A4;
            public const long UCharacterMovementComponent_GroundFriction = 0x1A8;
            public const long UWorld_PersistentLevel = 0x30;
            public const long ULevel_Actors = 0x98;
            public const long AActor_CustomTimeDilation = 0x64;
            public const long AActor_bCanBeDamaged_Byte = 0x5A;
            public const long AActor_RootComponent = 0x198;
            public const long USceneComponent_RelativeLocation = 0x160;
        }

        public const string PROCESS_NAME = "DriveBeyondHorizons-Win64-Shipping.exe";
        public Mem m = new Mem();
        private bool isSliding = false;
        private FVector slideVelocity = new FVector();
        private GlobalKeyboardHook _keyboardHook;
        private long baseAddress = 0;

        public const float DEFAULT_SPEED = 600f;
        public const float DEFAULT_JUMP = 600f;
        public const float DEFAULT_GRAVITY = 1f;
        public const float DEFAULT_FRICTION = 8f;
        public const float DEFAULT_AIR_CONTROL = 0.2f;

        public struct FVector
        {
            public double X, Y, Z;
        }

        public Form1()
        {
            InitializeComponent();

            _keyboardHook = new GlobalKeyboardHook();
            _keyboardHook.HookKey(Keys.NumPad1, () => { this.Invoke((MethodInvoker)delegate { chkSpeedhack.Checked = !chkSpeedhack.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad2, () => { this.Invoke((MethodInvoker)delegate { chkHighJump.Checked = !chkHighJump.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad3, () => { this.Invoke((MethodInvoker)delegate { chkFreezeAll.Checked = !chkFreezeAll.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad4, () => { this.Invoke((MethodInvoker)delegate { chkAirControl.Checked = !chkAirControl.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad5, () => { this.Invoke((MethodInvoker)delegate { chkIceSlide.Checked = !chkIceSlide.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad6, () => { this.Invoke((MethodInvoker)delegate { chkFly.Checked = !chkFly.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad7, () => { this.Invoke((MethodInvoker)delegate { chkGodMode.Checked = !chkGodMode.Checked; }); });
            _keyboardHook.HookKey(Keys.NumPad0, () => { this.Invoke((MethodInvoker)delegate { btnVoidAll.PerformClick(); }); });

            backgroundWorker1.DoWork += BW_DoWork;
            backgroundWorker1.RunWorkerAsync();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _keyboardHook?.Dispose();
            base.OnFormClosing(e);
        }

        void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!m.Attach(PROCESS_NAME))
                {
                    baseAddress = 0;
                    this.Invoke((MethodInvoker)delegate {
                        lblStatus.Text = "Статус: Ожидание игры...";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    });
                    Thread.Sleep(1);
                    continue;
                }

                var gameModule = m.GetModule(PROCESS_NAME);
                if (gameModule == null) { Thread.Sleep(1000); continue; }
                baseAddress = gameModule.BaseAddress.ToInt64();

                this.Invoke((MethodInvoker)delegate {
                    lblStatus.Text = "Статус: Игра найдена!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                });

                while (m.Attach(PROCESS_NAME))
                {
                    this.Invoke((MethodInvoker)delegate {
                        chkSpeedhack.Text = $"Speedhack [Num 1] {(chkSpeedhack.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                        chkHighJump.Text = $"High Jump [Num 2] {(chkHighJump.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                        chkFreezeAll.Text = $"Freeze All [Num 3] {(chkFreezeAll.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                        chkAirControl.Text = $"Air Control [Num 4] {(chkAirControl.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                        chkIceSlide.Text = $"Ice Slide [Num 5] {(chkIceSlide.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                        chkFly.Text = $"No Gravity [Num 6] {(chkFly.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                        chkGodMode.Text = $"God Mode [Num 7] {(chkGodMode.Checked ? "[ВКЛ]" : "[ВЫКЛ]")}";
                    });

                    long playerPawn = GetPlayerPawn();
                    if (playerPawn != 0)
                    {
                        long movementComponent = m.ReadInt64(playerPawn + Offsets.ACharacter_CharacterMovement);
                        if (movementComponent != 0)
                        {
                            m.WriteFloat(movementComponent + Offsets.UCharacterMovementComponent_MaxWalkSpeed, chkSpeedhack.Checked ? 2000f : DEFAULT_SPEED);
                            m.WriteFloat(movementComponent + Offsets.UCharacterMovementComponent_JumpZVelocity, chkHighJump.Checked ? 1500f : DEFAULT_JUMP);
                            m.WriteFloat(movementComponent + Offsets.UCharacterMovementComponent_GravityScale, chkFly.Checked ? 0f : DEFAULT_GRAVITY);
                            m.WriteFloat(movementComponent + Offsets.UCharacterMovementComponent_AirControl, chkAirControl.Checked ? 2f : DEFAULT_AIR_CONTROL);
                            m.WriteFloat(movementComponent + Offsets.UCharacterMovementComponent_GroundFriction, chkIceSlide.Checked ? 0f : DEFAULT_FRICTION);
                        }

                        if (chkIceSlide.Checked)
                        {
                            byte currentMode = m.ReadByte(movementComponent + Offsets.UCharacterMovementComponent_MovementMode);
                            if (currentMode == 1)
                            {
                                if (!isSliding)
                                {
                                    slideVelocity.X = m.ReadDouble(movementComponent + Offsets.UPawnMovementComponent_Velocity + 0);
                                    slideVelocity.Y = m.ReadDouble(movementComponent + Offsets.UPawnMovementComponent_Velocity + 8);
                                    isSliding = true;
                                }
                                m.WriteDouble(movementComponent + Offsets.UPawnMovementComponent_Velocity + 0, slideVelocity.X);
                                m.WriteDouble(movementComponent + Offsets.UPawnMovementComponent_Velocity + 8, slideVelocity.Y);
                            }
                            else
                            {
                                isSliding = false;
                            }
                        }
                        else
                        {
                            isSliding = false;
                        }

                        byte godModeByte = m.ReadByte(playerPawn + Offsets.AActor_bCanBeDamaged_Byte);
                        if (chkGodMode.Checked) godModeByte = (byte)(godModeByte & ~0x04);
                        else godModeByte = (byte)(godModeByte | 0x04);
                        m.WriteByte(playerPawn + Offsets.AActor_bCanBeDamaged_Byte, godModeByte);
                    }

                    if (chkFreezeAll.Checked)
                    {
                        long world = m.ReadInt64(baseAddress + Offsets.GWORLD);
                        long persistentLevel = m.ReadInt64(world + Offsets.UWorld_PersistentLevel);
                        long actorsArray = m.ReadInt64(persistentLevel + Offsets.ULevel_Actors);
                        int actorsCount = (int)m.ReadInt64(persistentLevel + Offsets.ULevel_Actors + 8);

                        for (int i = 0; i < actorsCount && i < 1024; i++)
                        {
                            long actor = m.ReadInt64(actorsArray + (i * 8));
                            if (actor != 0 && actor != playerPawn)
                                m.WriteFloat(actor + Offsets.AActor_CustomTimeDilation, 0.001f);
                        }
                    }

                    Thread.Sleep(10);
                }
            }
        }

        private long GetPlayerPawn()
        {
            try
            {
                long world = m.ReadInt64(baseAddress + Offsets.GWORLD);
                long gameInstance = m.ReadInt64(world + Offsets.UWorld_OwningGameInstance);
                long localPlayers = m.ReadInt64(gameInstance + Offsets.UGameInstance_LocalPlayers);
                long localPlayer = m.ReadInt64(localPlayers);
                long playerController = m.ReadInt64(localPlayer + Offsets.UPlayer_PlayerController);
                return m.ReadInt64(playerController + Offsets.APlayerController_AcknowledgedPawn);
            }
            catch { return 0; }
        }

        private void btnVoidAll_Click(object sender, EventArgs e)
        {
            if (baseAddress == 0) return;
            long playerPawn = GetPlayerPawn();
            if (playerPawn == 0) return;

            long world = m.ReadInt64(baseAddress + Offsets.GWORLD);
            long persistentLevel = m.ReadInt64(world + Offsets.UWorld_PersistentLevel);
            long actorsArray = m.ReadInt64(persistentLevel + Offsets.ULevel_Actors);
            int actorsCount = (int)m.ReadInt64(persistentLevel + Offsets.ULevel_Actors + 8);

            for (int i = 0; i < actorsCount && i < 1024; i++)
            {
                long actor = m.ReadInt64(actorsArray + (i * 8));
                if (actor != 0 && actor != playerPawn)
                {
                    long rootComponent = m.ReadInt64(actor + Offsets.AActor_RootComponent);
                    if (rootComponent != 0)
                    {
                        m.WriteDouble(rootComponent + Offsets.USceneComponent_RelativeLocation + 8, -20000.0);
                    }
                }
            }
        }
    }
}