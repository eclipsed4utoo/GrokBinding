using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using System.ComponentModel;

namespace UGrokIt {

	// @interface UgiRfidConfiguration : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface UgiRfidConfiguration {

		// @property (nonatomic) double initialPowerLevel;
		[Export ("initialPowerLevel")]
		double InitialPowerLevel { get; set; }

		// @property (nonatomic) double minPowerLevel;
		[Export ("minPowerLevel")]
		double MinPowerLevel { get; set; }

		// @property (nonatomic) double maxPowerLevel;
		[Export ("maxPowerLevel")]
		double MaxPowerLevel { get; set; }

		// @property (nonatomic) int initialQValue;
		[Export ("initialQValue")]
		int InitialQValue { get; set; }

		// @property (nonatomic) int minQValue;
		[Export ("minQValue")]
		int MinQValue { get; set; }

		// @property (nonatomic) int maxQValue;
		[Export ("maxQValue")]
		int MaxQValue { get; set; }

		// @property (nonatomic) int session;
		[Export ("session")]
		int Session { get; set; }

		// @property (nonatomic) int roundsWithNoFindsToToggleAB;
		[Export ("roundsWithNoFindsToToggleAB")]
		int RoundsWithNoFindsToToggleAB { get; set; }

		// @property (nonatomic) int sensitivity;
		[Export ("sensitivity")]
		int Sensitivity { get; set; }

		// @property (nonatomic) double powerLevelWrite;
		[Export ("powerLevelWrite")]
		double PowerLevelWrite { get; set; }

		// @property (nonatomic) int sensitivityWrite;
		[Export ("sensitivityWrite")]
		int SensitivityWrite { get; set; }

		// @property (nonatomic) BOOL setListenBeforeTalk;
		[Export ("setListenBeforeTalk")]
		bool SetListenBeforeTalk { get; set; }

		// @property (nonatomic) BOOL listenBeforeTalk;
		[Export ("listenBeforeTalk")]
		bool ListenBeforeTalk { get; set; }

		// @property (nonatomic) int maxRoundsPerSecond;
		[Export ("maxRoundsPerSecond")]
		int MaxRoundsPerSecond { get; set; }

		// @property (nonatomic) int minTidBytes;
		[Export ("minTidBytes")]
		int MinTidBytes { get; set; }

		// @property (nonatomic) int maxTidBytes;
		[Export ("maxTidBytes")]
		int MaxTidBytes { get; set; }

		// @property (nonatomic) int minUserBytes;
		[Export ("minUserBytes")]
		int MinUserBytes { get; set; }

		// @property (nonatomic) int maxUserBytes;
		[Export ("maxUserBytes")]
		int MaxUserBytes { get; set; }

		// @property (nonatomic) int minReservedBytes;
		[Export ("minReservedBytes")]
		int MinReservedBytes { get; set; }

		// @property (nonatomic) int maxReservedBytes;
		[Export ("maxReservedBytes")]
		int MaxReservedBytes { get; set; }

		// @property (retain, nonatomic) NSData * selectMask;
		[Export ("selectMask", ArgumentSemantic.Retain)]
		NSData SelectMask { get; set; }

		// @property (nonatomic) int selectMaskBitLength;
		[Export ("selectMaskBitLength")]
		int SelectMaskBitLength { get; set; }

		// @property (nonatomic) int selectOffset;
		[Export ("selectOffset")]
		int SelectOffset { get; set; }

		// @property (nonatomic) UgiMemoryBank selectBank;
		[Export ("selectBank")]
		UgiMemoryBank SelectBank { get; set; }

		// @property (nonatomic) BOOL continual;
		[Export ("continual")]
		bool Continual { get; set; }

		// @property (nonatomic) BOOL reportRssi;
		[Export ("reportRssi")]
		bool ReportRssi { get; set; }

		// @property (nonatomic) BOOL detailedPerReadData;
		[Export ("detailedPerReadData")]
		bool DetailedPerReadData { get; set; }

		// @property (nonatomic) int detailedPerReadNumReads;
		[Export ("detailedPerReadNumReads")]
		int DetailedPerReadNumReads { get; set; }

		// @property (nonatomic) UgiMemoryBank detailedPerReadMemoryBank1;
		[Export ("detailedPerReadMemoryBank1")]
		UgiMemoryBank DetailedPerReadMemoryBank1 { get; set; }

		// @property (nonatomic) int detailedPerReadWordOffset1;
		[Export ("detailedPerReadWordOffset1")]
		int DetailedPerReadWordOffset1 { get; set; }

		// @property (nonatomic) UgiMemoryBank detailedPerReadMemoryBank2;
		[Export ("detailedPerReadMemoryBank2")]
		UgiMemoryBank DetailedPerReadMemoryBank2 { get; set; }

		// @property (nonatomic) int detailedPerReadWordOffset2;
		[Export ("detailedPerReadWordOffset2")]
		int DetailedPerReadWordOffset2 { get; set; }

		// @property (nonatomic) BOOL reportSubsequentFinds;
		[Export ("reportSubsequentFinds")]
		bool ReportSubsequentFinds { get; set; }

		// @property (nonatomic) UgiSoundTypes soundType;
		[Export ("soundType")]
		UgiSoundTypes SoundType { get; set; }

		// @property (nonatomic) double volume;
		[Export ("volume")]
		double Volume { get; set; }

		// @property (nonatomic) int historyIntervalMSec;
		[Export ("historyIntervalMSec")]
		int HistoryIntervalMSec { get; set; }

		// @property (nonatomic) int historyDepth;
		[Export ("historyDepth")]
		int HistoryDepth { get; set; }

		// +(UgiRfidConfiguration *)configWithInventoryType:(UgiInventoryTypes)inventoryType;
		[Static, Export ("configWithInventoryType:")]
		UgiRfidConfiguration ConfigWithInventoryType (UgiInventoryTypes inventoryType);

		// +(NSString *)nameForInventoryType:(UgiInventoryTypes)inventoryType;
		[Static, Export ("nameForInventoryType:")]
		string NameForInventoryType (UgiInventoryTypes inventoryType);

		// +(int)numInventoryTypes;
		[Static, Export ("numInventoryTypes")]
		int NumInventoryTypes ();

		// +(double)getMinAllowablePowerLevel;
		[Static, Export ("getMinAllowablePowerLevel")]
		double GetMinAllowablePowerLevel ();

		// +(double)getMaxAllowablePowerLevel;
		[Static, Export ("getMaxAllowablePowerLevel")]
		double GetMaxAllowablePowerLevel ();

		// +(int)getMinAllowableQValue;
		[Static, Export ("getMinAllowableQValue")]
		int GetMinAllowableQValue ();

		// +(int)getMaxAllowableQValue;
		[Static, Export ("getMaxAllowableQValue")]
		int GetMaxAllowableQValue ();

		// +(int)getMaxAllowableRoundsWithNoFindsToToggleAB;
		[Static, Export ("getMaxAllowableRoundsWithNoFindsToToggleAB")]
		int GetMaxAllowableRoundsWithNoFindsToToggleAB ();

		// +(int)getMaxAllowableMemoryBankBytes;
		[Static, Export ("getMaxAllowableMemoryBankBytes")]
		int GetMaxAllowableMemoryBankBytes ();
	}

//	 @interface UgiJsonPropertyInfo : NSObject
	[BaseType (typeof (NSObject))]
	interface UgiJsonPropertyInfo {

		// @property (retain, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; set; }
	}

	// @interface UgiJsonClassInfo : NSObject
	[BaseType (typeof (NSObject))]
	interface UgiJsonClassInfo {

		// @property (retain, nonatomic) NSDictionary * properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		NSDictionary Properties { get; set; }

		// @property (retain, nonatomic) NSArray * idFieldNames;
		[Export ("idFieldNames", ArgumentSemantic.Retain)]
		NSObject [] IdFieldNames { get; set; }
	}

	// @interface UgiJson (NSObject)
	[Category]
	[BaseType (typeof (NSObject))]
	interface UgiJson {

		// -(id)initFromJsonStream:(NSInputStream *)stream error:(NSError **)error context:(NSDictionary *)context;
		[Export ("initFromJsonStream:error:context:")]
		IntPtr Constructor (NSInputStream stream, out NSError error, NSDictionary context);

		// -(void)toJsonStream:(NSOutputStream *)stream context:(NSDictionary *)context;
		[Export ("toJsonStream:context:")]
		void ToJsonStream (NSOutputStream stream, NSDictionary context);

		// -(NSData *)toJson:(NSDictionary *)context;
		[Export ("toJson:")]
		NSData ToJson (NSDictionary context);

		// -(NSString *)toJsonString:(NSDictionary *)context;
		[Export ("toJsonString:")]
		string ToJsonString (NSDictionary context);
	}

	// @protocol UgiJsonModel <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface UgiJsonModel {

		// @optional -(BOOL)shouldSerializeObject:(NSMutableDictionary *)context;
		[Export ("shouldSerializeObject:")]
		bool ShouldSerializeObject (NSMutableDictionary context);

		// @optional -(BOOL)shouldSerializeField:(NSString *)fieldName value:(id)value context:(NSMutableDictionary *)context;
		[Export ("shouldSerializeField:value:context:")]
		bool ShouldSerializeField (string fieldName, NSObject value, NSMutableDictionary context);

		// @optional -(id)customSerialize:(NSMutableDictionary *)context;
		[Export ("customSerialize:")]
		NSObject CustomSerialize (NSMutableDictionary context);

		// @optional -(void)customDeserialize:(id)value;
		[Export ("customDeserialize:")]
		void CustomDeserialize (NSObject value);

		// @optional -(void)prepareSerializationContext:(NSMutableDictionary *)context;
		[Export ("prepareSerializationContext:")]
		void PrepareSerializationContext (NSMutableDictionary context);

		// @optional -(void)prepareDeserializationContext:(NSMutableDictionary *)context;
		[Export ("prepareDeserializationContext:")]
		void PrepareDeserializationContext (NSMutableDictionary context);

		// @optional -(void)initForDeserialization:(NSMutableDictionary *)context;
		[Export ("initForDeserialization:")]
		void InitForDeserialization (NSMutableDictionary context);

		// @optional -(id)customSerializeField:(NSString *)fieldName value:(id)value context:(NSMutableDictionary *)context;
		[Export ("customSerializeField:value:context:")]
		NSObject CustomSerializeField (string fieldName, NSObject value, NSMutableDictionary context);

		// @optional -(id)customDeserializeField:(NSString *)fieldName value:(id)value context:(NSMutableDictionary *)context;
		[Export ("customDeserializeField:value:context:")]
		NSObject CustomDeserializeField (string fieldName, NSObject value, NSMutableDictionary context);

		// @optional -(void)handleUnrecognizedField:(NSString *)key value:(NSObject *)value context:(NSMutableDictionary *)context;
		[Export ("handleUnrecognizedField:value:context:")]
		void HandleUnrecognizedField (string key, NSObject value, NSMutableDictionary context);
	}

	// @interface UgiJsonModelBase : NSObject <UgiJsonModel>
	[BaseType (typeof (NSObject))]
	interface UgiJsonModelBase : UgiJsonModel {

	}

	// @interface UgiPersistentJsonRoot : UgiJsonModelBase
	[BaseType (typeof (UgiJsonModelBase))]
	interface UgiPersistentJsonRoot {

		// -(id)initFromFile:(NSString *)fileName initializationData:(NSDictionary *)initializationData debug:(BOOL)debug;
		[Export ("initFromFile:initializationData:debug:")]
		IntPtr Constructor (string fileName, NSDictionary initializationData, bool debug);

		// @property BOOL _debug;
		[Export ("_debug")]
		bool _debug { get; set; }

		// @property (retain, nonatomic) NSString * _fileName;
		[Export ("_fileName", ArgumentSemantic.Retain)]
		string _fileName { get; set; }

		// @property (retain, nonatomic) NSString * _filePath;
		[Export ("_filePath", ArgumentSemantic.Retain)]
		string _filePath { get; set; }

		// -(void)initForNoFile:(NSDictionary *)initializationData;
		[Export ("initForNoFile:")]
		void InitForNoFile (NSDictionary initializationData);

		// -(void)initAfterFileLoaded:(NSDictionary *)initializationData;
		[Export ("initAfterFileLoaded:")]
		void InitAfterFileLoaded (NSDictionary initializationData);

		// -(void)initNonPersistent:(NSDictionary *)initializationData;
		[Export ("initNonPersistent:")]
		void InitNonPersistent (NSDictionary initializationData);

		// +(void)deleteFile:(NSString *)fileName;
		[Static, Export ("deleteFile:")]
		void DeleteFile (string fileName);

		// -(void)save;
		[Export ("save")]
		void Save ();
	}

	// @interface UgiEpc : NSObject <NSCopying, UgiJsonModel>
	[BaseType (typeof (NSObject))]
	interface UgiEpc : UgiJsonModel {

		// @property (retain, nonatomic) NSData * data;
		[Export ("data", ArgumentSemantic.Retain)]
		NSData Data { get; set; }

		// +(UgiEpc *)epcFromBytes:(NSData *)data;
		[Static, Export ("epcFromBytes:")]
		UgiEpc EpcFromBytes (NSData data);

		// +(UgiEpc *)epcFromString:(NSString *)s;
		[Static, Export ("epcFromString:")]
		UgiEpc EpcFromString (string s);

		// -(const uint8_t *)bytes;
		[Export ("bytes")]
		byte Bytes ();

		// -(int)length;
		[Export ("length")]
		int Length ();

		// -(NSString *)toString;
		[Export ("toString")]
		string ToString ();

		// -(NSString *)toTagURI;
		[Export ("toTagURI")]
		string ToTagURI ();

		// -(NSString *)getManufacturerNameIfUnprogrammed;
		[Export ("getManufacturerNameIfUnprogrammed")]
		string GetManufacturerNameIfUnprogrammed ();

		// -(BOOL)isUnprogrammedEpc;
		[Export ("isUnprogrammedEpc")]
		bool IsUnprogrammedEpc ();

		// +(UgiEpc *)epcFromUGrokItEpc;
		[Static, Export ("epcFromUGrokItEpc")]
		UgiEpc EpcFromUGrokItEpc ();
	}

	// @interface UgiTag : NSObject
	[BaseType (typeof (NSObject))]
	interface UgiTag {

		// @property (readonly, nonatomic) UgiEpc * epc;
		[Export ("epc")]
		UgiEpc Epc { get; }

		// @property (readonly, nonatomic) NSDate * firstRead;
		[Export ("firstRead")]
		NSDate FirstRead { get; }

		// @property (readonly, nonatomic) NSData * tidMemory;
		[Export ("tidMemory")]
		NSData TidMemory { get; }

		// @property (readonly, nonatomic) NSData * userMemory;
		[Export ("userMemory")]
		NSData UserMemory { get; }

		// @property (readonly, nonatomic) NSData * reservedMemory;
		[Export ("reservedMemory")]
		NSData ReservedMemory { get; }

		// @property (readonly, nonatomic) UgiTagReadState * readState;
		[Export ("readState")]
		UgiTagReadState ReadState { get; }

		// @property (readonly, nonatomic) BOOL isVisible;
		[Export ("isVisible")]
		bool IsVisible { get; }
	}

	// @interface UgiDetailedPerReadData : NSObject
	[BaseType (typeof (NSObject))]
	interface UgiDetailedPerReadData {

		// @property (readonly, nonatomic) NSDate * timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }

		// @property (readonly, nonatomic) int frequency;
		[Export ("frequency")]
		int Frequency { get; }

		// @property (readonly, nonatomic) double rssiI;
		[Export ("rssiI")]
		double RssiI { get; }

		// @property (readonly, nonatomic) double rssiQ;
		[Export ("rssiQ")]
		double RssiQ { get; }

		// @property (readonly, nonatomic) int readData1;
		[Export ("readData1")]
		int ReadData1 { get; }

		// @property (readonly, nonatomic) int readData2;
		[Export ("readData2")]
		int ReadData2 { get; }
	}

	// @interface UgiInventory : NSObject
	[BaseType (typeof (NSObject))]
	interface UgiInventory {

		// @property (readonly, nonatomic) UgiRfidConfiguration * configuration;
		[Export ("configuration")]
		UgiRfidConfiguration Configuration { get; }

		// @property (readonly, nonatomic) NSDate * startTime;
		[Export ("startTime")]
		NSDate StartTime { get; }

		// @property (readonly, nonatomic) BOOL isPaused;
		[Export ("isPaused")]
		bool IsPaused { get; }

		// @property (readonly, nonatomic) BOOL isScanning;
		[Export ("isScanning")]
		bool IsScanning { get; }

		// @property (readonly, nonatomic) int numInventoryRounds;
		[Export ("numInventoryRounds")]
		int NumInventoryRounds { get; }

		// @property (readonly, nonatomic) NSArray * tags;
		[Export ("tags")]
		NSObject [] Tags { get; }

		// -(void)stopInventoryWithCompletion:(StopInventoryCompletion)completion;
		[Export ("stopInventoryWithCompletion:")]
		void StopInventoryWithCompletion (Action completion);

		// -(void)stopInventory;
		[Export ("stopInventory")]
		void StopInventory ();

		// -(void)pauseInventory;
		[Export ("pauseInventory")]
		void PauseInventory ();

		// -(void)resumeInventory;
		[Export ("resumeInventory")]
		void ResumeInventory ();

		// -(void)resumeInventoryWithConfiguration:(UgiRfidConfiguration *)configuration;
		[Export ("resumeInventoryWithConfiguration:")]
		void ResumeInventoryWithConfiguration (UgiRfidConfiguration configuration);

		// -(UgiTag *)getTagByEpc:(UgiEpc *)epc;
		[Export ("getTagByEpc:")]
		UgiTag GetTagByEpc (UgiEpc epc);

		// -(void)programTag:(UgiEpc *)oldEpc toEpc:(UgiEpc *)newEpc withPassword:(int)password whenCompleted:(TagAccessCompletion)completion;
		[Export ("programTag:toEpc:withPassword:whenCompleted:")]
		void ProgramTag (UgiEpc oldEpc, UgiEpc newEpc, int password, Action<UgiTag, UgiTagAccessReturnValues> completion);

		// -(void)writeTag:(UgiEpc *)epc memoryBank:(UgiMemoryBank)memoryBank offset:(int)offset data:(NSData *)data previousData:(NSData *)previousData withPassword:(int)password whenCompleted:(TagAccessCompletion)completion;
		[Export ("writeTag:memoryBank:offset:data:previousData:withPassword:whenCompleted:")]
		void WriteTag (UgiEpc epc, UgiMemoryBank memoryBank, int offset, NSData data, NSData previousData, int password, Action<UgiTag, UgiTagAccessReturnValues> completion);

		// -(void)setTagAccessPassword:(UgiEpc *)epc currentPassword:(int)currentPassword newPassword:(int)newPassword whenCompleted:(TagAccessCompletion)completion;
		[Export ("setTagAccessPassword:currentPassword:newPassword:whenCompleted:")]
		void SetTagAccessPassword (UgiEpc epc, int currentPassword, int newPassword, Action<UgiTag, UgiTagAccessReturnValues> completion);

		// -(void)setTagKillPassword:(UgiEpc *)epc currentPassword:(int)currentPassword killPassword:(int)killPassword whenCompleted:(TagAccessCompletion)completion;
		[Export ("setTagKillPassword:currentPassword:killPassword:whenCompleted:")]
		void SetTagKillPassword (UgiEpc epc, int currentPassword, int killPassword, Action<UgiTag, UgiTagAccessReturnValues> completion);

		// -(void)lockUnlockTag:(UgiEpc *)epc maskAndAction:(UgiLockUnlockMaskAndAction)maskAndAction withPassword:(int)password whenCompleted:(TagAccessCompletion)completion;
		[Export ("lockUnlockTag:maskAndAction:withPassword:whenCompleted:")]
		void LockUnlockTag (UgiEpc epc, UgiLockUnlockMaskAndAction maskAndAction, int password, Action<UgiTag, UgiTagAccessReturnValues> completion);

		// -(void)readTag:(UgiEpc *)epc memoryBank:(UgiMemoryBank)memoryBank offset:(int)offset minNumBytes:(int)minNumBytes maxNumBytes:(int)maxNumBytes whenCompleted:(TagReadCompletion)completion;
		[Export ("readTag:memoryBank:offset:minNumBytes:maxNumBytes:whenCompleted:")]
		void ReadTag (UgiEpc epc, UgiMemoryBank memoryBank, int offset, int minNumBytes, int maxNumBytes, Action<UgiTag, NSData, UgiTagAccessReturnValues> completion);

		// -(void)customCommandToTag:(UgiEpc *)epc command:(NSData *)command commandBits:(int)commandBits responseBitLengthNoHeaderBit:(int)responseBitLengthNoHeaderBit responseBitLengthWithHeaderBit:(int)responseBitLengthWithHeaderBit receiveTimeoutUsec:(int)receiveTimeoutUsec whenCompleted:(TagCustomCommandCompletion)completion;
		[Export ("customCommandToTag:command:commandBits:responseBitLengthNoHeaderBit:responseBitLengthWithHeaderBit:receiveTimeoutUsec:whenCompleted:")]
		void CustomCommandToTag (UgiEpc epc, NSData command, int commandBits, int responseBitLengthNoHeaderBit, int responseBitLengthWithHeaderBit, int receiveTimeoutUsec, Action<UgiTag, sbyte, NSData, UgiTagAccessReturnValues> completion);

		// -(void)changePowerInitial:(double)initialPowerLevel min:(double)minPowerLevel max:(double)maxPowerLevel whenCompleted:(ChangePowerCompletion)completion;
		[Export ("changePowerInitial:min:max:whenCompleted:")]
		void ChangePowerInitial (double initialPowerLevel, double minPowerLevel, double maxPowerLevel, Action<sbyte> completion);
	}

	// @interface UgiTagReadState : NSObject
	[BaseType (typeof (NSObject))]
	interface UgiTagReadState {

		// @property (readonly, nonatomic) UgiTag * tag;
		[Export ("tag")]
		UgiTag Tag { get; }

		// @property (readonly, nonatomic) NSDate * timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }

		// @property (readonly, nonatomic) BOOL isVisible;
		[Export ("isVisible")]
		bool IsVisible { get; }

		// @property (readonly, nonatomic) int totalReads;
		[Export ("totalReads")]
		int TotalReads { get; }

		// @property (readonly, nonatomic) NSDate * mostRecentRead;
		[Export ("mostRecentRead")]
		NSDate MostRecentRead { get; }

		// @property (readonly, nonatomic) double mostRecentRssiI;
		[Export ("mostRecentRssiI")]
		double MostRecentRssiI { get; }

		// @property (readonly, nonatomic) double mostRecentRssiQ;
		[Export ("mostRecentRssiQ")]
		double MostRecentRssiQ { get; }

		// @property (readonly, nonatomic) NSArray * readHistory;
		[Export ("readHistory")]
		NSObject [] ReadHistory { get; }

		// -(NSString *)readHistoryString;
		[Export ("readHistoryString")]
		string ReadHistoryString ();

		// -(NSString *)description;
		[Export ("description")]
		string Description ();
	}

	// @protocol UgiInventoryDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface UgiInventoryDelegate {

		// @optional -(void)inventoryDidStart;
		[Export ("inventoryDidStart")]
		void InventoryDidStart ();

		// @optional -(void)inventoryDidStopWithResult:(UgiInventoryCompletedReturnValues)result;
		[Export ("inventoryDidStopWithResult:")]
		void InventoryDidStopWithResult (UgiInventoryCompletedReturnValues result);

		// @optional -(BOOL)inventoryFilter:(UgiEpc *)epc;
		[Export ("inventoryFilter:")]
		bool InventoryFilter (UgiEpc epc);

		// @optional -(BOOL)inventoryFilterLowLevel:(UgiEpc *)epc;
		[Export ("inventoryFilterLowLevel:")]
		bool InventoryFilterLowLevel (UgiEpc epc);

		// @optional -(void)inventoryTagChanged:(UgiTag *)tag isFirstFind:(BOOL)firstFind;
		[Export ("inventoryTagChanged:isFirstFind:")]
		void InventoryTagChanged (UgiTag tag, bool firstFind);

		// @optional -(void)inventoryTagFound:(UgiTag *)tag withDetailedPerReadData:(NSArray *)detailedPerReadData;
		[Export ("inventoryTagFound:withDetailedPerReadData:")]
		void InventoryTagFound (UgiTag tag, NSObject [] detailedPerReadData);

		// @optional -(void)inventoryTagSubsequentFinds:(UgiTag *)tag numFinds:(int)num withDetailedPerReadData:(NSArray *)detailedPerReadData;
		[Export ("inventoryTagSubsequentFinds:numFinds:withDetailedPerReadData:")]
		void InventoryTagSubsequentFinds (UgiTag tag, int num, NSObject [] detailedPerReadData);

		// @optional -(void)inventoryHistoryInterval;
		[Export ("inventoryHistoryInterval")]
		void InventoryHistoryInterval ();
	}

	// @interface Ugi : NSObject
	[BaseType (typeof (NSObject))]
	interface Ugi {

		// @property (readonly, nonatomic) BOOL inOpenConnection;
		[Export ("inOpenConnection")]
		bool InOpenConnection { get; }

		// @property (readonly, nonatomic) BOOL isAnythingPluggedIntoAudioJack;
		[Export ("isAnythingPluggedIntoAudioJack")]
		bool IsAnythingPluggedIntoAudioJack { get; }

		// @property (readonly, nonatomic) NSString * NOTIFICAION_NAME_CONNECTION_STATE_CHANGED;
		[Export ("NOTIFICAION_NAME_CONNECTION_STATE_CHANGED")]
		string NOTIFICAION_NAME_CONNECTION_STATE_CHANGED { get; }

		// @property (readonly, nonatomic) NSString * NOTIFICAION_NAME_INVENTORY_STATE_CHANGED;
		[Export ("NOTIFICAION_NAME_INVENTORY_STATE_CHANGED")]
		string NOTIFICAION_NAME_INVENTORY_STATE_CHANGED { get; }

		// @property (readonly, nonatomic) UgiConnectionStates connectionState;
		[Export ("connectionState")]
		UgiConnectionStates ConnectionState { get; }

		// @property (readonly, nonatomic) BOOL isConnected;
		[Export ("isConnected")]
		bool IsConnected { get; }

		// @property (readonly, nonatomic) UgiInventory * activeInventory;
		[Export ("activeInventory")]
		UgiInventory ActiveInventory { get; }

		// @property (readonly, nonatomic) int requiredProtocolVersion;
		[Export ("requiredProtocolVersion")]
		int RequiredProtocolVersion { get; }

		// @property (readonly, nonatomic) int supportedProtocolVersion;
		[Export ("supportedProtocolVersion")]
		int SupportedProtocolVersion { get; }

		// @property (readonly, nonatomic) int readerProtocolVersion;
		[Export ("readerProtocolVersion")]
		int ReaderProtocolVersion { get; }

		// @property (readonly, nonatomic) NSString * readerHardwareModel;
		[Export ("readerHardwareModel")]
		string ReaderHardwareModel { get; }

		// @property (readonly, nonatomic) UgiReaderHardwareTypes readerHardwareType;
		[Export ("readerHardwareType")]
		UgiReaderHardwareTypes ReaderHardwareType { get; }

		// @property (readonly, nonatomic) NSString * readerHardwareTypeName;
		[Export ("readerHardwareTypeName")]
		string ReaderHardwareTypeName { get; }

		// @property (readonly, nonatomic) int readerHardwareRevision;
		[Export ("readerHardwareRevision")]
		int ReaderHardwareRevision { get; }

		// @property (readonly, nonatomic) int firmwareVersionMajor;
		[Export ("firmwareVersionMajor")]
		int FirmwareVersionMajor { get; }

		// @property (readonly, nonatomic) int firmwareVersionMinor;
		[Export ("firmwareVersionMinor")]
		int FirmwareVersionMinor { get; }

		// @property (readonly, nonatomic) int firmwareVersionBuild;
		[Export ("firmwareVersionBuild")]
		int FirmwareVersionBuild { get; }

		// @property (readonly, nonatomic) int readerSerialNumber;
		[Export ("readerSerialNumber")]
		int ReaderSerialNumber { get; }

		// @property (readonly, nonatomic) NSString * regionName;
		[Export ("regionName")]
		string RegionName { get; }

		// @property (readonly, nonatomic) int maxTonesInSound;
		[Export ("maxTonesInSound")]
		int MaxTonesInSound { get; }

		// @property (readonly, nonatomic) double maxPower;
		[Export ("maxPower")]
		double MaxPower { get; }

		// @property (readonly, nonatomic) int maxSensitivity;
		[Export ("maxSensitivity")]
		int MaxSensitivity { get; }

		// @property (readonly, nonatomic) int numVolumeLevels;
		[Export ("numVolumeLevels")]
		int NumVolumeLevels { get; }

		// @property (readonly, nonatomic) BOOL hasBattery;
		[Export ("hasBattery")]
		bool HasBattery { get; }

		// @property (readonly, nonatomic) BOOL hasExternalPower;
		[Export ("hasExternalPower")]
		bool HasExternalPower { get; }

		// @property (readonly, nonatomic) BOOL userMustSetRegion;
		[Export ("userMustSetRegion")]
		bool UserMustSetRegion { get; }

		// @property (readonly, nonatomic) BOOL userCanSetRegion;
		[Export ("userCanSetRegion")]
		bool UserCanSetRegion { get; }

		// @property (readonly, nonatomic) int batteryCapacity;
		[Export ("batteryCapacity")]
		int BatteryCapacity { get; }

		// @property (readonly, nonatomic) int batteryCapacity_mAh;
		[Export ("batteryCapacity_mAh")]
		int BatteryCapacity_mAh { get; }

		// @property (readonly, nonatomic) BOOL deviceInitializedSuccessfully;
		[Export ("deviceInitializedSuccessfully")]
		bool DeviceInitializedSuccessfully { get; }

		// @property (readonly, nonatomic) NSString * readerDescription;
		[Export ("readerDescription")]
		string ReaderDescription { get; }

		// @property (nonatomic) UgiLoggingTypes loggingStatus;
		[Export ("loggingStatus")]
		UgiLoggingTypes LoggingStatus { get; set; }

		// @property (nonatomic) BOOL loggingTimestamp;
		[Export ("loggingTimestamp")]
		bool LoggingTimestamp { get; set; }

		// @property (readonly, nonatomic) int sdkVersionMajor;
		[Export ("sdkVersionMajor")]
		int SdkVersionMajor { get; }

		// @property (readonly, nonatomic) int sdkVersionMinor;
		[Export ("sdkVersionMinor")]
		int SdkVersionMinor { get; }

		// @property (readonly, nonatomic) int sdkVersionBuild;
		[Export ("sdkVersionBuild")]
		int SdkVersionBuild { get; }

		// @property (readonly, nonatomic) NSDate * sdkVersionDateTime;
		[Export ("sdkVersionDateTime")]
		NSDate SdkVersionDateTime { get; }

		// +(Ugi *)singleton;
		[Static, Export ("singleton")]
		Ugi Singleton ();

		// +(void)releaseSingleton;
		[Static, Export ("releaseSingleton")]
		void ReleaseSingleton ();

		// -(void)checkMicPermission:(void (^)(BOOL))callback;
		[Export ("checkMicPermission:")]
		void CheckMicPermission (Action<sbyte> callback);

		// -(UIInterfaceOrientation)desiredInterfaceOrientation;
		[Export ("desiredInterfaceOrientation")]
		UIInterfaceOrientation DesiredInterfaceOrientation ();

		// -(UIInterfaceOrientationMask)desiredInterfaceOrientationMask;
		[Export ("desiredInterfaceOrientationMask")]
		UIInterfaceOrientationMask DesiredInterfaceOrientationMask ();

		// -(void)openConnection;
		[Export ("openConnection")]
		void OpenConnection ();

		// -(void)closeConnection;
		[Export ("closeConnection")]
		void CloseConnection ();

		// -(UgiInventory *)startInventory:(id<UgiInventoryDelegate>)delegate withConfiguration:(UgiRfidConfiguration *)configuration withEpcs:(NSArray *)epcs;
		[Export ("startInventory:withConfiguration:withEpcs:")]
		UgiInventory StartInventory (UgiInventoryDelegate del, UgiRfidConfiguration configuration, NSObject [] epcs);

		// -(UgiInventory *)startInventoryIgnoringEpcs:(id<UgiInventoryDelegate>)delegate withConfiguration:(UgiRfidConfiguration *)configuration withEpcsToIgnore:(NSArray *)epcsToIgnore;
		[Export ("startInventoryIgnoringEpcs:withConfiguration:withEpcsToIgnore:")]
		UgiInventory StartInventoryIgnoringEpcs (UgiInventoryDelegate del, UgiRfidConfiguration configuration, NSObject [] epcsToIgnore);

		// -(UgiInventory *)startInventory:(id<UgiInventoryDelegate>)delegate withConfiguration:(UgiRfidConfiguration *)configuration;
		[Export ("startInventory:withConfiguration:")]
		UgiInventory StartInventory (UgiInventoryDelegate del, UgiRfidConfiguration configuration);

		// -(UgiInventory *)startInventory:(id<UgiInventoryDelegate>)delegate withConfiguration:(UgiRfidConfiguration *)configuration withEpc:(UgiEpc *)epc;
		[Export ("startInventory:withConfiguration:withEpc:")]
		UgiInventory StartInventory (UgiInventoryDelegate del, UgiRfidConfiguration configuration, UgiEpc epc);

		// -(BOOL)getGeigerCounterSound:(UgiGeigerCounterSound *)config;
		[Export ("getGeigerCounterSound:")]
		bool GetGeigerCounterSound (UgiGeigerCounterSound config);

		// -(void)setGeigerCounterSound:(UgiGeigerCounterSound *)config;
		[Export ("setGeigerCounterSound:")]
		void SetGeigerCounterSound (UgiGeigerCounterSound config);

		// -(UgiSpeakerTone *)getFoundItemSound;
		[Export ("getFoundItemSound")]
		UgiSpeakerTone GetFoundItemSound ();

		// -(void)setFoundItemSound:(UgiSpeakerTone *)sound;
		[Export ("setFoundItemSound:")]
		void SetFoundItemSound (UgiSpeakerTone sound);

		// -(UgiSpeakerTone *)getFoundLastItemSound;
		[Export ("getFoundLastItemSound")]
		UgiSpeakerTone GetFoundLastItemSound ();

		// -(void)setFoundLastItemSound:(UgiSpeakerTone *)sound;
		[Export ("setFoundLastItemSound:")]
		void SetFoundLastItemSound (UgiSpeakerTone sound);

		// -(BOOL)getDiagnosticData:(UgiDiagnosticData *)data resetCounters:(BOOL)reset;
		[Export ("getDiagnosticData:resetCounters:")]
		bool GetDiagnosticData (UgiDiagnosticData data, bool reset);

		// -(BOOL)getBatteryInfo:(UgiBatteryInfo *)retBatteryInfo;
		[Export ("getBatteryInfo:")]
		bool GetBatteryInfo (UgiBatteryInfo retBatteryInfo);

		// -(void)playSound:(UgiPlaySoundSoundTypes)sound;
		[Export ("playSound:")]
		void PlaySound (UgiPlaySoundSoundTypes sound);

		// -(void)setLoggingDestination:(LoggingDestination *)loggingDestination withParam:(NSObject *)param;
//		[Export ("setLoggingDestination:withParam:")]
//		void SetLoggingDestination (LoggingDestination loggingDestination, NSObject param);
	}
}


