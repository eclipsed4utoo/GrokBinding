using System;
using ObjCRuntime;

[assembly: LinkWith ("libUGrokItApi.a", LinkTarget.ArmV7 | LinkTarget.Simulator, SmartLink = true, ForceLoad = true)]
