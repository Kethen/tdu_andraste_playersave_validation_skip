using Andraste.Payload.ModManagement;
using Andraste.Payload.Native;
using System;
using NLog;

namespace KatieCookie.tdu
{
	public class PlayersaveValidationSkip : BasePlugin
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		private bool _enabled;
		public override bool Enabled
		{
			get {
				return _enabled;
			}
			set
			{
				_enabled = value;
				IntPtr location_check_1 = new IntPtr (0x0089a7d5);
				IntPtr location_check_2 = new IntPtr (0x0089a7e6);
				IntPtr location_check_3 = new IntPtr (0x0089a7f7);

				byte[] expectation_check_1 = new byte[]{ 0x75, 0x3d };
				byte[] expectation_check_2 = new byte[]{ 0x75, 0x2c };
				byte[] expectation_check_3 = new byte[]{ 0x75, 0x1b };

				byte[] to_apply = new byte[]{ 0x90, 0x90 };

				InstructionPatcher patcher_check_1 = new InstructionPatcher(location_check_1, expectation_check_1, to_apply);
				InstructionPatcher patcher_check_2 = new InstructionPatcher(location_check_2, expectation_check_2, to_apply);
				InstructionPatcher patcher_check_3 = new InstructionPatcher(location_check_3, expectation_check_3, to_apply);
				if (value){
					patcher_check_1.Patch(true);
					patcher_check_2.Patch(true);
					patcher_check_3.Patch(true);
					Logger.Info("playersave validation skip is now enabled");
				}else{
					patcher_check_1.Patch(false);
					patcher_check_2.Patch(false);
					patcher_check_3.Patch(false);
					Logger.Info("playersave validation skip is now disabled");
				}
			}
		}

		protected override void PluginLoad()
		{
		}

		protected override void PluginUnload()
		{
		}
	}
}