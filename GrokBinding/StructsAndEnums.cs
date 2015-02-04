using System;

namespace UGrokIt {

	public enum UgiMemoryBank : uint {
		UGI_MEMORY_BANK_RESERVED = 0,
		UGI_MEMORY_BANK_EPC = 1,
		UGI_MEMORY_BANK_TID = 2,
		UGI_MEMORY_BANK_USER = 3
	}

	public enum UgiSoundTypes : uint {
		UGI_INVENTORY_SOUNDS_NONE = 0,
		UGI_INVENTORY_SOUNDS_GEIGER_COUNTER = 1,
		UGI_INVENTORY_SOUNDS_FIRST_FIND = 2,
		UGI_INVENTORY_SOUNDS_FIRST_FIND_AND_LAST = 6
	}

	public enum UgiInventoryTypes : uint {
		UGI_INVENTORY_TYPE_LOCATE_DISTANCE = 1,
		UGI_INVENTORY_TYPE_INVENTORY_SHORT_RANGE = 2,
		UGI_INVENTORY_TYPE_INVENTORY_DISTANCE = 3,
		UGI_INVENTORY_TYPE_LOCATE_SHORT_RANGE = 4,
		UGI_INVENTORY_TYPE_LOCATE_VERY_SHORT_RANGE = 5
	}

	public enum UgiTagAccessReturnValues : uint {
		UGI_TAG_ACCESS_OK = 0,
		UGI_TAG_ACCESS_WRONG_PASSWORD = 1,
		UGI_TAG_ACCESS_PASSWORD_REQUIRED = 2,
		UGI_TAG_ACCESS_MEMORY_OVERRUN = 3,
		UGI_TAG_ACCESS_TAG_NOT_FOUND = 4,
		UGI_TAG_ACCESS_GENERAL_ERROR = 5
	}

	public enum UgiLockUnlockMaskAndAction : uint {
		UGI_ACCESS_KILL_PASSWORD_MASK_BIT_OFFSET = 18,
		UGI_ACCESS_ACCESS_PASSWORD_MASK_BIT_OFFSET = 16,
		UGI_ACCESS_EPC_MASK_BIT_OFFSET = 14,
		UGI_ACCESS_TID_MASK_BIT_OFFSET = 12,
		UGI_ACCESS_USER_MASK_BIT_OFFSET = 10,
		UGI_ACCESS_KILL_PASSWORD_ACTION_BIT_OFFSET = 8,
		UGI_ACCESS_ACCESS_PASSWORD_ACTION_BIT_OFFSET = 6,
		UGI_ACCESS_EPC_ACTION_BIT_OFFSET = 4,
		UGI_ACCESS_TID_ACTION_BIT_OFFSET = 2,
		UGI_ACCESS_USER_ACTION_BIT_OFFSET = 0,
		UGI_ACCESS_MASK_CHANGE_NONE = 0,
		UGI_ACCESS_MASK_CHANGE_PERMALOCK = 1,
		UGI_ACCESS_MASK_CHANGE_WRITABLE = 2,
		UGI_ACCESS_MASK_CHANGE_WRITABLE_AND_PERMALOCK = 3,
		UGI_ACCESS_ACTION_WRITABLE = 0,
		UGI_ACCESS_ACTION_PERMANENTLY_WRITABLE = 1,
		UGI_ACCESS_ACTION_WRITE_RESTRICTED = 2,
		UGI_ACCESS_ACTION_PERMANENTLY_NOT_WRITABLE = 3
	}

	public enum UgiInventoryCompletedReturnValues : uint {
		UGI_INVENTORY_COMPLETED_OK = 0,
		UGI_INVENTORY_COMPLETED_ERROR_SENDING = 98,
		UGI_INVENTORY_COMPLETED_LOST_CONNECTION = 99,
		UGI_INVENTORY_COMPLETED_SPI_NOT_WORKING = 1,
		UGI_INVENTORY_COMPLETED_ENABLE_PIN_NOT_WORKING = 2,
		UGI_INVENTORY_COMPLETED_INTERRUPT_PIN_NOT_WORKING = 3,
		UGI_INVENTORY_COMPLETED_WRONG_CHIP_VERSION = 4,
		UGI_INVENTORY_COMPLETED_CRYSTAL_NOT_STABLE = 5,
		UGI_INVENTORY_COMPLETED_PLL_NOT_LOCKED = 6,
		UGI_INVENTORY_COMPLETED_BATTERY_TOO_LOW = 7,
		UGI_INVENTORY_COMPLETED_TEMPERATURE_TOO_HIGH = 8,
		UGI_INVENTORY_COMPLETED_NOT_PROVISIONED = 9,
		UGI_INVENTORY_COMPLETED_REGION_NOT_SET = 10
	}

	public enum UgiConnectionStates : uint {
		UGI_CONNECTION_STATE_NOT_CONNECTED,
		UGI_CONNECTION_STATE_CONNECTING,
		UGI_CONNECTION_STATE_INCOMPATIBLE_READER,
		UGI_CONNECTION_STATE_CONNECTED
	}

	public enum UgiReaderHardwareTypes : uint {
		UGI_READER_HARDWARE_UNKNOWN,
		UGI_READER_HARDWARE_GROKKER_1 = 5
	}

	public enum UgiPlaySoundSoundTypes : uint {
		UGI_PLAY_SOUND_FOUND_LAST
	}

	public enum UgiLoggingTypes : uint {
		UGI_LOGGING_INTERNAL_BYTE_PROTOCOL = 1,
		UGI_LOGGING_INTERNAL_CONNECTION_ERRORS = 2,
		UGI_LOGGING_INTERNAL_CONNECTION_STATE = 4,
		UGI_LOGGING_INTERNAL_PACKET_PROTOCOL = 8,
		UGI_LOGGING_INTERNAL_COMMAND = 16,
		UGI_LOGGING_INTERNAL_INVENTORY = 32,
		UGI_LOGGING_INTERNAL_FIRMWARE_UPDATE = 64,
		UGI_LOGGING_STATE = 4096,
		UGI_LOGGING_INVENTORY = 8192,
		UGI_LOGGING_INVENTORY_DETAIL = 16384
	}

	public struct UgiGeigerCounterSound
	{
		public int frequency;
		public int durationMsec;
		public double clickRate;
		public int maxClicksPerSecond;
		public int historyDepthMsec;
	}

	public struct UgiSpeakerTone
	{
		public int frequency;
		public int durationMsec;
	}

	public struct UgiDiagnosticData
	{
		public double byteProtocolSkewFactor;
		public int byteProtocolBytesSent;
		public int byteProtocolBytesReceived;
		public int byteProtocolSubsequentReadTimeouts;
		public int packetProtocolPacketsSent;
		public int packetProtocolPacketsReceived;
		public int packetProtocolSendFailures;
		public int packetProtocolSendRetries;
		public int packetProtocolSendTimeouts;
		public int packetProtocolInvalidPackets;
		public int packetProtocolInternalCrcMismatches;
		public int packetProtocolCrcMismatches;
		public int rawInventoryRounds;
		public int rawTagFinds;
		public int inventoryUnique;
		public int inventoryForgotten;
		public int inventoryForgottenNotAcknowledged;
		public int inventoryForgottenNotSent;
	}

	public struct UgiBatteryInfo
	{
		public bool canScan;
		public bool externalPowerIsConnected;
		public bool isCharging;
		public int minutesRemaining;
		public int percentRemainging;
	}
}


